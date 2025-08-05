using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleUniversity.Domain;

namespace SimpleUniversity.Persistence.EF.Teachers
{
    public class TeacherEntityMap : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasMany(_ => _.Classes)
                .WithOne(_ => _.Teacher)
                .HasForeignKey(_ => _.TeacherId);
        }
    }
}
