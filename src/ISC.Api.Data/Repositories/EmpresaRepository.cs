using ISC.Api.Domain.Entitys;
using ISC.Api.Domain.Intefaces;
using ISC.Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Api.Infra.Data.Repositories
{
    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        private readonly ISCDbContext _context;

        public EmpresaRepository(ISCDbContext context)  : base(context)
        {
            _context = context;
        }
        public async new Task<Empresa> GetByIdAsync(long id)
            => await _context.Empresas.FirstOrDefaultAsync(x => x.Id == id);

        public Task<bool> verificarDuplicidade(string login)
        {
            throw new NotImplementedException();
        }
    }
}
