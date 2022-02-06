using Coladel.Core.Extensions;
using Coladel.Domain.Enum;
using System;

namespace Coladel.Domain.Entidades
{
    public class Aula : Entity
    {
        public short IdAluno { get; set; }
        public decimal TempoAula { get; set; }
        public decimal ValorHora { get; set; }
        public bool IsPaga { get; set; }
        public bool IsCancelada { get; set; }
        public bool IsRealizada { get; set; }
        public DateTime DataAula { get; set; }
        public Materia Materia { get; set; }

        public virtual Aluno Aluno { get; set; }

        public Aula() { }
        public Aula(object mapping) => mapping.MappingProperties(this);

        public void AlterarParaRealizada() => IsRealizada = true;
        public void CancelarAula() => IsCancelada = true;
    }
}
