using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth_JWT.Models;
using Auth_JWT.Repository;
using Auth_JWT.Services;
using Microsoft.AspNetCore.Mvc;

namespace Auth_JWT.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserEntity user)
        {
            //Recupera o usuario
            var userAuth = UserRepository.Get(user.UserName, user.Password);

            //Verifica se o user existe
            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            // Gera um token
            var token = TokenService.GenerateToken(userAuth);

            //Oculta a Senha;
            userAuth.Password = "";

            //Retorna os dados

            return Ok(new
            {
                user = userAuth.UserName,
                token = token
            });
        }
    }
}
