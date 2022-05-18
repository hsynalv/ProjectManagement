using AutoMapper;
using ProjectManagement.Contracts;
using ProjectManagement.Contracts.UnitOFWork;
using ProjectManagement.Entities.Exceptions;
using ProjectManagement.Service.Contracts;
using ProjectManagement.Shared.DataTransferObject;

namespace ProjectManagement.Service;

public class ProjectService : IProjectService
{
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ProjectService(IUnitOfWork unitOfWork, ILoggerManager loggerManager, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }

    public IEnumerable<ProjectDto> GetAllProject(bool trackChanges)
    {
        var projects = _unitOfWork.Project.GetAllProjects(trackChanges);
        return _mapper.Map<IEnumerable<ProjectDto>>(projects);
    }

    public ProjectDto GetOneProjectById(Guid id, bool trackChanges)
    {
        var project = _unitOfWork.Project.GetOneProjectById(id, trackChanges);
        if (project == null)
            throw new ProjectNotFoundException(id);
        return _mapper.Map<ProjectDto>(project);
    }
}