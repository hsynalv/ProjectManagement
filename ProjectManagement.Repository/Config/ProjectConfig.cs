using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Entities.Models;

namespace ProjectManagement.Repository.Config;

public class ProjectConfig : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProjectName).IsRequired().HasMaxLength(60);

        builder.HasData(
            new Project
            {
                Id = new Guid("b67e3d43-23ef-444f-a022-5294810a5428"),
                ProjectName = "ASP.NET Core Web API Project",
                Description = "Web Application Programming Interface",
                Field = "Computer Science"
            });
    }
}