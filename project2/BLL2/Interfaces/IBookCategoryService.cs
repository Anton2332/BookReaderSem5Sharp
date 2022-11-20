using BLL2.DTO.Request;
using BLL2.DTO.Response;

namespace BLL2.Interfaces;

public interface IBookCategoryService
{
    Task AddAsync(BookCategoryRequestDTO authorRequestDto);
    Task UpdateAsync(BookCategoryRequestDTO authorRequestDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<BookCategoryResponseDTO>> GetAllCategoriesByBookIdAsync(int bookId, string? orderBy);
}