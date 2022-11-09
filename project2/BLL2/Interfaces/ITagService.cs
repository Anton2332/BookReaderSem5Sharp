using BLL2.DTO.Request;
using BLL2.DTO.Response;

namespace BLL2.Interfaces;

public interface ITagService
{
    Task AddAsync(TagRequestDTO authorRequestDto);
    Task UpdateAsync(TagRequestDTO authorRequestDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<TagResponseDTO>> GetAllAsync();
    Task<TagResponseDTO> GetByIdAsync(int id);
}