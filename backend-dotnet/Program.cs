using backend_dotnet.Data;
using Microsoft.EntityFrameworkCore;
using backend_dotnet.Models;
using backend_dotnet.Services;
using backend_dotnet.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<PriceService>();
builder.Services.AddScoped<PriceRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/prices", async (PriceService service) =>
{
    var prices = await service.GetAllPricesAsync();
    return Results.Ok(prices);
});

app.MapPost("/prices", async (PriceService service, PriceHistory price) =>
{
    var createdPrice = await service.AddPriceAsync(price);
    return Results.Created($"/prices/{createdPrice.Id}", createdPrice);
});

app.Run();