using Microsoft.AspNetCore.Mvc;
using SimpleUniversity.Application.Classes.Contracts;

namespace SimpleUniversity.EndPoint.Api.Controllers;

[Route("api/classes")]
[ApiController]
public class ClassesController: ControllerBase
{
    private readonly IClassService _service;

    public ClassesController(IClassService service)
    {
        _service = service;
    }

    [HttpPost]
    public int CreateClass(CreateClassDto dto)
    {
        return _service.Create(dto);
    }
    
    
    [HttpPatch("{id:int}")]
    public int AddSection(int id, AddSectionDto dto)
    {
        return _service.AddSection(id, dto);
    }

    [HttpGet("{id:int}/sections")]
    public List<GetSectionDto> GetSections(int id)
    {
        return _service.GetSections(id);
    }

    [HttpDelete("{id:int}/sections/{sectionId:int}")]
         public void DeleteSection(int id, int sectionId)
         {
             _service.DeleteSection(id,sectionId);
         }
}