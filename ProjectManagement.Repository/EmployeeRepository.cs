using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Contracts.Repository;
using ProjectManagement.Entities.Models;

namespace ProjectManagement.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Employee> GetEmployeesByProjectId(Guid projectiId, bool trackChanges)
        {
            return FindByCondition(emp => emp.ProjectId.Equals(projectiId), trackChanges).OrderBy(e => e.FirstName);
        }

        public Employee GetEmployeeByProjectId(Guid projectId, Guid employeeId, bool trackChanges)
        {
            return FindByCondition(emp => emp.ProjectId.Equals(projectId) && emp.Id.Equals(employeeId), trackChanges)
                .FirstOrDefault();
        }

        public void CreateEmployeeForProject(Guid id, Employee employee)
        {
            employee.ProjectId = id;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee) => Delete(employee);
    }
}
