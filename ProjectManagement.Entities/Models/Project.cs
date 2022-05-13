namespace ProjectManagement.Entities.Models;

public class Project
{
    public Guid Id { get; set; }
    public string ProjectName { get; set; }

    public string? Description { get; set; }
    public string? Field { get; set; }
    public string? ImageUrl { get; set; }

    public ICollection<Employee> Employees { get; set; }
}