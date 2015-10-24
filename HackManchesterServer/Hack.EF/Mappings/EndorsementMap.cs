using System.Data.Entity.ModelConfiguration;
using Hack.Domain.Entities;

namespace Hack.EF.Mappings
{
    public class EndorsementMap : BaseEntityMap<Endorsement>
    {
        public EndorsementMap() : base("Endorsement")
        {
        }
    }
}