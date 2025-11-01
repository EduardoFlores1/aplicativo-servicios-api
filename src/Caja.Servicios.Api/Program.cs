using Caja.Servicios.Api;
using Caja.Servicios.Application;
using Caja.Servicios.Persistence;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebApi()
    .AddAplication()
    .AddPersistence(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    
    app.MapSwagger("/openapi/{documentName}.json");
    app.MapScalarApiReference();

}

    

app.Run();

