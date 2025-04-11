using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces;

public interface IModelConfigurator
{
    void Configure(ModelBuilder modelBuilder);
}