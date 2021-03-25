using ISC.Api.Domain.Entitys.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISC.Api.Domain.Entitys
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int EmpresaId { get; set; }
        public DateTime DataInclusao { get; set; }
        public Empresa Empresa { get; set; }
    }
}
