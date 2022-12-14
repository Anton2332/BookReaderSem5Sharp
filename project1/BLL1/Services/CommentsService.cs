using AutoMapper;
using BLL1.DTO.Requests;
using BLL1.DTO.Responses;
using BLL1.Interfaces;
using DAL1.Interface;
using DAL1.Model;

namespace BLL1.Services;

public class CommentsService : ICommentsService
{
    private readonly IUnitOfWork _unitOfWork;
    public readonly IMapper _mapper;

    public CommentsService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CommentsResponsDTO>> GetRepliesByCommentIdAsync(int id)
    {
        var result = await _unitOfWork.CommentsRepository.GetRepliesByCommentsIdAsync(id);
        return result?.Select(_mapper.Map<Comments, CommentsResponsDTO>);
    }

    public async Task<IEnumerable<CommentsResponsDTO>> GetAllByBookIdAsync(int id)
    {
        var result = await _unitOfWork.CommentsRepository.GetAllByBookIdAsync(id);
        return result?.Select(_mapper.Map<Comments, CommentsResponsDTO>);
    }
    
    public async Task<IEnumerable<CommentsResponsDTO>> GetCommentsByBookIdAsync(int id)
    {
        var result = await _unitOfWork.CommentsRepository.GetCommentsByBookIdAsync(id);
        return result?.Select(_mapper.Map<Comments, CommentsResponsDTO>);
    }
    
    public async Task AddAsync(CommentsRequestDTO comment)
    {
        var result = _mapper.Map<CommentsRequestDTO, BaseComments>(comment);
        await _unitOfWork.CommentsRepository.AddAsync(result);
        _unitOfWork.Commit();
    }

    public async Task UpdateAsync(CommentsRequestDTO comment)
    {
        var result = _mapper.Map<CommentsRequestDTO, Comments>(comment);
        await _unitOfWork.CommentsRepository.ReplaceAsync(result);
        _unitOfWork.Commit();
    }
    
    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.CommentsRepository.DeleteAsync(id);
        _unitOfWork.Commit();
    }

}