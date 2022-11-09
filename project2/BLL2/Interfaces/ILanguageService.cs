using BLL2.DTO.Request;
using BLL2.DTO.Response;

namespace BLL2.Interfaces;

public interface ILanguageService
{
    Task AddAsync(LanguageRequestDTO authorRequestDto);
    Task UpdateAsync(LanguageRequestDTO authorRequestDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<LanguageResponseDTO>> GetAllAsync();
    Task<LanguageResponseDTO> GetByIdAsync(int id);
}