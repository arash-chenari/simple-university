using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleUniversity.Domain;

namespace SimpleUniversity.Persistence.EF.Classes
{
    public class ClassesEntityMap : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Classes");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(_ => _.Term)
                .WithMany(_ => _.Classes)
                .HasForeignKey(_ => _.TermId);
        }
    }
}
