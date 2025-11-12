namespace Caja.Servicios.Application.DataBase.Usuario.Queries.ObtenerUsuarioPorEmail
{
    public interface IObtenerUsuarioPorEmailQuery
    {
        Task<ObtenerUsuarioPorEmailResponse> ExecuteAsync(string email);
    }
}
