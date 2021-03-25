using ISC.Api.Domain.Entitys;
using ISC.Api.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISC.Api.Infra.Data.Context
{
    public class ISCDbContext : DbContext
    {
        public ISCDbContext(DbContextOptions<ISCDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            foreach (var property in builder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }
            builder.ApplyConfiguration(new UsuarioConfig());
            builder.ApplyConfiguration(new TipoUsuarioConfig());
            builder.ApplyConfiguration(new ProdutoConfig());
            builder.ApplyConfiguration(new EmpresaConfig());

            base.OnModelCreating(builder);
        }
    }
}
