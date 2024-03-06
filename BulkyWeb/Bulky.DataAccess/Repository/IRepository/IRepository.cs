﻿using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository.IRepository;

public interface IRepository<T> 
    where T : class
{
    void Add(T entity);
    
    T? Get(Expression<Func<T, bool>> filter);
    
    IEnumerable<T> GetAll();
    
    void Remove(T entity);
    
    void RemoveRange(IEnumerable<T> entities);
}