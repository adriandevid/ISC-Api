using ISC.Api.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISC.Api.Infra.Data.EntityConfig
{
    public class TipoUsuarioConfig : IEntityTypeConfiguration<TipoUsuario>
    {
        public void Configure(EntityTypeBuilder<TipoUsuario> builder)
        {
            builder.ToTable("tb_tp_usuario", "ISC");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("cd_tp_usuario_pk").ValueGeneratedOnAdd();

            builder.Property(x => x.Tipo).HasColumnName("nm_tipo").IsRequired();

            builder.HasMany(x => x.Usuarios).WithOne(x => x.TipoUsuario).HasForeignKey(x => x.TipoUsuarioId);
        }
    }
}
