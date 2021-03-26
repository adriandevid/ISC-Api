using ISC.Api.Application.Interfaces;
using ISC.Api.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
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

        public UsuarioController(IUsuarioQuerie UsuarioQuerie)
        {
            _queriesUser = UsuarioQuerie;
        }

        [HttpPost("Cadastrar/")]
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
    }
}
