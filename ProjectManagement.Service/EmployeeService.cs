using AutoMapper;
using ProjectManagement.Contracts;
using ProjectManagement.Contracts.UnitOFWork;
using ProjectManagement.Entities.Exceptions;
using ProjectManagement.Service.Contracts;
using ProjectManagement.Shared.DataTransferObject;

namespace ProjectManagement.Service;

public class EmployeeService : IEmployeeService
{
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeService(ILoggerManager loggerManager, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _loggerManager = loggerManager;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public IEnumerable<EmployeeDto> GetAllEmployeesByProjectId(Guid projectId, bool trackChanges)
    {
        CheckProjectExists(projectId);
        var employees = _unitOfWork.Employee.GetEmployeeListByProjectId(projectId, trackChanges);
        return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }

    public EmployeeDto GetOneEmployeeById(Guid projectId, Guid employeeId, bool trackChanges)
    {
        CheckProjectExists(projectId);
        var employee = _unitOfWork.Employee.GetEmployeeByProjectId(projectId, employeeId, trackChanges);
        if (employee == null)
            throw new EmployeeNotFoundException(employeeId);
        return _mapper.Map<EmployeeDto>(employee);
    }

    private void CheckProjectExists(Guid projectId)
    {
        var project = _unitOfWork.Project.GetOneProjectById(projectId, false);
        if (project == null)
            throw new ProjectNotFoundException(projectId);
    }
}