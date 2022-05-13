namespace ProjectManagement.Shared.DataTransferObject
{
    public record ProjectDto(Guid Id, string ProjectName, string Description, string Field);

    public record EmployeeDto(Guid Id, string FirstName, String LastName, int Age, string Position);
}
