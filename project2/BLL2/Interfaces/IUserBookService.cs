using BLL2.DTO.Request;
using BLL2.DTO.Response;

namespace BLL2.Interfaces;

public interface IUserBookService
{
    Task AddAsync(UserBookRequestDTO authorRequestDto);
    Task UpdateAsync(UserBookRequestDTO authorRequestDto);
    Task DeleteAsync(string id);
    Task<IEnumerable<UserBookResponseDTO>> GetAllAsync();
}