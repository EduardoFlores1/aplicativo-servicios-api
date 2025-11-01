using Caja.Servicios.Api;
using Caja.Servicios.Application;
using Caja.Servicios.Domain.Models.Jwt;
using Caja.Servicios.Persistence;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtSettings>(
                builder.Configuration.GetSection(JwtSettings.Seccion)
            );

//injeccion
builder.Services
    .AddWebApi()
    .AddAplication()
    .AddPersistence(builder.Configuration);

builder.Services.AddControllers();

// scalar
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// auth jwt
builder.Services.AddAutenticationPersonalizado(builder.Configuration);
builder.Services.AddAuthorization();

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    
    app.MapSwagger("/openapi/{documentName}.json");
    app.MapScalarApiReference();

}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Run();

