using ProjectManagement.Contracts.Repository;

namespace ProjectManagement.Contracts.UnitOFWork;

public interface IUnitOfWork
{
    IProjectRepository Project { get; }
    IEmployeeRepository Employee { get; }

    void Save();
}