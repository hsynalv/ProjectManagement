using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Service.Contracts;

namespace ProjectManagement.Presentation.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly IServiceManager _service;

    public ProjectsController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAllProjects()
    {
        var projects = _service.ProjectService.GetAllProject(false);
        return Ok(projects);
    }

    [HttpGet("{projectId:guid}")]
    public IActionResult GetOneProjectById(Guid projectId)
    {
        var project = _service.ProjectService.GetOneProjectById(projectId, false);
        return Ok(project);
    }
}