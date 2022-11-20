using BLL1.DTO.Requests;
using BLL1.DTO.Responses;

namespace BLL1.Interfaces;

public interface IBookCommentsService
{
    Task<IEnumerable<BookCommentsResponseDTO>> GetAllAsync();
    Task AddAsync(BookCommentsRequestDTO comment);
    Task UpdateAsync(BookCommentsRequestDTO comment);
    Task DeleteAsync(int id);
}