using AutoMapper;
using BLL2.DTO.Request;
using BLL2.DTO.Response;
using BLL2.Interfaces;
using DAL2.Entitys;
using DAL2.Interfaces;

namespace BLL2.Services;

public class PageService : IPageService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PageService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddAsync(PageRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<PageRequestDTO, Page>(authorRequestDto);
        await _unitOfWork.PageRepository.AddAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(PageRequestDTO authorRequestDto)
    {
        var item = _mapper.Map<PageRequestDTO, Page>(authorRequestDto);
        await _unitOfWork.PageRepository.UpdateAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.PageRepository.RemoveAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<PageResponseDTO>> GetAllAsync()
    {
        var results = await _unitOfWork.PageRepository.GetAllAsync();
        return results?.Select(_mapper.Map<Page, PageResponseDTO>);
    }
    
    public async Task<PageResponseDTO> GetByIdAsync(int id)
    {
        var result = await _unitOfWork.PageRepository.GetByIdAsync(id);
        return _mapper.Map<Page, PageResponseDTO>(result);
    }
}