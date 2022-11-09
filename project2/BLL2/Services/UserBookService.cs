using AutoMapper;
using BLL2.DTO.Request;
using BLL2.DTO.Response;
using DAL2.Entitys;
using DAL2.Interfaces;

namespace BLL2.Services;

public class UserBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserBookService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddAsync(UserBookRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<UserBookRequestDTO, UserBook>(authorRequestDto);
        await _unitOfWork.UserBookRepository.AddAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(UserBookRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<UserBookRequestDTO, UserBook>(authorRequestDto);
        await _unitOfWork.UserBookRepository.UpdateAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        await _unitOfWork.UserBookRepository.RemoveAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserBookResponseDTO>> GetAllAsync()
    {
        var results = await _unitOfWork.UserBookRepository.GetAllAsync();
        return results?.Select(_mapper.Map<UserBook, UserBookResponseDTO>);
    }
}