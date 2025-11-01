namespace Caja.Servicios.Domain.Models
{
    public class BaseExceptionModel
    {
        public  int StatusCode { get; set; }
        public  string ErrorCode { get; set; } = string.Empty;
        public  string Message { get; set; } = string.Empty;

        public static BaseExceptionModel toModel(
            int statusCode, 
            string errorCode,
            string message)
        {
            return new BaseExceptionModel
            {
                StatusCode = statusCode,
                ErrorCode = errorCode,
                Message = message
            };
        }

    }
}
