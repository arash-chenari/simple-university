using Microsoft.EntityFrameworkCore;
using SimpleUniversity.Application.Classes.Contracts;
using SimpleUniversity.Domain;

namespace SimpleUniversity.Persistence.EF.Classes
{
    public class EFClassRepository : IClassRepository
    {
        private readonly EFDbContext _dbContext;

        public EFClassRepository(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Class @class)
        {
            _dbContext.Classes.Add(@class);
        }

        public Class? Find(int classId)
        {
            return _dbContext.Classes
                .Include(_ => _.Sections)
                .FirstOrDefault(_ => _.Id == classId);
        }

        public List<GetSectionDto> GetSections(int classId)
        {
            /*return _dbContext.Classes.Where(c => c.Id == classId)
                .SelectMany(_=> _.Sections)
                .Select(s => new GetSectionDto
                {
                    Id = s.Id,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    DayOfWeek = s.DayOfWeek
                }).ToList();*/
            
           return  _dbContext.Set<Section>()
                .Where(_=> _.ClassId == classId)
                .Select(s => new GetSectionDto
                {
                    Id = s.Id,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    DayOfWeek = s.DayOfWeek
                }).ToList();
        }
    }
}
