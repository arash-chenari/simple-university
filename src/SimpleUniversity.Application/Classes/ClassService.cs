using SimpleUniversity.Application.Classes.Contracts;
using SimpleUniversity.Application.Classes.Contracts.Exceptions;
using SimpleUniversity.Application.Contracts;
using SimpleUniversity.Domain;

namespace SimpleUniversity.Application.Classes;

public class ClassService : IClassService
{
    private readonly IClassRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public ClassService(
        IClassRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public int Create(CreateClassDto dto)
    {
        //check for valid teacher , course , term
        var @class = new Class
        {
            CourseId = dto.CourseId,
            TeacherId = dto.TeacherId,
            TermId = dto.TermId,
            Capacity = dto.Capacity
        };

        _repository.Add(@class);
        _unitOfWork.SaveChanges();

        return @class.Id;
    }

    public int AddSection(int classId, AddSectionDto dto)
    {
        var @class = _repository.Find(classId);
        if (@class is null)
        {
            throw new ClassNotFoundException();
        }
        // check to see if section already exists

        var section = new Section
        {
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            DayOfWeek = dto.DayOfWeek
        };

        @class.Sections.Add(section);
        
        _unitOfWork.SaveChanges();

        return section.Id;
    }
    
    public List<GetSectionDto> GetSections(int classId)
    {
        return _repository.GetSections(classId);
    }
    
    public void DeleteSection(int classId, int sectionId)
    {
        var @class = _repository.Find(classId);
        if (@class is null)
        {
            throw new ClassNotFoundException();
        }
        
        var section = @class.Sections
            .FirstOrDefault(s => s.Id == sectionId);
        if (section is null)
        {
            throw new SectionNotFoundException();
        }
        
        @class.Sections.Remove(section);
        _unitOfWork.SaveChanges();
    }
}