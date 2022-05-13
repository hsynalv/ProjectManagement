using AutoMapper;
using ProjectManagement.Contracts;
using ProjectManagement.Contracts.UnitOFWork;
using ProjectManagement.Service.Contracts;

namespace ProjectManagement.Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IEmployeeService> _employeeService;
    private readonly Lazy<IProjectService> _projectService;

    public ServiceManager(IUnitOfWork unitOfWork, ILoggerManager loggerManager, IMapper mapper)
    {
        _projectService =
            new Lazy<IProjectService>(() => new ProjectService(unitOfWork, loggerManager, mapper));
        _employeeService =
            new Lazy<IEmployeeService>(() => new EmployeeService(loggerManager, unitOfWork, mapper));
    }

    public IProjectService ProjectService => _projectService.Value;
    public IEmployeeService EmployeeService => _employeeService.Value;
}