using Microsoft.EntityFrameworkCore;

namespace api.service.alyoza.infrastructure.context;

public class ContextGeneral<T> : IContextGeneral<T> where T : class
{
    public AlyozaDbContext Context { get; }

    public ContextGeneral(AlyozaDbContext context)
    {
        Context = context;
    }

    public async Task<List<T>> GetAll()
    {
        return await Context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetById(int id)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public async Task<T> Add(T entity)
    {
        Context.Set<T>().Add(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task Update(T entity)
    {
        Context.Set<T>().Update(entity);
        await Context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        Context.Set<T>().Remove(entity);
        await Context.SaveChangesAsync();
    }
}