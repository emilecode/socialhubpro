using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult<UserResponseDto?>>Create(UserRequestDto user)
    {
        var newUser = await _service.CreateAsync(user);
        if(newUser == null)
        {
            return BadRequest("Invalid info.");
        }
        return CreatedAtAction(nameof(GetAll),new {id = newUser.Id},newUser);
    }

    [HttpGet]
    public async Task<ActionResult<List<UserResponseDto>>> GetAll()
    {
        var users = await _service.GetAllAsync();
        return Ok(users);
    }  
    [HttpDelete("{id}")]
    public async Task<ActionResult<UserResponseDto?>> Delete(Guid id)
    {
        var deletedUser = await _service.DeleteAsync(id);
        if(deletedUser is null)
        {
            return NotFound($"No User With Id:({id})");
        }
        return Ok(deletedUser);
    }



}
