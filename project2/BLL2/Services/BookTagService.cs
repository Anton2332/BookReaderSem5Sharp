using AutoMapper;
using BLL2.DTO.Request;
using BLL2.DTO.Response;
using BLL2.Interfaces;
using DAL2.Entitys;
using DAL2.Interfaces;

namespace BLL2.Services;

public class BookTagService : IBookTagService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookTagService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddAsync(BookTagRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<BookTagRequestDTO, BookTag>(authorRequestDto);
        await _unitOfWork.BookTagRepository.AddAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(BookTagRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<BookTagRequestDTO, BookTag>(authorRequestDto);
        await _unitOfWork.BookTagRepository.UpdateAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.BookTagRepository.RemoveAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<BookTagResponseDTO>> GetAllAsync()
    {
        var results = await _unitOfWork.BookTagRepository.GetAllAsync();
        return results?.Select(_mapper.Map<BookTag, BookTagResponseDTO>);
    }
    
    public async Task<BookTagResponseDTO> GetByIdAsync(int id)
    {
        var result = await _unitOfWork.BookTagRepository.GetByIdAsync(id);
        return _mapper.Map<BookTag, BookTagResponseDTO>(result);
    }

    public async Task<IEnumerable<BookTagResponseDTO>> GetAllTagsByBookIdAsync(int bookId, string? orderBy)
    {
        var results = await _unitOfWork.BookTagRepository.GetAllTagsByBookIdAsync(bookId, orderBy);
        return results?.Select(_mapper.Map<BookTag, BookTagResponseDTO>);
    }
}