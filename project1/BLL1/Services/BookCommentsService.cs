using AutoMapper;
using BLL1.DTO.Requests;
using BLL1.DTO.Responses;
using BLL1.Interfaces;
using DAL1.Interface;
using DAL1.Model;

namespace BLL1.Services;

public class BookCommentsService : IBookCommentsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookCommentsService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<BookCommentsResponseDTO>> GetAllAsync()
    {
        var result = await _unitOfWork.BookCommentsRepository.GetAllAsync();
        return result?.Select(_mapper.Map<BookComments, BookCommentsResponseDTO>);
    }
    
    public async Task AddAsync(BookCommentsRequestDTO comment)
    {
        var result = _mapper.Map<BookCommentsRequestDTO, BookComments>(comment);
        await _unitOfWork.BookCommentsRepository.AddAsync(result);
        _unitOfWork.Commit();
    }

    public async Task UpdateAsync(BookCommentsRequestDTO comment)
    {
        var result = _mapper.Map<BookCommentsRequestDTO, BookComments>(comment);
        await _unitOfWork.BookCommentsRepository.ReplaceAsync(result);
        _unitOfWork.Commit();
    }
    
    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.BookCommentsRepository.DeleteAsync(id);
        _unitOfWork.Commit();
    }
}