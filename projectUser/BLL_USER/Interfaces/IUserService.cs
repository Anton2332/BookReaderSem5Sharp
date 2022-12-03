using BLL_USER.DTO.Request;
using BLL_USER.DTO.Response;
using DAL_USER.Entities;

namespace BLL_USER.Interfaces;

public interface IUserService
{
    Task<string> RegisterAsync(RegisterRequestDTO dto);
    Task<UserResponseDTO> GetTokenAsync(LoginRequestDTO model);
    Task<string> AddRoleAsync(AddRoleRequestDTO model);
    Task<UserResponseDTO> RefreshTokenAsync(string token);
    ApplicationUser GetById(string id);
    
    bool RevokeToken(string token);
}