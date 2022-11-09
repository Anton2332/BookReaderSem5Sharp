using BLL2.DTO.Request;
using BLL2.DTO.Response;

namespace BLL2.Interfaces;

public interface IRatingService
{
    Task AddAsync(RatingRequestDTO authorRequestDto);
    Task UpdateAsync(RatingRequestDTO authorRequestDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<RatingResponseDTO>> GetAllAsync();
    Task<RatingResponseDTO> GetByIdAsync(int id);
}