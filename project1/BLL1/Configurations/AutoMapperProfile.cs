using AutoMapper;
using BLL1.DTO.Requests;
using BLL1.DTO.Responses;
using BLL1.Services;
using DAL1.Model;

namespace BLL1.Configurations;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateCommentsMaps();
        CreateCommentLikesService();
    }

    private void CreateCommentsMaps()
    {
        CreateMap<Comments, CommentsResponsDTO>();
        CreateMap<CommentsRequestDTO, BaseComments>();
    }

    private void CreateCommentLikesService()
    {
        CreateMap<CommentLikesRequestDTO, CommentLikes>();
    }

}