using AutoMapper;
using BLL2.DTO.Request;
using BLL2.DTO.Response;
using BLL2.Interfaces;
using DAL2.Entitys;
using DAL2.Helpers;
using DAL2.Interfaces;
using DAL2.Models;

namespace BLL2.Services;

public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<int> AddAsync(BookRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<BookRequestDTO, Book>(authorRequestDto);
        var id = await _unitOfWork.BookRepository.AddAsync(item);
        await _unitOfWork.SaveChangesAsync();
        return id;
    }

    public async Task UpdateAsync(BookRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<BookRequestDTO, Book>(authorRequestDto);
        await _unitOfWork.BookRepository.UpdateAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.BookRepository.RemoveAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<BookResponseDTO>> GetAllAsync()
    {
        var results = await _unitOfWork.BookRepository.GetAllAsync();
        return results?.Select(_mapper.Map<Book, BookResponseDTO>);
    }
    
    public async Task<BookResponseDTO> GetByIdAsync(int id)
    {
        var result = await _unitOfWork.BookRepository.GetByIdAsync(id);
        return _mapper.Map<Book, BookResponseDTO>(result);
    }

    public async Task<Page<BookResponseDTO>> GetPagedBooksAsync(QueryStringParameters query)
    {
        var results = await _unitOfWork.BookRepository.GetPagedBooksAsync(query);
        return new Page<BookResponseDTO>(results.Items?.Select(_mapper.Map<Book, BookResponseDTO>),
            results.TotalItemCount);
    }
    
    public async Task<IEnumerable<BookResponseDTO>> GetMostPopularBooksAsync()
    {
        var ids = await _unitOfWork.RatingRepository.GetMostPopularBookIdAsync();
        var results = await _unitOfWork.BookRepository.GetBooksByIdsAsync(ids);
        return results?.Select(_mapper.Map<Book, BookResponseDTO>);
    }
}