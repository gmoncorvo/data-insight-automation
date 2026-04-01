using backend_dotnet.Data;
using Microsoft.EntityFrameworkCore;
using backend_dotnet.Services;
using backend_dotnet.Repositories;
using backend_dotnet.DTOs;
using backend_dotnet.Common;
using backend_dotnet.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<PriceService>();
builder.Services.AddScoped<PriceRepository>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/prices", async (PriceService service, [AsParameters] PriceQueryParams queryParams) =>
{
    var result = await service.GetAllPricesAsync(queryParams);

    var totalPages = (int)Math.Ceiling((double)result.Item2 / queryParams.PageSize);

    var pagination = new PaginationMetadataDto
    {
        Page = queryParams.Page,
        PageSize = queryParams.PageSize,
        TotalItems = result.Item2,
        TotalPages = totalPages
    };

    return Results.Ok(ApiResponse<object>.SuccessResponse(result.Item1, pagination));
});

app.MapPost("/prices", async (PriceService service, CreatePriceDto dto) =>
{
    var createdPrice = await service.AddPriceAsync(dto);
    return Results.Created($"/prices/{createdPrice.Id}", ApiResponse<object>.SuccessResponse(createdPrice));
});

app.MapGet("/prices/{assetName}", async (PriceService service, string assetName) =>
{
    var prices = await service.GetPricesByAssetAsync(assetName);

    if (prices.Count == 0)
    {
        return Results.Ok(new ApiResponse<object>
        {
            Success = true,
            Data = prices,
            Message = "Nenhum registro encontrado para o ativo informado."
        });
    }

    return Results.Ok(ApiResponse<object>.SuccessResponse(prices));
});

app.Run();