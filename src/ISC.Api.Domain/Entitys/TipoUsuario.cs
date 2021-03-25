using ISC.Api.Domain.Entitys.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISC.Api.Domain.Entitys
{
    public class TipoUsuario : Entity
    {
        public string Tipo { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
