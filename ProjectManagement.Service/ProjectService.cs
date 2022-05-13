using AutoMapper;
using ProjectManagement.Contracts;
using ProjectManagement.Contracts.UnitOFWork;
using ProjectManagement.Service.Contracts;
using ProjectManagement.Shared.DataTransferObject;

namespace ProjectManagement.Service;

public class ProjectService : IProjectService
{
    private readonly ILoggerManager _loggerManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ProjectService(IUnitOfWork unitOfWork, ILoggerManager loggerManager, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }

    public IEnumerable<ProjectDto> GetAllProject(bool trackChanges)
    {
        try
        {
            var projects = _unitOfWork.Project.GetAllProjects(trackChanges);
            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }
        catch (Exception e)
        {
            _loggerManager.LogError("ProjectService.GetAllProjects() has ben error: " + e.Message);
            throw;
        }
    }

    public ProjectDto GetOneProjectById(Guid id, bool trackChanges)
    {
        try
        {
            var project = _unitOfWork.Project.GetOneProjectById(id, trackChanges);
            return _mapper.Map<ProjectDto>(project);
        }
        catch (Exception e)
        {
            _loggerManager.LogError("ProjectService.GetOneProjectById() has ben error: " + e.Message);
            throw;
        }
    }
}