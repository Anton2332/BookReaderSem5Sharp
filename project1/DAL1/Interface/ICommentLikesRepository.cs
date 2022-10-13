using DAL1.Model;

namespace DAL1.Interface;

public interface ICommentLikesRepository : IGenericRepository<CommentLikes>
{

    Task<int> AddLikeAsync(CommentLikes commentLikes);
    Task<int> GetCountLikesByCommentIdAsync(int id);

    Task<int> GetCountDislikesByCommentIdAsync(int id);
    Task<int?> GetIdByUserIdAndCommentIdAndLike(string userId, int commentId);

    Task<int?> GetIdByUserIdAndCommentIdAndDislike(string userId, int commentId);

}