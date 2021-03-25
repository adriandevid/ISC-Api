using ISC.Api.Domain.Entitys;
using ISC.Api.Domain.Intefaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Api.Domain.Intefaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        new Task<Usuario> GetByIdAsync(long id);
        Task<bool> verificarDuplicidade(string login);
    }
}
