using ProjectManagement.Entities.Models;

namespace ProjectManagement.Service.Contracts
{
    public interface IProjectService
    {
        IEnumerable<Project> GetAllProject(bool trackChanges);
    }
}