using AutoMapper;
using BLL2.DTO.Request;
using DAL2.Entitys;
using DAL2.Interfaces;

namespace BLL2.Services;

public class CategoryService
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
}