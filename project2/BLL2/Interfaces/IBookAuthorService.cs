using BLL2.DTO.Request;
using BLL2.DTO.Response;

namespace BLL2.Interfaces;

public interface IBookAuthorService
{
    Task AddAsync(BookAuthorRequestDTO authorRequestDto);
    Task UpdateAsync(BookAuthorRequestDTO authorRequestDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<BookAuthorResponseDTO>> GetAllAuthorsByBookIdAsync(int bookId, string? orderBy);
}