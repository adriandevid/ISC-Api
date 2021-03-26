using ISC.Api.Application.Interfaces;
using ISC.Api.Domain.Dtos;
using ISC.Api.Domain.Entitys;
using ISC.Api.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListarUsuarios/")]
        [Authorize(Roles = "Administrador")]
        public IEnumerable<Usuario> ListarUsuarios() {
            return _queriesUser.ListarUsuarios();
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <returns></returns>
        [HttpPost("Cadastrar/")]
        [AllowAnonymous]
        public async Task<IActionResult> Cadastrar([FromBody]UsuarioRegisterDto user) {
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

        /// <summary>
        /// Faz o login do usuario
        /// </summary>
        /// <returns>Token de usuario com seus dados confirmados</returns>
        [HttpGet("Login/")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Login([FromQuery] UsuarioLoginDto user) {
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
