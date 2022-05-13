using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Contracts;

namespace ProjectManagement.Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T : class
{
    protected RepositoryContext _repositoryContext;

    protected RepositoryBase(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }

    public IQueryable<T> FindAll(bool trackChanges)
    {
        return !trackChanges ? _repositoryContext.Set<T>().AsNoTracking() : _repositoryContext.Set<T>();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        return !trackChanges
            ? _repositoryContext.Set<T>().Where(expression).AsNoTracking()
            : _repositoryContext.Set<T>();
    }

    public void Create(T entity)
    {
        _repositoryContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        _repositoryContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _repositoryContext.Set<T>().Add(entity);
    }
}