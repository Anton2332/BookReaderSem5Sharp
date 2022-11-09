using AutoMapper;
using BLL2.DTO.Request;
using BLL2.DTO.Response;
using DAL2.Entitys;
using DAL2.Interfaces;

namespace BLL2.Services;

public class ChapterService
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
}