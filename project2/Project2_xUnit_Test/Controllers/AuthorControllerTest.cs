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

        // authorServiceMock.Setup(a => a.AddAsync(It.IsAny<AuthorRequestDTO>()))
        //     .Callback((AuthorRequestDTO author) =>
        //     {
        //         var newAuthor = new AuthorResponseDTO()
        //         {
        //             Id = authors.Count() + 1,
        //             Name = author.Name
        //         };
        //         authors.Add(newAuthor);
        //     }).Verifiable();

        authorServiceMock.SetupAllProperties();
        _controller = new AuthorController(authorServiceMock.Object);
    }

    [Fact]
    public async Task AuthorController_GetAuthorById_AuthorResponseDTO()
    {
        // Arrange 
        const int id = 1;
        var expected = _authors[0];
        
        // Act 
        var author = await _controller.GetAuthorById(id);
        
        //Assert
        author.Should().BeOfType<OkObjectResult>();
        author.Should().Subject.Equals(expected);
    }
    
    [Fact]
    public async Task AuthorController_GetAuthorById_NotFound()
    {
        // Arrange 
        const int id = 3;
        
        // Act 
        var author = await _controller.GetAuthorById(id);
        
        //Assert
        author.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task AuthorController_GetAllAuthors_ListAuthors()
    {
        // Arrange
        var expected = _authors;
        
        // Act
        var result = await _controller.GetAllAsync();
        
        // Assert
        result.Should().BeOfType<OkObjectResult>();
        result.Should().Subject.Equals(expected);
    }
    
    // [Fact]
    // public async Task AuthorController_GetAllAuthors_NoContent()
    // {
    //     // Arrange
    //     
    //     // Act
    //     var result = await _controller.GetAllAsync();
    //     
    //     // Assert
    //     result.Should().BeOfType<NoContentResult>();
    // }
}