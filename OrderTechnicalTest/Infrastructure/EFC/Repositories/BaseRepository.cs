using Microsoft.EntityFrameworkCore;
using OrderTechnicalTest.Domain.Repositories;
using OrderTechnicalTest.Infrastructure.EFC.Context;

namespace OrderTechnicalTest.Infrastructure.EFC.Repositories;

public abstract class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity>
    where TEntity : class
{
    protected readonly AppDbContext Context = context;

    public async Task AddAsync(TEntity entity)
        => await Context.Set<TEntity>().AddAsync(entity);

    public virtual async Task<TEntity?> FindByIdAsync(Guid id)
        => await Context.Set<TEntity>().FindAsync(id);

    public void Update(TEntity entity)
        => Context.Set<TEntity>().Update(entity);

    public void Remove(TEntity entity)
        => Context.Set<TEntity>().Remove(entity);

    public virtual async Task<IEnumerable<TEntity>> ListAsync()
        => await Context.Set<TEntity>().ToListAsync();
}