using ISC.Api.Application.Interfaces;
using ISC.Api.Domain.Dtos;
using ISC.Api.Domain.Entitys;
using ISC.Api.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISC.Api.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioQuerie _queriesUser;
        private readonly IConfiguration _config;
        public UsuarioController(IUsuarioQuerie UsuarioQuerie, IConfiguration configuration)
        {
            _config = configuration;
            _queriesUser = UsuarioQuerie;
        }

        [HttpGet("ListarUsuarios/")]
        [Authorize(Roles = "Administrador")]
        public IEnumerable<Usuario> ListarUsuarios() {
            return _queriesUser.ListarUsuarios();
        }

        [HttpPost("Cadastrar/")]
        [AllowAnonymous]
        public async Task<IActionResult> Cadastrar(UsuarioRegisterDto user) {
            try
            {
                var registerUser = await _queriesUser.CadastrarUsuario(user);
                if (registerUser)
                {
                    return Ok(new { Response = "Success register", UserLogin = new { Login = user.Login, Password = user.Senha } });
                }
                else {
                    return Ok("Erro register");
                }
            }
            catch (Exception ex) {
                return Ok(ex);
            }
        }

        [HttpGet("Login/")]
        [AllowAnonymous]
        public IActionResult Login(UsuarioLoginDto user) {
            try {
                var UserLogin = _queriesUser.VerificarUsuario(user.Login, user.Senha);
                if (UserLogin != null)
                {
                    return Ok(new { Token = JwtService.GenerateToken(UserLogin, _config), User = UserLogin });
                }
                else {
                    return Ok("Usuario não existe");
                }
            } catch (Exception ex) {
                return Ok(ex);
            }
        }
    }
}
