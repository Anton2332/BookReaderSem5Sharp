using BLL2.DTO.Request;
using BLL2.DTO.Response;

namespace BLL2.Interfaces;

public interface IAuthorService
{
    Task AddAsync(AuthorRequestDTO authorRequestDto);
    Task UpdateAsync(AuthorRequestDTO authorRequestDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<AuthorResponseDTO>> GetAllAsync();
    Task<AuthorResponseDTO> GetByIdAsync(int id);
    Task<IEnumerable<AuthorResponseDTO>> GetAllWithoutIdsAsync(int[] ids);
}