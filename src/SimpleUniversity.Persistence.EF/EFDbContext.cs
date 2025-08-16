using Microsoft.EntityFrameworkCore;
using SimpleUniversity.Domain;

namespace SimpleUniversity.Persistence.EF
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDbContext).Assembly);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<SelectedClass> SelectedClasses { get; set; }
        public DbSet<Class> Classes { get; set; }
    }
}
