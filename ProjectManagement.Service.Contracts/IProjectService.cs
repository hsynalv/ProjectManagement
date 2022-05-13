using ProjectManagement.Entities.Models;
using ProjectManagement.Shared.DataTransferObject;

namespace ProjectManagement.Service.Contracts;

public interface IProjectService
{
    IEnumerable<ProjectDto> GetAllProject(bool trackChanges);
    ProjectDto GetOneProjectById(Guid id, bool trackChanges);
}