using DAL2.Interfaces;

namespace DAL2;

public class UnitOfWork : IUnitOfWork
{
    public readonly DBContext _dbContext;
    
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

    public UnitOfWork(
        DBContext dbContext, 
        ITestRepository testRepository, 
        IAuthorRepository authorRepository,
        IBookAuthorRepository bookAuthorRepository
        )
    {
        _dbContext = dbContext;
        TestRepository = testRepository;
        AuthorRepository = authorRepository;
        BookAuthorRepository = bookAuthorRepository;
    }
    
    public DBContext DbContext
    {
        get { return _dbContext; }
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
    
}