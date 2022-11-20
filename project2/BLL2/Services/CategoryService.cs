using AutoMapper;
using BLL2.DTO.Request;
using BLL2.DTO.Response;
using BLL2.Interfaces;
using DAL2.Entitys;
using DAL2.Interfaces;

namespace BLL2.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddAsync(CategoryRequestDTO сategoryRequestDto)
    {
        var item = _mapper.Map<CategoryRequestDTO, Category>(сategoryRequestDto);
        await _unitOfWork.CategoryRepository.AddAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(CategoryRequestDTO categoryRequestDto)
    {
        var item = _mapper.Map<CategoryRequestDTO, Category>(categoryRequestDto);
        await _unitOfWork.CategoryRepository.UpdateAsync(item);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.CategoryRepository.RemoveAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<CategoryResponseDTO>> GetAllAsync()
    {
        var results = await _unitOfWork.CategoryRepository.GetAllAsync();
        return results?.Select(_mapper.Map<Category, CategoryResponseDTO>);
    }
    
    public async Task<CategoryResponseDTO> GetByIdAsync(int id)
    {
        var result = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
        return _mapper.Map<Category, CategoryResponseDTO>(result);
    }

    public async Task<IEnumerable<CategoryResponseDTO>> GetAllWithoutIdsAsync(int[] ids, string? orderBy = null)
    {
        var results = await _unitOfWork.CategoryRepository.GetAllWithoutIdsAsync(ids);
        return results?.Select(_mapper.Map<Category, CategoryResponseDTO>);
    }
}