using AutoMapper;
using BLL2.DTO.Request;
using BLL2.DTO.Response;
using BLL2.Interfaces;
using DAL2.Entitys;
using DAL2.Interfaces;

namespace BLL2.Services;

public class LanguageService : ILanguageService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LanguageService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddAsync(LanguageRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<LanguageRequestDTO, Language>(authorRequestDto);
        await _unitOfWork.LanguageRepository.AddAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(LanguageRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<LanguageRequestDTO, Language>(authorRequestDto);
        await _unitOfWork.LanguageRepository.UpdateAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.LanguageRepository.RemoveAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<LanguageResponseDTO>> GetAllAsync()
    {
        var results = await _unitOfWork.LanguageRepository.GetAllAsync();
        return results?.Select(_mapper.Map<Language, LanguageResponseDTO>);
    }
    
    public async Task<LanguageResponseDTO> GetByIdAsync(int id)
    {
        var result = await _unitOfWork.LanguageRepository.GetByIdAsync(id);
        return _mapper.Map<Language, LanguageResponseDTO>(result);
    }
}