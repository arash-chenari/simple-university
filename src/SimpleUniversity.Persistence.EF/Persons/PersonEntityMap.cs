using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleUniversity.Domain;

namespace SimpleUniversity.Persistence.EF.Persons
{
    public class PersonEntityMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");

            builder.HasKey(p => p.Id);

            builder.OwnsOne(p => p.ContactInfo, c =>
            {
                c.Property(_ => _.Phone).HasColumnName("Phone")
                .HasMaxLength(15).IsRequired(false);

                c.Property(_ => _.Address).HasColumnName("Address")
                .HasMaxLength(200).IsRequired(false);
            });

            builder.HasDiscriminator<PersonType>("PersonType")
                .HasValue<Student>(PersonType.Student)
                .HasValue<Teacher>(PersonType.Teacher);

            builder.Property("PersonType")
                .HasColumnName("PersonType")
                .IsRequired();
        }
    }
}
