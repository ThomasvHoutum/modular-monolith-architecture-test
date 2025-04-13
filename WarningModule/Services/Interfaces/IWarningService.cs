using Core.Models;

namespace WarningModule.Services.Interfaces;

public interface IWarningService
{
    public Task<Warning?> GetWarningAsync(int id);
}