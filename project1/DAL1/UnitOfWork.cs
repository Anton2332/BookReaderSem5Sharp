using System.Data;
using DAL1.Interface;
using DAL1.Repositories;
using Microsoft.Data.SqlClient;
using MySqlConnector;

namespace DAL1;

public class UnitOfWork : IUnitOfWork
{
    private IDbConnection? _connection;
    private IDbTransaction? _transaction;

    private ICommentLikesRepository? _commentLikesRepository;
    private ICommentsRepository? _commentsRepository;

    private bool _disposed;

    public UnitOfWork(MySqlConnection connection, IDbTransaction transaction)
    {
        _connection = connection;
        _transaction = transaction;
    }

    public ICommentLikesRepository CommentLikesRepository
    {
        get
        {
            return _commentLikesRepository ?? (_commentLikesRepository = new CommentLikesRepository(_transaction));     
        }
    }

    public ICommentsRepository CommentsRepository
    {
        get
        {
            return _commentsRepository ?? (_commentsRepository = new CommentsRepository(_transaction));
        }
    }

    public IDbTransaction GetDbTransaction
    {
        get
        {
            return _transaction;
        }
    }

    private void resetRepositories()
    {
        _commentLikesRepository = null;
        _commentsRepository = null;
    }

    public void Commit()
    {
        try
        {
            _transaction.Commit();
        }
        catch
        {
            _transaction.Rollback();
            throw;
        }
        finally
        {
            _transaction.Dispose();
            _transaction = _connection.BeginTransaction();
            resetRepositories();
        }
    }

    public void Dispose()
    {
        dispose(true);
        GC.SuppressFinalize(this);
    }

    private void dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }

                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;
                }
            }

            _disposed = true;
        }
    }

    ~UnitOfWork()
    {
        dispose(false);
    }

}