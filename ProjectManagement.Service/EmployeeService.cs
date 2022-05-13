using AutoMapper;
using ProjectManagement.Contracts;
using ProjectManagement.Contracts.UnitOFWork;
using ProjectManagement.Entities.Models;
using ProjectManagement.Service.Contracts;
using ProjectManagement.Shared.DataTransferObject;

namespace ProjectManagement.Service;

public class EmployeeService : IEmployeeService
{
    private readonly ILoggerManager _loggerManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmployeeService(ILoggerManager loggerManager, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _loggerManager = loggerManager;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public IEnumerable<EmployeeDto> GetAllEmployeesByProjectId(Guid projectId, bool trackChanges)
    {
        try
        {
            var employees = _unitOfWork.Employee.GetEmployeeListByProjectId(projectId, trackChanges);
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }
        catch (Exception e)
        {
            _loggerManager.LogError("EmployeeService.GetAllEmployeesByProjectId : " + e.Message);
            throw;
        }
    }

    public EmployeeDto GetOneEmployeeById(Guid projectId, Guid employeeId, bool trackChanges)
    {
        try
        {
            var employee = _unitOfWork.Employee.GetEmployeeByProjectId(projectId, employeeId, trackChanges);
            return _mapper.Map<EmployeeDto>(employee);
        }
        catch (Exception e)
        {
            _loggerManager.LogError("EmployeeService.GetOneEmployeeById : " + e.Message);
            throw;
        }
    }
}