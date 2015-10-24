using System.Linq;
using Hack.Domain.DataContracts;
using Hack.Domain.Interfaces;
using Hack.EF;

namespace Hack.Server.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly HackDbContext _hackDbContext;

        public UserHelper(HackDbContext hackDbContext)
        {
            _hackDbContext = hackDbContext;
        }

        public ApplicationUser GetUserWith(string token)
        {
            var user = _hackDbContext.Users.FirstOrDefault(x => x.Token == token);

            return user != null ? new ApplicationUser(true, user.Id, user.Username) : new ApplicationUser(false);
        }
    }
}