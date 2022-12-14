using DAL2;
using DAL2.Entitys;
using DAL2.Interfaces;
using DAL2.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Project2_xUnit_Test.Services;

public class BaseServiceTest
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IEnumerable<Author> _authors = new List<Author>()
    {
        new Author()
        {
            Id = 1,
            Name = "Author 1"
        },
        new Author()
        {
            Id = 2,
            Name = "Author 2"
        }
    };

    public BaseServiceTest()
    {
        
        var authorRepo = new Mock<IAuthorRepository>();
        
        authorRepo.Setup(a => a.GetAllAsync())
            .ReturnsAsync(_authors.ToList());
        
        _unitOfWork = new UnitOfWork(
            new Mock<DBContext>().Object,
            authorRepo.Object,
            new Mock<IBookAuthorRepository>().Object,
            new Mock<IBookCategoryRepository>().Object,
            new Mock<IBookRepository>().Object,
            new Mock<IBookTagRepository>().Object,
            new Mock<ICategoryRepository>().Object,
            new Mock<IChapterRepository>().Object,
            new Mock<ILanguageRepository>().Object,
            new Mock<IPageRepository>().Object,
            new Mock<IRatingRepository>().Object,
            new Mock<IStatusRepository>().Object,
            new Mock<ITagRepository>().Object
        );
    }

}