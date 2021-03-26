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
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly ISCDbContext _context;

        public UsuarioRepository(ISCDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> verificarDuplicidade(string login)
        {
            var Usuario = await _context.Usuarios.AsQueryable().Where(x => x.Login == login).FirstOrDefaultAsync();
            return Usuario != null;
        }
        public async new Task<Usuario> GetByIdAsync(long id)
            => await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
    }
}
