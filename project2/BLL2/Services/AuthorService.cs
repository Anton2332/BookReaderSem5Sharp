using AutoMapper;
using BLL2.DTO.Request;
using BLL2.DTO.Response;
using BLL2.Interfaces;
using DAL2.Entitys;
using DAL2.Interfaces;

namespace BLL2.Services;

public class AuthorService : IAuthorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddAsync(AuthorRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<AuthorRequestDTO, Author>(authorRequestDto);
        await _unitOfWork.AuthorRepository.AddAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(AuthorRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<AuthorRequestDTO, Author>(authorRequestDto);
        await _unitOfWork.AuthorRepository.UpdateAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.AuthorRepository.RemoveAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<AuthorResponseDTO>> GetAllAsync()
    {
        var results = await _unitOfWork.AuthorRepository.GetAllAsync();
        return results?.Select(_mapper.Map<Author, AuthorResponseDTO>);
    }

    public async Task<AuthorResponseDTO> GetByIdAsync(int id)
    {
        var result = await _unitOfWork.AuthorRepository.GetByIdAsync(id);
        return _mapper.Map<Author, AuthorResponseDTO>(result);
    }

    public async Task<IEnumerable<AuthorResponseDTO>> GetAllWithoutIdsAsync(int[] ids)
    {
        var results = await _unitOfWork.AuthorRepository.GetAllAsync();
        
        var allIds = results.Select(x => x.Id).ToList();

        var trueIds = allIds.Except(ids).ToList();
        
        
        var query = results.Where(x => trueIds.Contains(x.Id)).ToList();
        
        return query?.Select(_mapper.Map<Author, AuthorResponseDTO>);
    }
}