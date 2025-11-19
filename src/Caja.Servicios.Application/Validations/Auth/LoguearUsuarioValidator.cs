using Caja.Servicios.Application.DataBase.Auth.Commands.LoguearUsuario;
using FluentValidation;

namespace Caja.Servicios.Application.Validations.Auth
{
    public class LoguearUsuarioValidator: AbstractValidator<LoguearUsuarioRequest>
    {
        public LoguearUsuarioValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(12);
        }
    }
}
