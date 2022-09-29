

using AutoMapper;
using BLL2.DTO;
using BLL2.Interfaces;
using DAL2.Entitys;
using DAL2.Interfaces;

namespace BLL2.Services;

public class TestService : ITestService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TestService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddAsync(TestDTO test)
    {
        var result = _mapper.Map<TestDTO, Test>(test);
        await _unitOfWork.TestRepository.AddAsync(result);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(TestDTO test)
    {
        var result = _mapper.Map<TestDTO, Test>(test);
        await _unitOfWork.TestRepository.UpdateAsync(result);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.TestRepository.RemoveAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<TestDTO>> GetAllAsync()
    {
        var item = await _unitOfWork.TestRepository.GetAllAsync();
        return item?.Select(_mapper.Map<Test, TestDTO>);
    }
}