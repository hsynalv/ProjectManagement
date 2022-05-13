using ProjectManagement.Contracts.Repository;
using ProjectManagement.Entities.Models;

namespace ProjectManagement.Repository;

public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
{
    public ProjectRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Project> GetAllProjects(bool trackChanges)
    {
        return FindAll(trackChanges).OrderBy(p => p.ProjectName).ToList();
    }

    public Project GetOneProjectById(Guid id, bool trackChanges)
    {
        return FindByCondition(p => p.Id.Equals(id), trackChanges).SingleOrDefault();
    }

    public void CreateProject(Project project)
    {
        Create(project);
    }

    public void DeleteProject(Project project)
    {
        Delete(null);
    }
}