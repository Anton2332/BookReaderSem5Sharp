using BLL2.DTO.Request;
using BLL2.DTO.Response;

namespace BLL2.Interfaces;

public interface IPageService
{
    Task AddAsync(PageRequestDTO authorRequestDto);
    Task UpdateAsync(PageRequestDTO authorRequestDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<PageResponseDTO>> GetAllAsync();
}