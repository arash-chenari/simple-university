using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleUniversity.Domain;

namespace SimpleUniversity.Persistence.EF.SelectedClasses
{
    public class SelectedClassEntityMap : IEntityTypeConfiguration<SelectedClass>
    {
        public void Configure(EntityTypeBuilder<SelectedClass> builder)
        {
            builder.ToTable("SelectedClasses");

            builder.HasKey(_ => new { _.StudentId, _.ClassId });

            builder.HasOne(_ => _.Student)
                .WithMany(_ => _.SelectedClasses)
                .HasForeignKey(_ => _.StudentId);

            builder.HasOne(_ => _.Class)
                .WithMany(_ => _.SelectedClasses)
                .HasForeignKey(_ => _.ClassId);
        }
    }
}
