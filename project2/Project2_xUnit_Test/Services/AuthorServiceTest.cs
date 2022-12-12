using AutoMapper;
using BLL2.Services;
using DAL2;
using DAL2.Entitys;
using DAL2.Interfaces;
using Moq;

namespace Project2_xUnit_Test.Services;

public class AuthorServiceTest
{
    private readonly AuthorService _service;
    private readonly IMapper _mapper;

    public AuthorServiceTest()
    {
        var mockRepo = new Mock<IAuthorRepository>();
        IList<Author> authors = new List<Author>()
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

        mockRepo.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(authors.ToList());

        // mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
        //     .ReturnsAsync((int i) =>
        //         authors.SingleOrDefault(x => x.Id == i)
        //     );

        // mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Author>()))
        //     .Callback((Author author) =>
        //     {
        //         author.Id = authors.Count() + 1;
        //         authors.Add(author);
        //     }).
        // var n = new AuthorService(, _mapper);

    }
}