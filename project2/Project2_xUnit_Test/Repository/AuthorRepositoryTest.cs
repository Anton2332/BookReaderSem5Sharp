using DAL2;
using DAL2.Repository;

namespace Project2_xUnit_Test.Repository;

public class AuthorRepositoryTest : BaseRepositoryTest
{
    private readonly AuthorRepository _authorRepository;

    public AuthorRepositoryTest() : base()
    {
       var context = new DBContext(_dbOptions);
       _authorRepository = new AuthorRepository(context);
    }
    
    [Fact]
    public async Task AuthorRepository_GetAuthorById_Author()
    {
        // Arrange 
        const int id = 1;
        var expected = GetFakeAuthors()[0];
        
        // Act 
        var author = await _authorRepository.GetByIdAsync(id);
        
        //Assert
        Assert.Equal(expected.Id,author.Id);
    }
    
    [Fact]
    public async Task AuthorRepository_GetAuthorById_NotFound()
    {
        // Arrange 
        const int id = 3;
        
        // Act 
        var author = await _authorRepository.GetByIdAsync(id);
        
        //Assert
        Assert.Null(author);
    }
    
    [Fact]
    public async Task AuthorRepository_GetAllAuthors_Author()
    {
        // Arrange 
        var expected = GetFakeAuthors();
        
        // Act 
        var author = await _authorRepository.GetAllAsync();
        
        //Assert
        Assert.NotEmpty(author);
    }
}