using Core.Models;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using WarningModule.Services.Interfaces;

namespace WarningModule.Services;

public class WarningService(ApplicationDbContext dbContext) : IWarningService
{
    public async Task<Warning?> GetWarningAsync(int id) => await dbContext.Set<Warning>().FirstOrDefaultAsync(warning => warning.Id == id);
}