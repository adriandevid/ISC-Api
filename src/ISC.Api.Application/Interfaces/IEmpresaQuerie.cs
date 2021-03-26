using ISC.Api.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Api.Application.Interfaces
{
    public interface IEmpresaQuerie
    {
        Task<bool> CadastrarEmpresa(Empresa empr);
        Task<bool> CadastrarProdutoEmpresa(Produto prod);
    }
}
