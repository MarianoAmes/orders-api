using OrderTechnicalTest.Domain.Repositories;
using OrderTechnicalTest.Infrastructure.EFC.Context;

namespace OrderTechnicalTest.Infrastructure.EFC.UnitOfWork;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public AppDbContext Context { get; } = context;

    public async Task CompleteAsync()
    {
        await Context.SaveChangesAsync();
    }
}