namespace DAL1.Interface;

public interface IUnitOfWork : IDisposable
{
    
    public IBookCommentsRepository BookCommentsRepository { get; }
    public ICommentLikesRepository CommentLikesRepository { get; }
    public ICommentsRepository CommentsRepository { get; }
    public ILikeRepository LikeRepository { get; }
    public IUserCommentsRepository UserCommentsRepository { get; }
    void Commit();

}