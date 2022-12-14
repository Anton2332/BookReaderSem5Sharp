using API2.Controllers;
using BLL2.DTO.Request;
using BLL2.DTO.Response;
using BLL2.Interfaces;
using DAL2.Repository;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Project2_xUnit_Test.Controllers;

public class AuthorControllerTest
{
    private AuthorController _controller;
    private IList<AuthorResponseDTO> _authors;

    public AuthorControllerTest()
    {
        _authors = new List<AuthorResponseDTO>()
        {
            new AuthorResponseDTO()
            {
                Id = 1,
                Name = "Author 1"
            },
            new AuthorResponseDTO()
            {
                Id = 2,
                Name = "Author 2"
            }
        };

        var authorServiceMock = new Mock<IAuthorService>();
        
        authorServiceMock.Setup(a => a.GetAllAsync())
            .ReturnsAsync(_authors.ToList());

        authorServiceMock.Setup(a => a.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((int i) =>
                _authors.SingleOrDefault(x => x.Id == i));
        
        authorServiceMock.Setup(repo => repo.AddAsync(It.IsAny<AuthorRequestDTO>()))
            .Callback((AuthorRequestDTO author) =>
            {
                AuthorResponseDTO newAuthor = new AuthorResponseDTO()
                {
                    Id = _authors.Count + 1,
                    Name = author.Name
                };
                _authors.Add(newAuthor);
            });

        // authorServiceMock.Setup(a => a.AddAsync(It.IsAny<AuthorRequestDTO>()))
        //     .Callback((AuthorRequestDTO author) =>
        //     {
        //         var newAuthor = new AuthorResponseDTO()
        //         {
        //             Id = _authors.Count() + 1,
        //             Name = author.Name
        //         };
        //         _authors.Add(newAuthor);
        //     }).Verifiable();
        
        // authorServiceMock.Setup(a => a.GetAllWithoutIdsAsync((It.IsAny<int>())))
        //     .ReturnsAsync((int i) =>
        //         _authors.SingleOrDefault(x => x.Id == i));

        // authorServiceMock.Setup(serv => serv.DeleteAsync(It.IsAny<int>()))
        //     .Callback((int id) =>
        //     {
        //         _authors.RemoveAt(id - 1);
        //     }).Verifiable();

        authorServiceMock.SetupAllProperties();
        _controller = new AuthorController(authorServiceMock.Object);
    }

    [Fact]
    public async Task AuthorController_GetAuthorById_OkResult()
    {
        // Arrange 
        const int id = 1;
        var expected = _authors[0];
        
        // Act 
        var author = await _controller.GetAuthorById(id);
        
        //Assert
        Assert.IsType<OkObjectResult>(author);
    }
    
    [Fact]
    public async Task AuthorController_GetAuthorById_NotFoundResult()
    {
        // Arrange 
        const int id = 3;
        
        // Act 
        var author = await _controller.GetAuthorById(id);
        
        //Assert
        Assert.IsType<NotFoundResult>(author);
    }
    
    [Fact]
    public async Task AuthorController_GetAuthorById_MatchResult()
    {
        // Arrange 
        const int id = 1;
        
        // Act 
        var iauthor = await _controller.GetAuthorById(id);
        
        //Assert
        Assert.IsType<OkObjectResult>(iauthor);
        var okResult = iauthor.Should().BeOfType<OkObjectResult>().Subject;
        var author = okResult.Value.Should().BeAssignableTo<AuthorResponseDTO>().Subject;
        
        Assert.Equal("Author 1", author.Name);
    }
    
    [Fact]
    public async Task AuthorController_GetAllAuthors_OkResult()
    {
        // Arrange
        
        // Act
        var result = await _controller.GetAllAsync();
        
        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
    
    [Fact]
    public async Task AuthorController_GetAllAuthors_MatchResult()
    {
        // Arrange
        
        // Act
        var result = await _controller.GetAllAsync();
        
        // Assert
        Assert.IsType<OkObjectResult>(result);
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        var author = okResult.Value.Should().BeAssignableTo<List<AuthorResponseDTO>>().Subject;
        
        Assert.Equal("Author 1", author[0].Name);
        
        Assert.Equal("Author 2", author[1].Name);
    }

    [Fact]
    public async void AuthorController_AddAuthor_OkResult()
    {
        // Arrange
        var author = new AuthorRequestDTO()
        {
            Name = "Author 3"
        };
        
        //Act
        var data = await _controller.AddAuthorAsync(author);
        
        //Assert
        Assert.IsType<OkObjectResult>(data);
    }
    

}