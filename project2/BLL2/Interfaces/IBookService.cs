using BLL2.DTO.Request;
using BLL2.DTO.Response;
using DAL2.Helpers;
using DAL2.Models;

namespace BLL2.Interfaces;

public interface IBookService
{
    Task<int> AddAsync(BookRequestDTO authorRequestDto);
    Task UpdateAsync(BookRequestDTO authorRequestDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<BookResponseDTO>> GetAllAsync();
    Task<BookResponseDTO> GetByIdAsync(int id);
    Task<Page<BookResponseDTO>> GetPagedBooksAsync(QueryStringParameters query);
}