using Coladel.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coladel.Infra.Data.Mapping
{
    public class PagamentoMapping : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("pagamentos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd().HasColumnType("smallint");
            builder.Property(p => p.IdAluno).HasColumnName("id_aluno_pagamentos").HasColumnType("smallint");
            builder.Property(p => p.IdAula).HasColumnName("id_aula_pagamentos").HasColumnType("smallint");
            builder.Property(p => p.Guid).HasColumnName("guid");
            builder.Property(p => p.DataCadastro).HasColumnName("data_cadastro");
            builder.Property(p => p.Materia).HasColumnName("materia").HasColumnType("varchar(128)").HasConversion<string>();
            builder.Property(p => p.QuantidadeAulas).HasColumnName("quantidade_aulas").HasColumnType("smallint");
            builder.Property(p => p.ValorPago).HasColumnName("valor_pago").HasColumnType("decimal(5,2)");
            builder.Property(p => p.ValorHora).HasColumnName("valor_hora").HasColumnType("decimal(5,2)");

            builder.HasOne(p => p.Aluno).WithMany().HasForeignKey(fk => fk.IdAluno);
            builder.HasOne(p => p.Aula).WithMany().HasForeignKey(fk => fk.IdAula);
        }
    }
}
