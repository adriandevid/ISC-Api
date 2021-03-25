using ISC.Api.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISC.Api.Infra.Data.EntityConfig
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("tb_produto", "ISC");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("cd_produto_pk").ValueGeneratedOnAdd();

            builder.Property(x => x.Nome).HasColumnName("nm_produto");
            builder.Property(x => x.DataInclusao).HasColumnName("dt_inclusao").IsRequired();
            builder.Property(x => x.Valor).HasColumnName("vl_produto");
            builder.Property(x => x.EmpresaId).HasColumnName("cd_empresa_fk").IsRequired();

            builder.HasOne(x => x.Empresa).WithMany(x => x.Produtos).HasForeignKey(x => x.EmpresaId);
        }
    }
}
