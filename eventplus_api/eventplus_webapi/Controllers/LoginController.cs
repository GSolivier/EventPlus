﻿using eventplus_webapi.Domains;
using eventplus_webapi.Interfaces;
using eventplus_webapi.Repositories;
using eventplus_webapi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eventplus_webapi.Controllers
{
    /// <summary>
    /// Controlador com os métodos necessários para realizar o login
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        /// <summary>
        /// Construtor para criar um novo objeto UsuarioRepository
        /// </summary>
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Método para realizar o login de um usuário utilizando o método BuscarPorEmailESenha no UsuarioRepository
        /// </summary>
        /// <param name="usuario">Objeto da LoginViewModel para realizar o login do usuário</param>
        /// <returns>Retorna um StatusCode 200 - Ok</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioEncontrado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

                if (usuarioEncontrado == null)
                {
                    return NotFound("Email ou senha inválidos");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioEncontrado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioEncontrado.Nome!.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioEncontrado.Email!),
                    //new Claim(ClaimTypes.Role, usuarioEncontrado.TiposUsuario!.Titulo!)
                    new Claim("role", usuarioEncontrado.TiposUsuario!.Titulo!)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senai-eventplus-chave-autenticacao-webapi"));

                var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                        issuer: "eventplus_webapi",

                        audience: "eventplus_webapi",

                        claims: claims,

                        expires: DateTime.Now.AddMinutes(5),

                        signingCredentials: credential
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }
    }
}
