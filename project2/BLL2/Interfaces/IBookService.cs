using BLL2.DTO.Request;
using BLL2.DTO.Response;

namespace BLL2.Interfaces;

public interface IBookService
{
    Task AddAsync(BookRequestDTO authorRequestDto);
    Task UpdateAsync(BookRequestDTO authorRequestDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<BookResponseDTO>> GetAllAsync();
    Task<BookResponseDTO> GetByIdAsync(int id);
}