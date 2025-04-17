using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Interfaces;

public interface IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder);
}