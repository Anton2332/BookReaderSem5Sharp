using AutoMapper;
using BLL2.DTO.Request;
using BLL2.DTO.Response;
using BLL2.Interfaces;
using DAL2.Entitys;
using DAL2.Interfaces;

namespace BLL2.Services;

public class BookAuthorService : IBookAuthorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookAuthorService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddAsync(BookAuthorRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<BookAuthorRequestDTO, BookAuthor>(authorRequestDto);
        await _unitOfWork.BookAuthorRepository.AddAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(BookAuthorRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<BookAuthorRequestDTO, BookAuthor>(authorRequestDto);
        await _unitOfWork.BookAuthorRepository.UpdateAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.BookAuthorRepository.RemoveAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<BookAuthorResponseDTO>> GetAllAuthorsByBookIdAsync(int bookId, string? orderBy)
    {
        var results = await _unitOfWork.BookAuthorRepository.GetAllAuthorsByBookIdAsync(bookId, orderBy);
        return results?.Select(_mapper.Map<BookAuthor, BookAuthorResponseDTO>);
    }

}