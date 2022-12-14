using AutoMapper;
using BLL2.DTO.Response;
using BLL2.Services;
using DAL2.Entitys;

namespace Project2_xUnit_Test.Services;

public class AuthorServiceTest : BaseServiceTest
{
    private readonly AuthorService _service;
    private readonly IMapper _mapper;

    public AuthorServiceTest() : base()
    {
        _mapper = new Mapper(new MapperConfiguration(cfg =>
            cfg.CreateMap<Author, AuthorResponseDTO>()));
        _service = new AuthorService(_unitOfWork, _mapper);

    }

    [Fact]
    public async void AuthorService_GetAllWithoutIdsAsync_IEnumerableResult()
    {
        //Arrange
        int[] ids = { 1 };
        int expected = 1;
        
        //Act
        var result = await _service.GetAllWithoutIdsAsync(ids);
        
        //Assert
        Assert.Equal(expected, result.Count());
    }
    
    [Fact]
    public async void AuthorService_GetAllWithoutIdsAsync_Match()
    {
        //Arrange
        int[] ids = { 1 };
        int expected = 1;
        
        //Act
        var result = await _service.GetAllWithoutIdsAsync(ids);
        
        //Assert
        Assert.Equal("Author 2", result.ToList()[0].Name);
    }
    
    [Fact]
    public async void AuthorService_GetAllWithoutIdsAsync_IEnumerableEmpty()
    {
        //Arrange
        int[] ids = { 1, 2 };
        
        //Act
        var result = await _service.GetAllWithoutIdsAsync(ids);
        
        //Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public async void AuthorService_GetAllWithoutIdsAsync_IEnumerableResults()
    {
        //Arrange
        int[] ids = { };
        int expected = 2;
        
        //Act
        var result = await _service.GetAllWithoutIdsAsync(ids);
        
        //Assert
        Assert.Equal(expected, result.Count());
    }
}