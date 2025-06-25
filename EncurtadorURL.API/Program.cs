using EncurtadorUrl.Aplication.Interfaces;
using EncurtadorUrl.Aplication.Services;
using EncurtadorUrl.Infra.Repositories;
using EncurtadorURL.Core.IRepositories;
using EncurtadorURL.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUrlRepository, UrlRepository>();
builder.Services.AddScoped<IUrlService, UrlService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/{shortCode}", async (string shortCode, IUrlService urlService, HttpContext context) =>
{
    if (string.IsNullOrWhiteSpace(shortCode))
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsync("Código curto inválido.");
        return;
    }

    try
    {
        var longUrl = await urlService.RedirecionarUrl(shortCode);

        if (!string.IsNullOrEmpty(longUrl))
        {
            context.Response.Redirect(longUrl, permanent: true);
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsync("URL curta não encontrada.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro no redirecionamento para o código '{shortCode}': {ex.Message}");
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsync("Ocorreu um erro interno ao processar sua requisição.");
    }
});

app.Run();
