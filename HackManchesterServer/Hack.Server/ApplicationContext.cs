using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Hack.Domain.DataContracts;
using Hack.Domain.Interfaces;

namespace Hack.Server
{
    public class ApplicationContext : IApplicationContext
    {
        private readonly IUserHelper _userHelper;
        private bool _initialised;

        public ApplicationContext(IUserHelper userHelper)
        {
            _userHelper = userHelper;
        }

        public ApplicationUser User { get; private set; }

        public void InitialiseFrom(HttpRequestMessage request)
        {
            if (!_initialised)
            {
                var authToken = GetHeaderValue(request, "Authorization");

                if (string.IsNullOrWhiteSpace(authToken))
                    return;

                User = !string.IsNullOrEmpty(authToken)
                    ? _userHelper.GetUserWith(authToken)
                    : new ApplicationUser(false);

                _initialised = true;
            }
        }

        private static string GetHeaderValue(HttpRequestMessage request, string name)
        {
            IEnumerable<string> values;
            request.Headers.TryGetValues(name, out values);
            return values != null ? values.FirstOrDefault() : null;
        }
    }
}