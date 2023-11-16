using FormulaOne.Data;
using FormulaOne.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    public readonly ILogger _logger;
    protected AppDbContext _context;
    internal DbSet<T> _dbSet;

    // Constructor
    public GenericRepository(AppDbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
        _dbSet = context.Set<T>();
    }

    // Services Implementations
    public virtual async Task<bool> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        return true;
    }

    public virtual Task<IEnumerable<T>> All()
    {
        throw new NotImplementedException();
    }

    public virtual Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T?> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }
}