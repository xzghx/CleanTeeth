using CleanTeeth.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Persistence.UnitsOfWork;

public class UnitOfWorkEfCore : IUnitOfWork
{
    private readonly CleanTeethDbContext dbContext;

    public UnitOfWorkEfCore(CleanTeethDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task Commit()
    {
        await dbContext.SaveChangesAsync();
    }

    public Task RollBack()
    {
        return Task.CompletedTask;
    }
}
