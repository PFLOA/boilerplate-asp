using Coladel.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coladel.Infra.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Guid).HasColumnName("guid");
            builder.Property(p => p.DataCadastro).HasColumnName("data_cadastro");
            builder.Property(p => p.Nome).HasColumnName("nome");
            builder.Property(p => p.Senha).HasColumnName("senha");
            builder.Property(p => p.Email).HasColumnName("email");
            builder.Property(p => p.UserName).HasColumnName("user_name");
            builder.Property(p => p.ConnectionString).HasColumnName("connection_string");
        }
    }
}
