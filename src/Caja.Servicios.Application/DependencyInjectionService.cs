using AutoMapper;
using Caja.Servicios.Application.Configuration;
using Caja.Servicios.Application.DataBase.Auth.Commands.LoguearUsuario;
using Caja.Servicios.Application.DataBase.Auth.Commands.RegistrarUsuario;
using Caja.Servicios.Application.DataBase.Solicitud.Commands.ActualizarSolicitud;
using Caja.Servicios.Application.DataBase.Solicitud.Commands.EliminarSolicitud;
using Caja.Servicios.Application.DataBase.Solicitud.Commands.RegistrarSolicitud;
using Caja.Servicios.Application.DataBase.Solicitud.Queries.ListarSolicitudesEliminadas;
using Caja.Servicios.Application.DataBase.Usuario.Queries.ObtenerUsuarioPorEmail;
using Caja.Servicios.Application.Features.Jwt;
using Caja.Servicios.Application.Validations.Auth;
using Caja.Servicios.Application.Validations.Solicitud;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Caja.Servicios.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddAplication(
            this IServiceCollection services) {

            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            services.AddSingleton(mapper.CreateMapper());

            services.AddTransient<IRegistrarUsuarioCommand, RegistrarUsuarioCommand>();
            services.AddTransient<IObtenerUsuarioPorEmailQuery, ObtenerUsuarioPorEmailQuery>();
            
            services.AddTransient<IActualizarSolicitudCommand, ActualizarSolicitudCommand>();
            services.AddTransient<IRegistrarSolicitudCommand, RegistrarSolicitudCommand>();
            services.AddTransient<IEliminarSolicitudCommand, EliminarSolicitudCommand>();
            services.AddTransient<IListarSolicitudesEliminadasQuery, ListarSolicitudesEliminadasQuery>();

            // Auth

            services.AddScoped<IJwtService, JwtService>();
            services.AddTransient<ILoguearUsuarioCommand, LoguearUsuarioCommand>();

            // Validaciones

            services.AddScoped<IValidator<LoguearUsuarioRequest>, LoguearUsuarioValidator>();
            services.AddScoped<IValidator<RegistrarUsuarioRequest>, RegistrarUsuarioValidator>();
            services.AddScoped<IValidator<ActualizarSolicitudRequest>, ActualizarSolicitudValidator>();
            services.AddScoped<IValidator<RegistrarSolicitudRequest>, RegistrarSolicitudValidator>();

            return services;
        }
    }
}
