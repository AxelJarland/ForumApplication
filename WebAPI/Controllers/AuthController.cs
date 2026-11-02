using APIContracts.Users;
using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository userRepo;

    public AuthController(IUserRepository userRepo)
    {
        this.userRepo = userRepo;
    }

    [HttpPost("login")]
    public ActionResult<UserDTO> Login([FromBody] LoginRequestDTO request)
    {
        try
        {
            User? user = userRepo.GetManyAsync()
                .FirstOrDefault(u => u.Username.ToLower() == request.Username.ToLower());

            if (user is null)
            {
                return Unauthorized("Username or password is incorrect.");
            }

            if (user.Password != request.Password)
            {
                return Unauthorized("Username or password is incorrect.");
            }

            UserDTO dto = new()
            {
                Id = user.Id,
                Username = user.Username
            };
            return Ok(dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}