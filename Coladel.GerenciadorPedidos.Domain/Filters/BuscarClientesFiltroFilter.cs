using Coladel.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coladel.Domain.Filters
{
    public class BuscarClientesFiltroFilter : BaseFilter
    {
        /// <summary>
        /// Nome do cliente, pesquisa por aproximação.
        /// </summary>
        public string NomeCliente { get; set; }
        /// <summary>
        /// Data de cadastro do cliente ou clientes.
        /// </summary>
        public DateTime DataCadastro { get; set; }
    }
}
