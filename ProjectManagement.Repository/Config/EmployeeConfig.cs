using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Entities.Models;

namespace ProjectManagement.Repository.Config;

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.ProjectId);
        builder.Property(x => x.FirstName).IsRequired();
        builder.Property(x => x.LastName).IsRequired();

        builder.HasOne(x => x.Project)
            .WithMany(p => p.Employees)
            .HasForeignKey(x => x.ProjectId);


        builder.HasData(
            new Employee
            {
                Id = Guid.NewGuid(),
                ProjectId = new Guid("b67e3d43-23ef-444f-a022-5294810a5428"),
                FirstName = "Ahmet",
                LastName = "Yıldırım",
                Age = 30,
                Position = "Senior Developer"
            }
        );
    }
}