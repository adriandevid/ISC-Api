using ISC.Api.Domain.Entitys.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISC.Api.Domain.Entitys
{
    public class Usuario : Entity
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        public int EmpresaId { get; set; }
        public int TipoUsuarioId { get; set; }

        public TipoUsuario TipoUsuario { get; set; }
        public Empresa Empresa { get; set; }
    }
}
