namespace PomToolbox.Services.Interfaces;

using System.Collections.Generic;

public interface IDatabaseService<T> where T : class {
    public Task<T> Create(T entity);
    public Task<List<T>> Get();
    public Task<T?> Get(int id);
    public Task<T> Update(T entity);
    public Task Delete(T entity);
}