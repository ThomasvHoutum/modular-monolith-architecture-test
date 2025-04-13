using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
}