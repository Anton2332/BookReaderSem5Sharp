using DAL2.Interfaces;

namespace DAL2;

public class UnitOfWork : IUnitOfWork
{
    public readonly DBContext _dbContext;
    
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
        IAuthorRepository authorRepository,
        IBookAuthorRepository bookAuthorRepository, 
        IBookCategoryRepository bookCategoryRepository, 
        IBookRepository bookRepository, 
        IBookTagRepository bookTagRepository, 
        ICategoryRepository categoryRepository, 
        IChapterRepository chapterRepository, 
        ILanguageRepository languageRepository, 
        IPageRepository pageRepository, 
        IRatingRepository ratingRepository, 
        IStatusRepository statusRepository, 
        ITagRepository tagRepository, 
        IUserBookRepository userBookRepository)
    {
        _dbContext = dbContext;
        AuthorRepository = authorRepository;
        BookAuthorRepository = bookAuthorRepository;
        BookCategoryRepository = bookCategoryRepository;
        BookRepository = bookRepository;
        BookTagRepository = bookTagRepository;
        CategoryRepository = categoryRepository;
        ChapterRepository = chapterRepository;
        LanguageRepository = languageRepository;
        PageRepository = pageRepository;
        RatingRepository = ratingRepository;
        StatusRepository = statusRepository;
        TagRepository = tagRepository;
        UserBookRepository = userBookRepository;
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