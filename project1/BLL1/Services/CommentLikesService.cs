using AutoMapper;
using BLL1.DTO.Requests;
using BLL1.Interfaces;
using DAL1.Interface;
using DAL1.Model;

namespace BLL1.Services;

public class CommentsLikesService : ICommentsLikesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CommentsLikesService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<int?> AddLikeAsync(CommentLikesRequestDTO comment)
    {
        var result = _mapper.Map<CommentLikesRequestDTO, CommentLikes>(comment);

        result.LikeId = await _unitOfWork.LikeRepository.GetIdByBodyAsync("like");

        var idDislike = await _unitOfWork.CommentLikesRepository.GetIdByUserIdAndCommentIdAndDislike(comment.UserId, comment.CommentId);

        if (idDislike != null)
        {
            await _unitOfWork.CommentLikesRepository.DeleteAsync(idDislike.Value);
            _unitOfWork.Commit();
        }

        var idLike =
            await _unitOfWork.CommentLikesRepository.GetIdByUserIdAndCommentIdAndLike(comment.UserId,
                comment.CommentId);

        if (idLike.HasValue)
        {
            await _unitOfWork.CommentLikesRepository.DeleteAsync(idLike.Value);
            _unitOfWork.Commit();
            return null;
        }
        else
        {
            var id = await _unitOfWork.CommentLikesRepository.AddLikeAsync(result);
            _unitOfWork.Commit();
            return id;
        }
    }
    
    public async Task<int?> AddDislikeAsync(CommentLikesRequestDTO comment)
    {
        var result = _mapper.Map<CommentLikesRequestDTO, CommentLikes>(comment);
        
        var idLike =
            await _unitOfWork.CommentLikesRepository.GetIdByUserIdAndCommentIdAndLike(comment.UserId,
                comment.CommentId);
        
        if (idLike != null)
        {
            await _unitOfWork.CommentLikesRepository.DeleteAsync(idLike.Value);
            _unitOfWork.Commit();
        }
        
        result.LikeId = await _unitOfWork.LikeRepository.GetIdByBodyAsync("dislike");
        
        var idDislike = await _unitOfWork.CommentLikesRepository.GetIdByUserIdAndCommentIdAndDislike(comment.UserId, comment.CommentId);
        
        if (idDislike.HasValue)
        {
            await _unitOfWork.CommentLikesRepository.DeleteAsync(idDislike.Value);
            _unitOfWork.Commit();
            return null;
        }
        else
        {
            var id = await _unitOfWork.CommentLikesRepository.AddLikeAsync(result);
            _unitOfWork.Commit();
            return id;
        }
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