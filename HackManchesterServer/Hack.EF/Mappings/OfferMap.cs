using System.Data.Entity.ModelConfiguration;
using Hack.Domain.Entities;

namespace Hack.EF.Mappings
{
    public class OfferMap : BaseEntityMap<Offer>
    {
        public OfferMap() : base("Offer")
        {

        }
    }
}