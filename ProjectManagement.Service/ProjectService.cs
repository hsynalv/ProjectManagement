using ProjectManagement.Contracts;
using ProjectManagement.Contracts.UnitOFWork;
using ProjectManagement.Entities.Models;
using ProjectManagement.Service.Contracts;

namespace ProjectManagement.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _loggerManager;

        public ProjectService(IUnitOfWork unitOfWork, ILoggerManager loggerManager)
        {
            _unitOfWork = unitOfWork;
            _loggerManager = loggerManager;
        }

        public IEnumerable<Project> GetAllProject(bool trackChanges)
        {
            var projects = _unitOfWork.Project.GetAllProjects(trackChanges);
            return projects;
        }
    }
}