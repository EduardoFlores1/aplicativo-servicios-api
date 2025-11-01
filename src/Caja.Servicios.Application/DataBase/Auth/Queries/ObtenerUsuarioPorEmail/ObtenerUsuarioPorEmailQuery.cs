using Microsoft.EntityFrameworkCore;

namespace Caja.Servicios.Application.DataBase.Auth.Queries.ObtenerUsuarioPorEmail
{
    public class ObtenerUsuarioPorEmailQuery: IObtenerUsuarioPorEmailQuery
    {
        private readonly IDataBaseService _dataBaseService;
        public ObtenerUsuarioPorEmailQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<ObtenerUsuarioPorEmailResponse> ExecuteAsync(string email) {
            var response = await _dataBaseService.Usuarios
                .Where(u => u.Email == email)
                .Select(u => new ObtenerUsuarioPorEmailResponse
                {
                    PublicID = u.PublicID,
                    Nombres = u.Nombres,
                    Email = u.Email
                })
                .FirstOrDefaultAsync() ?? throw new InvalidOperationException("Usuario no encontrado: " + email); ;

            return response;
        }
    }
}
