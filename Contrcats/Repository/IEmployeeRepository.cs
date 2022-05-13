using ProjectManagement.Entities.Models;

namespace ProjectManagement.Contracts.Repository;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetEmployeeListByProjectId(Guid projectiId, bool trackChanges);
    Employee GetEmployeeByProjectId(Guid id, Guid employeeId, bool trackChanges);

    void CreateEmployeeForProject(Guid id, Employee employee);
    void DeleteEmployee(Employee employee);
}