using SimpleUniversity.Domain;

namespace SimpleUniversity.Application.Classes.Contracts
{
    public  interface IClassRepository
    {
        void Add(Class @class);
        Class? Find(int classId);
        List<GetSectionDto> GetSections(int classId);
    }
}
