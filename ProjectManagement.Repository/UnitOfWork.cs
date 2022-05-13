using ProjectManagement.Contracts.Repository;
using ProjectManagement.Contracts.UnitOFWork;

namespace ProjectManagement.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly RepositoryContext _context;
    private Lazy<IEmployeeRepository> _employeeRepository;
    private Lazy<IProjectRepository> _projectRepository;

    public UnitOfWork(RepositoryContext context)
    {
        _context = context;
    }

    public IProjectRepository Project =>
        (_projectRepository ?? new Lazy<IProjectRepository>(() => new ProjectRepository(_context))).Value;

    public IEmployeeRepository Employee =>
        (_employeeRepository ?? new Lazy<IEmployeeRepository>(() => new EmployeeRepository(_context))).Value;

    public void Save()
    {
        _context.SaveChanges();
    }
}