using BLL1.DTO.Requests;
using BLL1.DTO.Responses;

namespace BLL1.Interfaces;

public interface ICommentsService
{
    Task<IEnumerable<CommentsResponsDTO>> GetRepliesByCommentIdAsync(int id);
    Task<IEnumerable<CommentsResponsDTO>> GetAllByBookIdAsync(int id);

    Task<IEnumerable<CommentsResponsDTO>> GetCommentsByBookIdAsync(int id);
    Task AddAsync(CommentsRequestDTO comment);
    Task UpdateAsync(CommentsRequestDTO comment);
    Task DeleteAsync(int id);
}