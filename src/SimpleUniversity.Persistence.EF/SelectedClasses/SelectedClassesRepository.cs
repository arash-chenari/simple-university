using SimpleUniversity.Application.SelectedClasses.Contracts;
using SimpleUniversity.Domain;

namespace SimpleUniversity.Persistence.EF.SelectedClasses
{
    public class EFSelectedClassRepository : ISelectedClassRepository
    {
        private readonly EFDbContext _dbContext;

        public EFSelectedClassRepository(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(SelectedClass selectedClass)
        {
            _dbContext.SelectedClasses.Add(selectedClass);
        }
    }
}
