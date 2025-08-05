using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleUniversity.Application.SelectedClasses.Contracts;

namespace SimpleUniversity.EndPoint.Api.Controllers
{
    [Route("api/selected-classes")]
    [ApiController]
    public class SelectedClassesController : ControllerBase
    {
        private readonly ISelectedClassService _service;

        public SelectedClassesController(ISelectedClassService service)
        {
            _service = service;
        }

        [HttpPost]
        public void SelectClass(SelectClassesDto dto)
        {
            _service.SelectClass(dto);
        }
    }

    
}
