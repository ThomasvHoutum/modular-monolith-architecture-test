using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace UserFeature.Extensions;

public static class DbContextExtension
{
    public static DbSet<User> Users(this DbContext dbContext) => dbContext.Set<User>();
}