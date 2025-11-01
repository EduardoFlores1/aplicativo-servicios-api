namespace Caja.Servicios.Application.DataBase.Auth.Queries.ObtenerUsuarioPorEmail
{
    public interface IObtenerUsuarioPorEmailQuery
    {
        Task<ObtenerUsuarioPorEmailResponse> ExecuteAsync(string email);
    }
}
