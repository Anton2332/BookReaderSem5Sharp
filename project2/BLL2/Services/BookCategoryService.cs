using AutoMapper;
using BLL2.DTO.Request;
using BLL2.DTO.Response;
using BLL2.Interfaces;
using DAL2.Entitys;
using DAL2.Interfaces;

namespace BLL2.Services;

public class BookCategoryService : IBookCategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddAsync(BookCategoryRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<BookCategoryRequestDTO, BookCategory>(authorRequestDto);
        await _unitOfWork.BookCategoryRepository.AddAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(BookCategoryRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<BookCategoryRequestDTO, BookCategory>(authorRequestDto);
        await _unitOfWork.BookCategoryRepository.UpdateAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.BookCategoryRepository.RemoveAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<BookCategoryResponseDTO>> GetAllAsync()
    {
        var results = await _unitOfWork.BookCategoryRepository.GetAllAsync();
        return results?.Select(_mapper.Map<BookCategory, BookCategoryResponseDTO>);
    }
    
    public async Task<BookCategoryResponseDTO> GetByIdAsync(int id)
    {
        var result = await _unitOfWork.BookCategoryRepository.GetByIdAsync(id);
        return _mapper.Map<BookCategory, BookCategoryResponseDTO>(result);
    }
}