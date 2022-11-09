using BLL2.DTO.Request;
using BLL2.DTO.Response;

namespace BLL2.Interfaces;

public interface IChapterService
{
    Task AddAsync(ChapterRequestDTO authorRequestDto);
    Task UpdateAsync(ChapterRequestDTO authorRequestDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<ChapterResponseDTO>> GetAllAsync();
    Task<ChapterResponseDTO> GetByIdAsync(int id);
}