using Caja.Servicios.Application.DataBase.Solicitud.Commands.ActualizarSolicitud;
using FluentValidation;

namespace Caja.Servicios.Application.Validations.Solicitud
{
    public class ActualizarSolicitudValidator: AbstractValidator<ActualizarSolicitudRequest>
    {
        public ActualizarSolicitudValidator()
        {
            RuleFor(x => x.PublicSolicitudID)
                .NotEmpty()
                .NotEqual(Guid.Empty);
            RuleFor(x => x.DetalleSolicitud)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
