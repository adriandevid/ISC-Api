using ISC.Api.Domain.Dtos;
using ISC.Api.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Api.Application.Interfaces
{
    public interface IUsuarioQuerie
    {
        Task<Usuario> GetUsuarioById(long id);
        Task<bool> CadastrarUsuario(UsuarioRegisterDto user);
        Task<bool> RemoverUsuario(long id);
        Usuario VerificarUsuario(string Login, string senha);
        IEnumerable<Usuario> ListarUsuarios();
        void Update(UsuarioUpdateDto usr);
    }
}
