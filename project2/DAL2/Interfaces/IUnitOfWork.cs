namespace DAL2.Interfaces;

public interface IUnitOfWork
{
    public ITestRepository TestRepository { get; }
    
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
    public IUserBookRepository UserBookRepository { get; }
    
    public DBContext DbContext { get; }

    Task SaveChangesAsync();
}