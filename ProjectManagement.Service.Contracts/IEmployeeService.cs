using ProjectManagement.Entities.Models;
using ProjectManagement.Shared.DataTransferObject;

namespace ProjectManagement.Service.Contracts;

public interface IEmployeeService
{
    IEnumerable<EmployeeDto> GetAllEmployeesByProjectId(Guid projectId, bool trackChanges);
    EmployeeDto GetOneEmployeeById(Guid projectId, Guid employeeId, bool trackChanges);
}