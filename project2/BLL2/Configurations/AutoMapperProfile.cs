using AutoMapper;
using BLL2.DTO;
using BLL2.DTO.Request;
using BLL2.DTO.Response;
using DAL2.Entitys;

namespace BLL2.Configurations;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateTestMaps();
        CreateAuthorMaps();
        CreateCategoryMaps();
    }

    private void CreateTestMaps()
    {
        CreateMap<Test, TestDTO>();
        CreateMap<TestDTO, Test>();
    }

    private void CreateAuthorMaps()
    {
        CreateMap<AuthorRequestDTO, Author>();
        CreateMap<Author, AuthorResponseDTO>();
    }

    private void CreateCategoryMaps()
    {
        CreateMap<CategoryRequestDTO, Category>();
        CreateMap<Category, CategoryResponseDTO>();
    }
}