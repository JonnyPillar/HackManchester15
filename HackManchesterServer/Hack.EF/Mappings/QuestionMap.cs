using Hack.Domain.Entities;

namespace Hack.EF.Mappings
{
    public class QuestionMap : BaseEntityMap<Question>
    {
        public QuestionMap() : base("Question")
        {
            HasRequired(x => x.User).WithMany(x => x.Questions).HasForeignKey(x => x.UserId);
            HasMany(s => s.QuestionTags)
                .WithMany(c => c.Questions)
                .Map(cs =>
                {
                    cs.MapLeftKey("QuestionId");
                    cs.MapRightKey("QuestionTagId");
                    cs.ToTable("QuestionQuestionTag");
                });
        }
    }
}