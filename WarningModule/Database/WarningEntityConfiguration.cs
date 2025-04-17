using Core.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WarningModule.Database;

public class WarningEntityConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Warning>(entity =>
        {
            entity.ToTable("Warnings");
            entity.HasKey(warning => warning.Id);
            entity.Property(warning => warning.Id).ValueGeneratedOnAdd();
            entity.Property(warning => warning.UserId).IsRequired();
            entity.Property(warning => warning.Message);
            entity.Property(warning => warning.CreatedAt).IsRequired();
        });
    }
}