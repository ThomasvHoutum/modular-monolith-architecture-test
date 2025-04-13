using Core.Modules;
using Core.Modules.Interfaces;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var modules = new List<IModule>();

// TODO: Do this dynamically
if (ActiveModuleList.GetActiveModules().Contains("WarningModule"))
    modules.Add(new WarningModule.ModuleActivator());

// Register each module and let them add their own services.
foreach (var module in modules)
{
    builder.Services.AddSingleton(module);
    module.ConfigureServices(builder.Services);
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

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
