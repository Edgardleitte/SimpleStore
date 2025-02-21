using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Configuração de CORS para permitir o front-end acessar a API
app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

// Endpoint para fornecer a lista de produtos
app.MapGet("/api/products", () =>
{
    var products = new[]
    {
        new { Id = 1, Name = "Mouse", Price = 25.99, Stock = 50, Category = new { Id = 101, Name = "Peripherals" } },
        new { Id = 2, Name = "Keyboard", Price = 45.99, Stock = 30, Category = new { Id = 102, Name = "Peripherals" } },
    };

    return Results.Json(products, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
});

app.Run();
