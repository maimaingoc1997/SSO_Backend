using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        this._context = context;
    }

    [HttpPost]
    [Route("Registration")]
    
    public IActionResult Registration(UserDTO userDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var objUser = _context.Users.FirstOrDefault(x =>  x.Username == userDto.Username);
        if (objUser==null)
        {
            _context.Users.Add(new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password
            });
            _context.SaveChanges();
            return Ok("Usser registered successfully");
        }
        else
        {
            return BadRequest("User already exists");
        }
        

    }

    [HttpPost("Login")]
    public IActionResult Login(LoginDTO loginDto)
    {
        var user = _context.Users.FirstOrDefault(x => x.Username == loginDto.Username && x.Password == loginDto.Password);
        if (user != null)
        {
            return Ok(user);
        }

        return NoContent();
        
    }

    [HttpGet("GetAllUsers")]
    public IActionResult GetAllUsers()
    {
        return Ok(_context.Users.ToList());
    }
}