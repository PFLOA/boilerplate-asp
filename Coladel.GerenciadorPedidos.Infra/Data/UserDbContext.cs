using Coladel.Domain.Entidades;
using Coladel.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Colade.Infra.Data
{
    public class UserDbContext : DbContext
    {
        public DbSet<Aula> Aula { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }

        /// <summary>
        /// Construtor Padrão.
        /// </summary>
        /// <param name="options"></param>
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AulaMapping());
            modelBuilder.ApplyConfiguration(new AlunoMapping());
            modelBuilder.ApplyConfiguration(new PagamentoMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
