using Caja.Servicios.Api;
using Caja.Servicios.Application;
using Caja.Servicios.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebApi()
    .AddAplication()
    .AddPersistence(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();

