namespace ProjectManagement.Entities.Models;

public class Employee
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string? Position { get; set; }


    public Guid? ProjectId { get; set; }
    public Project Project { get; set; }
}