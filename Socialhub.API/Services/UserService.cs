using Microsoft.EntityFrameworkCore;
using Socialhub.API.DataBase;
using Socialhub.API.Interfaces;
using Socialhub.API.Entities;
using Socialhub.API.DTOs;
using BCryptNet = BCrypt.Net.BCrypt;
namespace Socialhub.API.Services;
public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;
    
    public UserService(ApplicationDbContext context)
    {
        _context = context;
        
    }
    
    public async Task<UserResponseDto?> CreateAsync(UserRequestDto dto)
    {
        if(dto is null)
        {
            return null;
        }
        bool emailExists = await _context.Users.AnyAsync(u => u.Email == dto.Email);
        if(emailExists)
        {
            return null;
        }    
        string secureHash = BCryptNet.HashPassword(dto.Password);
        var newUser = new User
        {
          Username = dto.Username,
          Email = dto.Email,
          PasswordHash =  secureHash 
        };
        
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();
        return new UserResponseDto
        (
            newUser.Id,
         newUser.Username,
            newUser.Email
        );
    }
    
     
    
}
