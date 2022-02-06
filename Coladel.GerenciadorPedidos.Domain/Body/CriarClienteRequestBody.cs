using Coladel.Domain.Entidades;

namespace Coladel.Domain.Body
{
    public class CriarClienteRequestBody
  {
    public string NomeCliente { get; set; }
    public virtual Aluno ToModel() => new Aluno(this);
  }
}
