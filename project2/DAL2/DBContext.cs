using DAL2.Configuration;
using DAL2.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DAL2;

public class DBContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<BookCategory> BookCategories { get; set; }
    public DbSet<BookTag> BookTags { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<Language> Languages {get; set; }
    public DbSet<Page> Pages { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<Tag> Tags { get; set; }


    public DBContext() : base()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new BookAuthorsConfiguration());
        modelBuilder.ApplyConfiguration(new BookCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new BookTagsConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ChapterConfiguration());
        modelBuilder.ApplyConfiguration(new LanguageConfiguration());
        modelBuilder.ApplyConfiguration(new PageConfiguration());
        modelBuilder.ApplyConfiguration(new RatingConfiguration());
        modelBuilder.ApplyConfiguration(new StatusConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        modelBuilder.ApplyConfiguration(new UserBookConfiguration());
    }
}