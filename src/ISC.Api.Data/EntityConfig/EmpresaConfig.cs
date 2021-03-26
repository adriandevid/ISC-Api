using ISC.Api.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISC.Api.Infra.Data.EntityConfig
{
    public class EmpresaConfig : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("tb_empresa", "ISC");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("cd_empresa_pk").ValueGeneratedOnAdd();

            builder.Property(x => x.Nome).HasColumnName("nm_empresa");
            builder.Property(x => x.Cnpj).HasColumnName("nm_cnpj");

            builder.HasMany(x => x.Produtos).WithOne(x => x.Empresa).HasForeignKey(x => x.EmpresaId);
        }
    }
}
