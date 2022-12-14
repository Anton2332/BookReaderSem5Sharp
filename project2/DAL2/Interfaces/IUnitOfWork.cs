namespace DAL2.Interfaces;

public interface IUnitOfWork
{
    
    public IAuthorRepository AuthorRepository { get; }
    public IBookAuthorRepository BookAuthorRepository { get; }
    
    public IBookCategoryRepository BookCategoryRepository { get; }
    public IBookRepository BookRepository { get; }
    public IBookTagRepository BookTagRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IChapterRepository ChapterRepository { get; }
    public ILanguageRepository LanguageRepository { get; }
    public IPageRepository PageRepository { get; }
    public IRatingRepository RatingRepository { get; }
    public IStatusRepository StatusRepository { get; }
    public ITagRepository TagRepository { get; }
    
    public DBContext DbContext { get; }

    Task SaveChangesAsync();
}