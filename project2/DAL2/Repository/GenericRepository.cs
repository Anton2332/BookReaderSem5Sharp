using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL2.Repository;

public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
{
    protected readonly DBContext DbContext;
    protected readonly DbSet<TEntity> Table;
    
    public bool AutoSaveChanges { get; set; } = true;

    public GenericRepository(DBContext dbContext)
    {
        DbContext = dbContext;
        Table = DbContext.Set<TEntity>();
    }

    public IQueryable<TEntity> Items => Table;

    public virtual async Task RemoveAsync(int id, CancellationToken cancel = default)
    {
        DbContext.Remove(new TEntity { Id = id });

        if (AutoSaveChanges)
            await DbContext.SaveChangesAsync(cancel).ConfigureAwait(false);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        => await Table.ToListAsync();

    public virtual async Task<TEntity> GetByIdAsync(int id, CancellationToken cancel = default)
        => await Items.SingleOrDefaultAsync(item => item.Id == id, cancel).ConfigureAwait(false);

    public virtual async Task AddAsync(TEntity entity, CancellationToken cancel = default)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity));
        await Table.AddAsync(entity);

        if (AutoSaveChanges)
            await DbContext.SaveChangesAsync(cancel).ConfigureAwait(false);        
    }

    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancel = default)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity));

        DbContext.Entry(entity).State = EntityState.Modified;

        if (AutoSaveChanges)
            await DbContext.SaveChangesAsync(cancel).ConfigureAwait(false);
    }
    
}