using Domain.Interfaces;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using UserFeature.Database;
using UserFeature.Services;
using UserFeature.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

// Register features here
builder.Services.AddTransient<IModelConfigurator, UserModelConfigurator>();

// Bruh
builder.Services.AddTransient<DatabaseContext>();

// TODO: Let feature register their own services
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
