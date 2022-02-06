using Coladel.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coladel.Infra.Data.Mapping
{
    public class AulaMapping : IEntityTypeConfiguration<Aula>
    {
        public void Configure(EntityTypeBuilder<Aula> builder)
        {
            builder.ToTable("aulas");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd().HasColumnType("smallint");
            builder.Property(p => p.IdAluno).HasColumnName("id_aluno_aulas").HasColumnType("smallint");
            builder.Property(p => p.Guid).HasColumnName("guid");
            builder.Property(p => p.DataCadastro).HasColumnName("data_cadastro");
            builder.Property(p => p.DataAula).HasColumnName("data_aula");
            builder.Property(p => p.Materia).HasColumnName("materia").HasColumnType("varchar(128)").HasConversion<string>();
            builder.Property(p => p.IsPaga).HasColumnName("is_paga").HasColumnType("bit");
            builder.Property(p => p.IsCancelada).HasColumnName("is_cancelada").HasColumnType("bit");
            builder.Property(p => p.IsRealizada).HasColumnName("is_realizada").HasColumnType("bit");
            builder.Property(p => p.TempoAula).HasColumnName("tempo_aula").HasColumnType("decimal(5,2)");
            builder.Property(p => p.ValorHora).HasColumnName("valor_hora").HasColumnType("decimal(10,2)");

            builder.HasOne(p => p.Aluno).WithMany().HasForeignKey(fk => fk.IdAluno);
        }
    }
}
