namespace Coladel.Application.Handlers.Pagamentos.Response
{
    public class BuscarTotalPagamentosMesAnoResponse
    {
        public decimal TotalPago { get; set; }
        public short Mes { get; set; }
        public short Ano { get; set; }

        public BuscarTotalPagamentosMesAnoResponse(decimal total, short mes, short ano)
        {
            TotalPago = total;
            Mes = mes;
            Ano = ano;
        }
    }
}
