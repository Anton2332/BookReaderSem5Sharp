using BLL1.DTO.Requests;
using BLL1.DTO.Responses;

namespace BLL1.Interfaces;

public interface ICommentsService
{
    Task<IEnumerable<CommentsResponsDTO>> GetAllAsync(int id);
    Task<int> AddAsync(CommentsRequestDTO comment);
    Task UpdateAsync(CommentsRequestDTO comment);
    Task DeleteAsync(int id);
}