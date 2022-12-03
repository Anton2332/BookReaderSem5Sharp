using AutoMapper;
using BLL_USER.DTO.Request;
using BLL_USER.DTO.Response;
using DAL_USER.Entities;

namespace BLL_USER.Configurations;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateUserRegisterMaps();
        
    }

    private void CreateUserRegisterMaps()
    {
        CreateMap<RegisterRequestDTO, ApplicationUser>();
    }

    private void CreateUserLoginMaps()
    {
        CreateMap<LoginRequestDTO, ApplicationUser>();
        CreateMap<ApplicationUser, UserResponseDTO>();
    }
}