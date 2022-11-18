﻿using AutoMapper;
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
        CreateBookCommentsMaps();
    }

    private void CreateCommentsMaps()
    {
        CreateMap<Comments, CommentsResponsDTO>();
            // .ForMember("Firstname", p=>p.MapFrom(c => c.User.Firstname))
            // .ForMember("Lastname", p => p.MapFrom(c => c.User.Lastname));
        CreateMap<CommentsRequestDTO, BaseComments>();
    }

    private void CreateCommentLikesService()
    {
        CreateMap<CommentLikesRequestDTO, CommentLikes>();
    }

    private void CreateBookCommentsMaps()
    {
        CreateMap<BookComments, BookCommentsResponseDTO>();
        CreateMap<BookCommentsRequestDTO, BookComments>();
    }

}