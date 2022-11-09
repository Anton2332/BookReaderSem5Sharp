using AutoMapper;
using BLL2.DTO.Request;
using BLL2.DTO.Response;
using BLL2.Interfaces;
using DAL2.Entitys;
using DAL2.Interfaces;

namespace BLL2.Services;

public class TagService : ITagService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TagService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddAsync(TagRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<TagRequestDTO, Tag>(authorRequestDto);
        await _unitOfWork.TagRepository.AddAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(TagRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<TagRequestDTO, Tag>(authorRequestDto);
        await _unitOfWork.TagRepository.UpdateAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.TagRepository.RemoveAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<TagResponseDTO>> GetAllAsync()
    {
        var results = await _unitOfWork.TagRepository.GetAllAsync();
        return results?.Select(_mapper.Map<Tag, TagResponseDTO>);
    }
}