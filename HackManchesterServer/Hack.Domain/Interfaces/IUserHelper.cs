using Hack.Domain.DataContracts;

namespace Hack.Domain.Interfaces
{
    public interface IUserHelper
    {
        ApplicationUser GetUserWith(string token);
    }
}