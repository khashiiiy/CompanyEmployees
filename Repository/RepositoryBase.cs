using System.Linq.Expressions;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly RepositoryContexts _repositoryContexts;

    protected RepositoryBase(RepositoryContexts repositoryContexts)
    {
        _repositoryContexts = repositoryContexts;
    }

    public IQueryable<T> FindAll(bool trackChanges) => !trackChanges
        ? _repositoryContexts.Set<T>()
            .AsNoTracking()
        : _repositoryContexts.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
        !trackChanges
            ? _repositoryContexts.Set<T>().Where(expression).AsNoTracking()
            : _repositoryContexts.Set<T>().Where(expression);

    public void Create(T entity) => _repositoryContexts.Set<T>().Add(entity);

    public void Update(T entity) => _repositoryContexts.Set<T>().Update(entity);

    public void Delete(T entity) => _repositoryContexts.Set<T>().Remove(entity);
}