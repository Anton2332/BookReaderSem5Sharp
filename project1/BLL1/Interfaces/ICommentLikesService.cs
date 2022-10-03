using BLL1.DTO.Requests;

namespace BLL1.Interfaces;

public interface ICommentLikesService
{

    Task<int> AddLikeAsync(CommentLikesRequestDTO comment);

    Task<int> AddDislikeAsync(CommentLikesRequestDTO comment);

    Task DeleteAsync(int id);

    Task<int> CountLikesByCommentIdAsync(int id);

    Task<int> CountDislikesByCommentIdAsync(int id);
}