using ISC.Api.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISC.Api.Infra.Data.EntityConfig
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tb_usuario", "ISC");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("cd_usuario_pk").ValueGeneratedOnAdd();

            builder.Property(x => x.Login).HasColumnName("nm_login").IsRequired();
            builder.Property(x => x.Senha).HasColumnName("nm_password").IsRequired();
            builder.Property(x => x.EmpresaId).HasColumnName("cd_empresa_fk");
            builder.Property(x => x.TipoUsuarioId).HasColumnName("cd_tp_usuario_fk").IsRequired();
            builder.HasOne(x => x.TipoUsuario).WithMany(x => x.Usuarios).HasForeignKey(x => x.TipoUsuarioId);
        }
    }
}
