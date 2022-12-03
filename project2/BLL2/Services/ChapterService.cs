using AutoMapper;
using BLL2.DTO.Request;
using BLL2.DTO.Response;
using BLL2.Interfaces;
using DAL2.Entitys;
using DAL2.Interfaces;

namespace BLL2.Services;

public class ChapterService : IChapterService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ChapterService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddAsync(ChapterRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<ChapterRequestDTO, Chapter>(authorRequestDto);
        await _unitOfWork.ChapterRepository.AddAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(ChapterRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<ChapterRequestDTO, Chapter>(authorRequestDto);
        await _unitOfWork.ChapterRepository.UpdateAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.ChapterRepository.RemoveAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<ChapterResponseDTO>> GetAllAsync()
    {
        var results = await _unitOfWork.ChapterRepository.GetAllAsync();
        return results?.Select(_mapper.Map<Chapter, ChapterResponseDTO>);
    }
    
    public async Task<ChapterResponseDTO> GetByIdAsync(int id)
    {
        var result = await _unitOfWork.ChapterRepository.GetByIdAsync(id);
        return _mapper.Map<Chapter, ChapterResponseDTO>(result);
    }
    
    public async Task<IEnumerable<ChapterResponseDTO>> GetAllByBookIdAsync(int bookId)
    {
        var results = await _unitOfWork.ChapterRepository.GetAllChaptersByBookIdAsync(bookId);
        return results?.Select(_mapper.Map<Chapter, ChapterResponseDTO>);
    }

    public async Task<int> GetCountChapterByCountIdAsync(int bookId)
    {
        var result = await _unitOfWork.ChapterRepository.GetCountOfChaptersByBookIdAsync(bookId);
        return result;
    }
    
    public async Task<IEnumerable<ChapterResponseDTO>> GetLastChapterAsync()
    {
        var results = await _unitOfWork.ChapterRepository.GetLastChaptersAsync();
        return results?.Select(_mapper.Map<Chapter, ChapterResponseDTO>);
    }
}