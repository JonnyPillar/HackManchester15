using Hack.Domain.Entities;

namespace Hack.EF.Mappings
{
    public class UserMap : BaseEntityMap<User>
    {
        public UserMap() : base("User")
        {
        }
    }
}