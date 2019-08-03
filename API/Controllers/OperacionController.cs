using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Data;
using API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route ("api/[controller]")]
    public class OperacionController: ControllerBase
    {
        private readonly IRepositorio _repo;

        public OperacionController (IRepositorio repo) {
            _repo = repo;
        }   


        [HttpGet ("Sumar")]
        public async Task<IActionResult> Sumar () {

            try {
                
                int currentUserId = int.Parse (User.FindFirst (ClaimTypes.NameIdentifier).Value);

                Valor valor = new Valor () {
                    UsuarioId = currentUserId,
                    ValorOperacion = 0,
                    Operacion = "Sumar"
                };

                await _repo.Agregar (valor);

                

                return Ok (true);
            } catch (Exception ex) {
                return BadRequest ("Error al sumar, comunicarse con el administrador " + ex.Message);
            }

        }
    }
}