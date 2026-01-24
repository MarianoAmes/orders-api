using OrderTechnicalTest.Infrastructure.EFC.Context;

namespace OrderTechnicalTest.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
    AppDbContext Context { get; }
}