namespace Coladel.Application.Handlers.Aulas.Response
{
    public class BuscarPagamentosPendentesResponse
    {
        public decimal TotalPendente { get; }

        public BuscarPagamentosPendentesResponse(decimal totalPendente)
        {
            TotalPendente = totalPendente;
        }
    }
}
