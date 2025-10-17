using CrudToAlgo.Application.Services;
using CrudToAlgo.Domain.Repositories;
using CrudToAlgo.Infrastructure;
using CrudToAlgo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repos + Services
builder.Services.AddScoped<IDesafioRepository, DesafioRepository>();
builder.Services.AddScoped<IDesafioService, DesafioService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
