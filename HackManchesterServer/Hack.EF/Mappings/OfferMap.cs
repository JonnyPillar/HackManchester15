using System.Data.Entity.ModelConfiguration;
using Hack.Domain.Entities;

namespace Hack.EF.Mappings
{
    public class OfferMap : BaseEntityMap<Offer>
    {
        public OfferMap() : base("Offer")
        {
            HasRequired(x => x.SubmittedByUser).WithMany(x => x.Offers).HasForeignKey(x => x.SubmittedByUserId).WillCascadeOnDelete(false);
            HasRequired(x => x.QuestionFor).WithMany(x => x.Offers).HasForeignKey(x => x.QuestionForId);
        }
    }
}