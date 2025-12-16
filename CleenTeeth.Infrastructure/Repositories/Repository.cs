using CleanTeeth.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly CleanTeethDbContext dbContext;

    public Repository(CleanTeethDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public Task<T> Add(T entity)
    {
        dbContext.Add(entity);
        return Task.FromResult(entity);
    }

    public Task Delete(T entity)
    {
        dbContext.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        var items = await dbContext.Set<T>().ToListAsync();
        return items;

    }

    public async Task<T?> GetById(Guid id)
    {
        var item = await dbContext.Set<T>().FindAsync(id);
        return item;
    }

    public Task Update(T entity)
    {
        dbContext.Update(entity);
        return Task.CompletedTask;
    }
}
