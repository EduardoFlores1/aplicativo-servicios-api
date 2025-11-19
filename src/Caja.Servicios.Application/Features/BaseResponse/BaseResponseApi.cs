using Caja.Servicios.Domain.Models;
using FluentValidation.Results;

namespace Caja.Servicios.Application.Features.BaseResponse
{
    public static class BaseResponseApi
    {
        public static BaseResponseModel<T> Ok<T>
            (int statusCode, T data, string message = "Operación exitosa")
                => new()
                {
                    Success = true,
                    StatusCode = statusCode,
                    Message = message,
                    Data = data
                };

        public static BaseResponseModel<T> Fail<T>
            (int statusCode, string error, string message = "Ocurrió un error")
                => new()
                {
                    Success = false,
                    StatusCode = statusCode,
                    Message = message,
                    Errors = [ error ]
                };

        public static BaseResponseModel<T> Fail<T>
            (int statusCode, IEnumerable<ValidationFailure> errors, string message = "Ocurrió un error")
                => new()
                {
                    Success = false,
                    StatusCode = statusCode,
                    Message = message,
                    Errors = errors.Select(e => e.ErrorMessage)
                };
    }
}
