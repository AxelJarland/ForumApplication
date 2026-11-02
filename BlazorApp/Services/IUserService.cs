using APIContracts.Users;
namespace BlazorApp.Services;

public interface IUserService
{
    Task<UserDTO> AddUserAsync(CreateUserDTO request);
    Task<UserDTO> GetUserAsync(int id);
    Task<List<UserDTO>> GetUsersAsync();
}