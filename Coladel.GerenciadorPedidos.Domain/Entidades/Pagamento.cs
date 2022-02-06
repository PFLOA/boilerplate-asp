using Coladel.Core.Extensions;
using Coladel.Domain.Enum;
using System.Collections.Generic;

namespace Coladel.Domain.Entidades
{
    public class Pagamento : Entity
    {
        private decimal _valorPago;

        public int QuantidadeAulas { get; set; }
        public decimal ValorPago { get; set; }
        public decimal ValorHora
        {
            get
            {
                if (_valorPago != 0)
                    return _valorPago;

                return ValorPago / QuantidadeAulas; ;
            }
            set
            {
                _valorPago = value;
            }
        }
        public Materia Materia { get; set; }

        public short IdAluno { get; set; }
        public short IdAula { get; set; }

        public virtual Aluno Aluno { get; set; }
        public virtual Aula Aula { get; set; }

        public Pagamento() { }
        public Pagamento(object mapping, short idAula) 
        { 
            mapping.MappingProperties(this);
            IdAula = idAula;
        }
    }
}
