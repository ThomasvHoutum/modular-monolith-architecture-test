using Domain.Models;

namespace UserFeature.Services.Interfaces;

public interface IUserService
{
    public Task<User> GetUserAsync(int id);
    
    public Task<User> CreateUserAsync(User user);
}