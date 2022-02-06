namespace Coladel.Application.Handlers.Aulas.Response
{
    public class BuscarTotalHorasMesAnoResponse
    {
        public decimal TotalHorasDadas { get; }
        public decimal TotalHorasPendentes { get; set; }
        public short Mes { get; }
        public short Ano { get; }

        public BuscarTotalHorasMesAnoResponse(decimal totalHorasDadas, decimal totalHorasPendentes, short mes, short ano)
        {
            TotalHorasDadas = totalHorasDadas;
            TotalHorasPendentes = totalHorasPendentes;
            Mes = mes;
            Ano = ano;
        }
    }
}
