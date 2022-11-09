using AutoMapper;
using BLL2.DTO.Request;
using BLL2.DTO.Response;
using BLL2.Interfaces;
using DAL2.Entitys;
using DAL2.Interfaces;

namespace BLL2.Services;

public class RatingService : IRatingService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RatingService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddAsync(RatingRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<RatingRequestDTO, Rating>(authorRequestDto);
        await _unitOfWork.RatingRepository.AddAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(RatingRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<RatingRequestDTO, Rating>(authorRequestDto);
        await _unitOfWork.RatingRepository.UpdateAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.RatingRepository.RemoveAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<RatingResponseDTO>> GetAllAsync()
    {
        var results = await _unitOfWork.RatingRepository.GetAllAsync();
        return results?.Select(_mapper.Map<Rating, RatingResponseDTO>);
    }
    
    public async Task<RatingResponseDTO> GetByIdAsync(int id)
    {
        var result = await _unitOfWork.RatingRepository.GetByIdAsync(id);
        return _mapper.Map<Rating, RatingResponseDTO>(result);
    }
}