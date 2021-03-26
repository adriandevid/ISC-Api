using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Api.Domain.Intefaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
