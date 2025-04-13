using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using UserFeature.Extensions;
using UserFeature.Services.Interfaces;

namespace UserFeature.Services;

public class UserService(DatabaseContext dbContext) : IUserService
{
    public async Task<User> GetUserAsync(int id)
    {
        return await dbContext.Users().FirstAsync(user => user.Id == id);
    }

    public async Task<User> CreateUserAsync(User user)
    {
        await dbContext.Users().AddAsync(user);
        await dbContext.SaveChangesAsync();

        return user;
    }
}