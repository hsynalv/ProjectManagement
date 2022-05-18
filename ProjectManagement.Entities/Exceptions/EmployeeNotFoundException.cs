namespace ProjectManagement.Entities.Exceptions;

public sealed class EmployeeNotFoundException : NotFoundException
{
    public EmployeeNotFoundException(Guid employeeId) : base($"The employeewith {employeeId} doesn't exist")
    {
    }
}