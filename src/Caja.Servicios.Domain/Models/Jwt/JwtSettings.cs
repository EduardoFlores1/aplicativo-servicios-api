namespace Caja.Servicios.Domain.Models.Jwt
{
    public class JwtSettings
    {
        public const string Seccion = "Jwt";

        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
