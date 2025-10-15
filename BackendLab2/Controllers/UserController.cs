using BackendLab2.Models;
using BackendLab2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackendLab2.Controllers;

[ApiController]
[Route("")]
public class UserController : ControllerBase
{
    private readonly UserRepository _userRepository;

    public UserController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpGet("user/{id:int}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        try
        {
            var user = await _userRepository.GetUser(id);
            if (user == null)
                return NotFound(new { message = "User was not found" });

            return user;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("user/{id:int}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        try
        {
            await _userRepository.DeleteUser(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("/user")]
    public async Task<ActionResult> PostUser([FromBody] User user)
    {
        try
        {
            await _userRepository.CreateUser(user);
            return Created();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("/users")]
    public async Task<ActionResult<List<User>>> ListUser()
    {
        try
        {
            var users = await _userRepository.GetAllUsers();
            return Ok(users);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}