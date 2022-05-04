using ProjectManagement.Contracts;
using ProjectManagement.Contracts.Repository;
using ProjectManagement.Entities.Models;

namespace ProjectManagement.Repository
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Project> GetAllProjects(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(p => p.ProjectName).ToList();

        public Project GetProject(Guid id, bool trackChanges) =>
            FindByCondition(p => p.Equals(id), trackChanges).SingleOrDefault();

        public void CreateProject(Project project) => Create(project);

        public void DeleteProject(Project project) => Delete(null);
    }
}
