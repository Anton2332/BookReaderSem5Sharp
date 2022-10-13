using BLL1.DTO.Requests;

namespace BLL1.Interfaces;

public interface ICommentsLikesService
{

    Task<int?> AddLikeAsync(CommentLikesRequestDTO comment);

    Task<int?> AddDislikeAsync(CommentLikesRequestDTO comment);

    Task<int> CountLikesByCommentIdAsync(int id);

    Task<int> CountDislikesByCommentIdAsync(int id);
}