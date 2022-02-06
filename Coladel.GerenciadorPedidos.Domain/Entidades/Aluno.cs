using Coladel.Core.Extensions;
using Coladel.Domain.Body;
using System.Collections.Generic;

namespace Coladel.Domain.Entidades
{
    public class Aluno : Entity
    {
        public string NomeCliente { get; set; }

        public Aluno() { }
        public Aluno(CriarClienteRequestBody requestBody) => requestBody.MappingProperties(this);
    }
}
