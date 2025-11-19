
using Caja.Servicios.Application.DataBase.Auth.Commands.RegistrarUsuario;
using FluentValidation;

namespace Caja.Servicios.Application.Validations.Auth
{
    public class RegistrarUsuarioValidator: AbstractValidator<RegistrarUsuarioRequest>
    {
        public RegistrarUsuarioValidator() {
            RuleFor(x => x.Nombres)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(12);
        }
    }
}
