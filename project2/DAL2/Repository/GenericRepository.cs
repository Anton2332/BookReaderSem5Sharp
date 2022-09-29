using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL2.Repository;

public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
{
    protected readonly DBContext _dbContext;
    protected readonly DbSet<TEntity> _table;
    
    public bool AutoSaveChanges { get; set; } = true;

    public GenericRepository(DBContext dbContext)
    {
        _dbContext = dbContext;
        _table = _dbContext.Set<TEntity>();
    }

    public IQueryable<TEntity> Items => _table;

    public virtual async Task RemoveAsync(int id, CancellationToken cancel = default)
    {
        _dbContext.Remove(new TEntity { Id = id });

        if (AutoSaveChanges)
            await _dbContext.SaveChangesAsync(cancel).ConfigureAwait(false);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        => await _table.ToListAsync();

    public virtual async Task<TEntity> GetByIdAsync(int id, CancellationToken cancel = default)
        => await Items.SingleOrDefaultAsync(item => item.Id == id, cancel).ConfigureAwait(false);

    public virtual async Task AddAsync(TEntity entity, CancellationToken cancel = default)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity));
        await _table.AddAsync(entity);

        if (AutoSaveChanges)
            await _dbContext.SaveChangesAsync(cancel).ConfigureAwait(false);        
    }

    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancel = default)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity));

        _dbContext.Entry(entity).State = EntityState.Modified;

        if (AutoSaveChanges)
            await _dbContext.SaveChangesAsync(cancel).ConfigureAwait(false);
    }
    
}