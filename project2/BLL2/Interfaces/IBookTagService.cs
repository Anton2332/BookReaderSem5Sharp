using BLL2.DTO.Request;
using BLL2.DTO.Response;

namespace BLL2.Interfaces;

public interface IBookTagService
{
    Task AddAsync(BookTagRequestDTO authorRequestDto);
    Task UpdateAsync(BookTagRequestDTO authorRequestDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<BookTagResponseDTO>> GetAllAsync();
    Task<BookTagResponseDTO> GetByIdAsync(int id);
}