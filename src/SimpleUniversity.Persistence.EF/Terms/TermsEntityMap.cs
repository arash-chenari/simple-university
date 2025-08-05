using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleUniversity.Domain;

namespace SimpleUniversity.Persistence.EF.Terms
{
    internal class TermsEntityMap : IEntityTypeConfiguration<Term>
    {
        public void Configure(EntityTypeBuilder<Term> builder)
        {
            builder.ToTable("Terms");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.IsActive)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}
