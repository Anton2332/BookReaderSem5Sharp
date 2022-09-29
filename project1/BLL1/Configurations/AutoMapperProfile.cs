using AutoMapper;
using BLL1.DTO.Requests;
using BLL1.DTO.Responses;
using DAL1.Model;

namespace BLL1.Configurations;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateCommentsMaps();
    }

    private void CreateCommentsMaps()
    {
        CreateMap<Comments, CommentsResponsDTO>();
        CreateMap<CommentsRequestDTO, Comments>();
    }

}