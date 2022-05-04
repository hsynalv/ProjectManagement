using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Service.Contracts;

namespace ProjectManagement.API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private IServiceManager _serviceManager;

        public ProjectsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = _serviceManager.ProjectService.GetAllProject(false);
            return Ok(list);
        }
    }
}
