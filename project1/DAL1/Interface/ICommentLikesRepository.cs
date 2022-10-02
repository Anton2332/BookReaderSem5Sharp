using DAL1.Model;

namespace DAL1.Interface;

public interface ICommentLikesRepository : IGenericRepository<CommentLikes>
{

    Task<int> GetCountLikesByCommentIdAsync(int id);

    Task<int> GetCountDislikesByCommentIdAsync(int id);

}