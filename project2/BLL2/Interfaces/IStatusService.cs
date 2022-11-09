using BLL2.DTO.Request;
using BLL2.DTO.Response;

namespace BLL2.Interfaces;

public interface IStatusService
{
    Task AddAsync(StatusRequestDTO authorRequestDto);
    Task UpdateAsync(StatusRequestDTO authorRequestDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<StatusResponseDTO>> GetAllAsync();
}