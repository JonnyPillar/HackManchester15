using System.Net.Http;
using Hack.Domain.DataContracts;

namespace Hack.Domain.Interfaces
{
    public interface IApplicationContext
    {
        ApplicationUser User { get; }
        void InitialiseFrom(HttpRequestMessage request);
    }
}