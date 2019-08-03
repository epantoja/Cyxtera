using System.Security.Claims;
using System.Threading.Tasks;
using API.Data;
using API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// clase que registra el valor por usuario
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    public class ValorController: ControllerBase
    {
        private readonly IRepositorio _repo;

        public ValorController (IRepositorio repo) {
            _repo = repo;
        }

        [HttpPost ("RegistrarValor")]
        public async Task<IActionResult> RegistrarValor ([FromBody] Valor valorOperacion) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            
            Valor valor = new Valor() {
                UsuarioId = currentUserId,
                ValorOperacion = valorOperacion.ValorOperacion,
                Operacion = "Agregar"
            };

            await _repo.Agregar (valor);

            return Ok (true);
        }

        [HttpGet ("ListarValores")]
        public async Task<IActionResult> ListarValores () {

            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            
            var valores = await _repo.Listar<Valor>(x=>x.UsuarioId == currentUserId);

            return Ok (valores);
        }
    }
}