using ProjectManagement.Contracts;
using ProjectManagement.Contracts.UnitOFWork;
using ProjectManagement.Service.Contracts;

namespace ProjectManagement.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProjectService> _projectService;

        public ServiceManager(IUnitOfWork unitOfWork, ILoggerManager loggerManager)
        {
            _projectService = new Lazy<IProjectService>(() => new ProjectService(unitOfWork, loggerManager));
        }

        public IProjectService ProjectService => _projectService.Value;
    }
}
