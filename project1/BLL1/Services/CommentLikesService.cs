using AutoMapper;
using BLL1.DTO.Requests;
using BLL1.Interfaces;
using DAL1.Interface;
using DAL1.Model;

namespace BLL1.Services;

public class CommentLikesService : ICommentLikesService
{
    private readonly IUnitOfWork _unitOfWork;
    public readonly IMapper _mapper;

    public CommentLikesService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<int> AddLikeAsync(CommentLikesRequestDTO comment)
    {
        var result = _mapper.Map<CommentLikesRequestDTO, CommentLikes>(comment);

        result.LikeId = await _unitOfWork.LikeRepository.GetIdByBodyAsync("like");
        
        return await _unitOfWork.CommentLikesRepository.AddAsync(result);
    }
    
    public async Task<int> AddDislikeAsync(CommentLikesRequestDTO comment)
    {
        var result = _mapper.Map<CommentLikesRequestDTO, CommentLikes>(comment);

        result.LikeId = await _unitOfWork.LikeRepository.GetIdByBodyAsync("dislike");
        
        return await _unitOfWork.CommentLikesRepository.AddAsync(result);
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.CommentLikesRepository.DeleteAsync(id);
    }

    public async Task<int> CountLikesByCommentIdAsync(int id)
    {
        return await _unitOfWork.CommentLikesRepository.GetCountLikesByCommentIdAsync(id);
    }
    
    public async Task<int> CountDislikesByCommentIdAsync(int id)
    {
        return await _unitOfWork.CommentLikesRepository.GetCountDislikesByCommentIdAsync(id);
    }
}