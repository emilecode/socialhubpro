namespace Socialhub.API.DTOs;

public record UserResponseDto(Guid Id, string Username,string Email);

public record UserRequestDto(string Username,string Email,string Password);

