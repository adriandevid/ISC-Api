using ISC.Api.Domain.Entitys;
using ISC.Api.Domain.Intefaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Api.Domain.Intefaces
{
    public interface IEmpresaRepository : IRepository<Empresa>
    {
        new Task<Empresa> GetByIdAsync(long id);
        Task<bool> verificarDuplicidade(string cnpj, string nome);
    }
}
