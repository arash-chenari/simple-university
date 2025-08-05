using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleUniversity.Domain;

namespace SimpleUniversity.Persistence.EF.Sections
{
    public class SectionEntityMap : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable("Sections");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(_ => _.Class)
                .WithMany(_ => _.Sections)
                .HasForeignKey(_ => _.ClassId);
        }
    }
}
