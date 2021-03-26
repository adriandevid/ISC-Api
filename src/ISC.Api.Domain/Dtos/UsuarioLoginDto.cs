using System;
using System.Collections.Generic;
using System.Text;

namespace ISC.Api.Domain.Dtos
{
    public class UsuarioLoginDto
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public int TipoUsuarioId { get; set; }
    }
}
