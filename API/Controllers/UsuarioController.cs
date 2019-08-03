using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    /// <summary>
    /// Clase usuario, registra el token
    /// </summary>
    [Route("api/[controller]")]
    public class UsuarioController: ControllerBase
    {
        private readonly IRepositorio _repo;
        private readonly IConfiguration _configuration;

        public UsuarioController(IRepositorio repo, IConfiguration configuration)
        {
            this._repo = repo;
            _configuration = configuration;
        }

        /// <summary>
        /// Metodo que guarda el usuario que se va loguear
        /// </summary>
        /// <param name="usuario">Token a Guardar</param>
        [HttpGet ("Registrar")]
        public async Task<ActionResult> Registrar()
        {

            Usuario crearUsuario = new Usuario {
                Token = Path.GetRandomFileName()
            };

            var userCreate = await _repo.Agregar (crearUsuario);

            var tokenHandler = new JwtSecurityTokenHandler ();
            var key = Encoding.ASCII.GetBytes (_configuration.GetSection ("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity (new Claim[] {
                new Claim (ClaimTypes.NameIdentifier, userCreate.UsuarioId.ToString())
                }),
                Expires = DateTime.Now.AddDays (1),
                SigningCredentials = new SigningCredentials (new SymmetricSecurityKey (key),
                SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken (tokenDescriptor);
            var tokenString = tokenHandler.WriteToken (token);

            crearUsuario = new Usuario {
                Token = tokenString
            };
            
            bool userUpdate = await _repo.Actualizar (userCreate.UsuarioId, crearUsuario);

            return Ok (new { tokenString });
        }
    }
}