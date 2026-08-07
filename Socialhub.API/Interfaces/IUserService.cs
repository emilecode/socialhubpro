using Socialhub.API.DTOs;

namespace Socialhub.API.Interfaces;
public interface IUserService
{
    Task<UserResponseDto?> CreateAsync(UserRequestDto user);
//    Task<UserResponseDto?> GetAllAsync();
//    Task<UserResponseDto?> DeleteAsync(Guid id);
}