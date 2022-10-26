using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL2.Repository;

public class UserBookRepository : IUserBookRepository
{
    readonly DBContext DbContext;
    readonly DbSet<UserBook> Table;
    
    private bool AutoSaveChanges { get; set; } = true;

    public UserBookRepository(DBContext dbContext)
    {
        DbContext = dbContext;
        Table = DbContext.Set<UserBook>();
    }

    public IQueryable<UserBook> Items => Table;

    public virtual async Task RemoveAsync(string id, CancellationToken cancel = default)
    {
        DbContext.Remove(new UserBook { Id = id });

        if (AutoSaveChanges)
            await DbContext.SaveChangesAsync(cancel).ConfigureAwait(false);
    }

    public virtual async Task<IEnumerable<UserBook>> GetAllAsync()
        => await Table.ToListAsync();

    public virtual async Task<UserBook> GetByIdAsync(string id, CancellationToken cancel = default)
        => await Items.SingleOrDefaultAsync(item => item.Id == id, cancel).ConfigureAwait(false);

    public virtual async Task AddAsync(UserBook entity, CancellationToken cancel = default)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity));
        await Table.AddAsync(entity);

        if (AutoSaveChanges)
            await DbContext.SaveChangesAsync(cancel).ConfigureAwait(false);        
    }

    public virtual async Task UpdateAsync(UserBook entity, CancellationToken cancel = default)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity));

        DbContext.Entry(entity).State = EntityState.Modified;

        if (AutoSaveChanges)
            await DbContext.SaveChangesAsync(cancel).ConfigureAwait(false);
    }
}