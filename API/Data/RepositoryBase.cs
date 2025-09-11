using System.Linq.Expressions;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected DataContext DataContext;

    public RepositoryBase(DataContext dataContext) => DataContext = dataContext;

    public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ?
        DataContext.Set<T>().AsNoTracking() : DataContext.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => !trackChanges ?
        DataContext.Set<T>().Where(expression).AsNoTracking() : DataContext.Set<T>().Where(expression);

    public void Create(T entity) => DataContext.Set<T>().Add(entity);

    public void Update(T entity) => DataContext.Set<T>().Update(entity);

    public void Delete(T entity) => DataContext.Set<T>().Remove(entity);
}