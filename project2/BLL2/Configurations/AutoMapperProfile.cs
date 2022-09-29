using AutoMapper;
using BLL2.DTO;
using DAL2.Entitys;

namespace BLL2.Configurations;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateTestMaps();
    }

    private void CreateTestMaps()
    {
        CreateMap<Test, TestDTO>();
        CreateMap<TestDTO, Test>();
    }
}