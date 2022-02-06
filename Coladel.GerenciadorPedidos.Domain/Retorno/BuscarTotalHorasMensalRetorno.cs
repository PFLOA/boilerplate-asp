namespace Coladel.Domain.Retorno
{
    public class BuscarTotalHorasMensalRetorno
    {
        public decimal TotalHorasPendentes { get; }
        public decimal TotalHorasDadas { get; }

        public BuscarTotalHorasMensalRetorno(decimal totalHorasPendentes, decimal totalHorasDadas)
        {
            TotalHorasPendentes = totalHorasPendentes;
            TotalHorasDadas = totalHorasDadas;
        }
    }
}
