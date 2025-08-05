using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleUniversity.Application.Students.Contracts;

namespace SimpleUniversity.EndPoint.Api.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }


        [HttpPost]
        public int Create(CreateStudentDto dto)
        {
            return _service.Create(dto);
        }

        [HttpGet]
        public List<GetStudentDto> GetAll()
        {
            return _service.GetAll();
        }
    }
}
