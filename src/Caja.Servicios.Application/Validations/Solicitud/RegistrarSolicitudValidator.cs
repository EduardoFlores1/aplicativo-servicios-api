using Caja.Servicios.Application.DataBase.Solicitud.Commands.RegistrarSolicitud;
using FluentValidation;

namespace Caja.Servicios.Application.Validations.Solicitud
{
    public class RegistrarSolicitudValidator: AbstractValidator<RegistrarSolicitudRequest>
    {
        public RegistrarSolicitudValidator() {
            RuleFor(x => x.PublicUsuarioRegistraID)
                .NotEmpty()
                .NotEqual(Guid.Empty);
            RuleFor(x => x.DetalleSolicitud)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
