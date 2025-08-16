namespace SimpleUniversity.Application.Classes.Contracts;

public interface IClassService
{
    int Create(CreateClassDto dto);
    int AddSection(int classId, AddSectionDto dto);
    List<GetSectionDto> GetSections(int classId);
    void DeleteSection(int classId, int sectionId);
}