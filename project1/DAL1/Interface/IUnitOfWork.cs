namespace DAL1.Interface;

public interface IUnitOfWork : IDisposable
{
    public ICommentLikesRepository CommentLikesRepository { get; }
    public ICommentsRepository CommentsRepository { get; }
    void Commit();

}