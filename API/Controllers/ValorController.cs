using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Data;
using API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

                return Ok (valores.OrderByDescending(x => x.ValorId));
            } catch (Exception ex) {
                return BadRequest ("Error al listar los valores, comunicarse con el administrador " + ex.Message);
            }

        }

        [HttpGet ("ListarHistorial")]
        public async Task<IActionResult> ListarHistorial () {

            try {
                int currentUserId = int.Parse (User.FindFirst (ClaimTypes.NameIdentifier).Value);

                List<Usuario> historial = await _repo.Listar<Usuario> (x => x.Token != "" && x.UsuarioId != currentUserId);

                return Ok (historial.OrderByDescending(x => x.UsuarioId));
            } catch (Exception ex) {
                return BadRequest ("Error al listar los historiales, comunicarse con el administrador " + ex.Message);
            }

        }

        [HttpGet ("ObtenerHistorico/{historicoId}")]
        public async Task<IActionResult> ObtenerHistorico (int historicoId) {

            try {
                
                List<Valor> historial = await _repo.Listar<Valor> (x => x.UsuarioId == historicoId);

                return Ok (historial.OrderByDescending(x => x.ValorId));
            } catch (Exception ex) {
                return BadRequest ("Error al listar los historiales, comunicarse con el administrador " + ex.Message);
            }

        }
    }
}