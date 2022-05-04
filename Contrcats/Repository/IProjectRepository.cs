using ProjectManagement.Entities.Models;

namespace ProjectManagement.Contracts.Repository
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAllProjects(bool trackChanges);
        Project GetProject(Guid id,bool trackChanges);

        void CreateProject(Project project);
        void DeleteProject(Project project);

    }
}
