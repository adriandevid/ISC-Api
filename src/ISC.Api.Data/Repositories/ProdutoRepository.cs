using ISC.Api.Domain.Entitys;
using ISC.Api.Domain.Intefaces;
using ISC.Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Api.Infra.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        protected readonly ISCDbContext _context;
        public ProdutoRepository(ISCDbContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<bool> verificarDuplicidade(string nome, decimal valor)
        {
            var user = await _context.Set<Produto>().AsQueryable().Where(x => x.Nome == nome && x.Valor == valor).FirstOrDefaultAsync();
            return user != null;
        }

        public async new Task<Produto> GetByIdAsync(long id)
            => await _context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
    }
}
