using SimpleUniversity.Application.Contracts;

namespace SimpleUniversity.Persistence.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly EFDbContext _dbContext;

        public EFUnitOfWork(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
