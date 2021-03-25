using ISC.Api.Domain.Entitys.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISC.Api.Domain.Entitys
{
    public class Empresa : Entity
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
