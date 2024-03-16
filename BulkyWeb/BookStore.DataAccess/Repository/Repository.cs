﻿using System.Linq.Expressions;
using BookStore.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repository;

public abstract class Repository<T> : IRepository<T>
    where T : class
{
    private readonly DbSet<T> _dbSet;

    protected Repository(DbContext db)
    {
        _dbSet = db.Set<T>();
    }
    
    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }
    
    public T? Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
    {
        return _dbSet.Where(filter).FirstOrDefault();
    }
    
    public IEnumerable<T> GetAll(string? includeProperties = null)
    {
        return _dbSet.ToList();
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}