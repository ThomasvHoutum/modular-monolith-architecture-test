using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UserFeature.Database;

public class UserModelConfigurator : IModelConfigurator
{
    public void Configure(ModelBuilder modelBuilder) => modelBuilder.ApplyConfiguration(new UserConfiguration());
}