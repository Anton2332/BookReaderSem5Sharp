using AutoMapper;
using BLL1.DTO.Requests;
using DAL1.Interface;
using DAL1.Model;

namespace BLL1.Services;

public class CommentLikesService
{
    private readonly IUnitOfWork _unitOfWork;
    public readonly IMapper _mapper;

    public CommentLikesService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<int> AddAsync(CommentLikesRequestDTO comment)
    {
        var result = _mapper.Map<CommentLikesRequestDTO, CommentLikes>(comment);
        return await _unitOfWork.CommentLikesRepository.AddAsync(result);
    }

    public async Task UpdateAsync(CommentLikesRequestDTO comment)
    {
        var result = _mapper.Map<CommentLikesRequestDTO, CommentLikes>(comment);
        await _unitOfWork.CommentLikesRepository.ReplaceAsync(result);
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