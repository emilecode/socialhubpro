using Microsoft.AspNetCore.Mvc;
using Socialhub.API.Entities;
using Socialhub.API.DTOs;
using Socialhub.API.Interfaces;
namespace Socialhub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    
    public UserController(IUserService service)
    {
        _service = service;
    }
    [HttpPost]
    public async Task<ActionResult<UserResponseDto>>Create(UserRequestDto user)
    {
        var newuser = await _service.CreateAsync(user);
        if(newuser is null)
        {
            return BadRequest("User data connot be empty.");
        } 
        return CreatedAtAction(nameof(Create),new UserResponseDto(newuser.Id,newuser.Username,newuser.Email));
    }
    
}