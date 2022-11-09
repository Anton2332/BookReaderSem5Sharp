using AutoMapper;
using BLL2.DTO.Request;
using BLL2.DTO.Response;
using BLL2.Interfaces;
using DAL2.Entitys;
using DAL2.Interfaces;

namespace BLL2.Services;

public class StatusService : IStatusService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StatusService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddAsync(StatusRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<StatusRequestDTO, Status>(authorRequestDto);
        await _unitOfWork.StatusRepository.AddAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(StatusRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<StatusRequestDTO, Status>(authorRequestDto);
        await _unitOfWork.StatusRepository.UpdateAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.StatusRepository.RemoveAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<StatusResponseDTO>> GetAllAsync()
    {
        var results = await _unitOfWork.StatusRepository.GetAllAsync();
        return results?.Select(_mapper.Map<Status, StatusResponseDTO>);
    }
}