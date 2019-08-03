using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Data;
using API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    /// <summary>
    /// clase que registra el valor por usuario
    /// </summary>
    [Authorize]
    [Route ("api/[controller]")]
    public class ValorController : ControllerBase {
        private readonly IRepositorio _repo;

        public ValorController (IRepositorio repo) {
            _repo = repo;
        }

        [HttpPost ("RegistrarValor")]
        public async Task<IActionResult> RegistrarValor ([FromBody] Valor valorOperacion) {

            try {
                if (!ModelState.IsValid)
                    return BadRequest (ModelState);

                int currentUserId = int.Parse (User.FindFirst (ClaimTypes.NameIdentifier).Value);

                Valor valor = new Valor () {
                    UsuarioId = currentUserId,
                    ValorOperacion = valorOperacion.ValorOperacion,
                    Operacion = "Agregar"
                };

                await _repo.Agregar (valor);

                

                return Ok (true);
            } catch (Exception ex) {
                return BadRequest ("Error al agregar un valor, comunicarse con el administrador " + ex.Message);
            }

        }

        [HttpGet ("ListarValores")]
        public async Task<IActionResult> ListarValores () {

            try {
                int currentUserId = int.Parse (User.FindFirst (ClaimTypes.NameIdentifier).Value);

                List<Valor> valores = await _repo.Listar<Valor> (x => x.UsuarioId == currentUserId);

                return Ok (valores);
            } catch (Exception ex) {
                return BadRequest ("Error al listar los valores, comunicarse con el administrador " + ex.Message);
            }

        }
    }
}