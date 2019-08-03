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
                
                double valorSuma = 0;
                int currentUserId = int.Parse (User.FindFirst (ClaimTypes.NameIdentifier).Value);

                //listo todos los valores
                List<Valor> valores = await _repo.Listar<Valor> (x => x.UsuarioId == currentUserId);

                if (valores.Where(x => x.Signo == null && x.Operacion == "Agregar").Count() <= 1) {
                    return BadRequest ("Por favor registre el operando");
                }

                Valor valor = new Valor () {
                    UsuarioId = currentUserId,
                    ValorOperacion = 0,
                    Operacion = "Sumar",
                    Signo = "+"
                };
                //agrego total de la suma
                await _repo.Agregar (valor);

                ///suma del total
                valorSuma = valores.Where(x => x.Signo == null && x.Operacion == "Agregar").Sum(x => x.ValorOperacion);

                valor.ValorOperacion = valorSuma;

                await _repo.Actualizar (valor);

                valores.Where(x => x.Signo == null && x.Operacion == "Agregar")
                .ToList().ForEach( x => {
                    x.Signo = "+";
                });

                await _repo.ActualizarLista (valores);

                //se agrega la suma como el nuevo operando
                valor = new Valor () {
                    UsuarioId = currentUserId,
                    ValorOperacion = valorSuma,
                    Operacion = "Agregar"
                };
                //agrego total de la suma
                await _repo.Agregar (valor);

                //obtener el usuario para actualizar el valor total
                Usuario usuario = await _repo.Obtener<Usuario>(x => x.UsuarioId == currentUserId);

                usuario.ValorTotal = valorSuma;

                await _repo.Actualizar(usuario);

                return Ok (true);
            } catch (Exception ex) {
                return BadRequest ("Error al sumar, comunicarse con el administrador " + ex.Message);
            }

        }

        [HttpGet ("Restar")]
        public async Task<IActionResult> Restar () {

            try {
                
                double valorResta = 0;
                int valorRestaIncial = 0;
                int currentUserId = int.Parse (User.FindFirst (ClaimTypes.NameIdentifier).Value);

                //listo todos los valores
                List<Valor> valores = await _repo.Listar<Valor> (x => x.UsuarioId == currentUserId);

                if (valores.Where(x => x.Signo == null && x.Operacion == "Agregar").Count() <= 1) {
                    return BadRequest ("Por favor registre otro operando");
                }

                Valor valor = new Valor () {
                    UsuarioId = currentUserId,
                    ValorOperacion = 0,
                    Operacion = "Resta",
                    Signo = "-"
                };
                //agrego total de la suma
                await _repo.Agregar (valor);

                ///suma del total
                valores.Where(x => x.Signo == null && x.Operacion == "Agregar")
                .ToList().ForEach(x => {
                    if (valorRestaIncial == 0) {
                        valorResta = x.ValorOperacion;
                        valorRestaIncial = 1;
                    } else {
                        valorResta = valorResta - x.ValorOperacion;   
                    }
                });

                valor.ValorOperacion = valorResta;

                await _repo.Actualizar (valor);

                valores.Where(x => x.Signo == null && x.Operacion == "Agregar")
                .ToList().ForEach( x => {
                    x.Signo = "-";
                });

                await _repo.ActualizarLista (valores);


                //se agrega la suma como el nuevo operando
                valor = new Valor () {
                    UsuarioId = currentUserId,
                    ValorOperacion = valorResta,
                    Operacion = "Agregar"
                };
                //agrego total de la suma
                await _repo.Agregar (valor);

                //obtener el usuario para actualizar el valor total
                Usuario usuario = await _repo.Obtener<Usuario>(x => x.UsuarioId == currentUserId);

                usuario.ValorTotal = valorResta;

                await _repo.Actualizar(usuario);

                return Ok (true);
            } catch (Exception ex) {
                return BadRequest ("Error al sumar, comunicarse con el administrador " + ex.Message);
            }

        }

        [HttpGet ("Multiplicar")]
        public async Task<IActionResult> Multiplicar () {

            try {
                
                double valorMultiplicacion = 1;
                int currentUserId = int.Parse (User.FindFirst (ClaimTypes.NameIdentifier).Value);

                //listo todos los valores
                List<Valor> valores = await _repo.Listar<Valor> (x => x.UsuarioId == currentUserId);

                if (valores.Where(x => x.Signo == null && x.Operacion == "Agregar").Count() <= 1) {
                    return BadRequest ("Por favor registre otro operando");
                }

                Valor valor = new Valor () {
                    UsuarioId = currentUserId,
                    ValorOperacion = 0,
                    Operacion = "Multiplicacion",
                    Signo = "*"
                };
                //agrego total de la suma
                await _repo.Agregar (valor);

                ///suma del total
                valores.Where(x => x.Signo == null && x.Operacion == "Agregar")
                .ToList().ForEach(x => {
                    valorMultiplicacion = valorMultiplicacion * x.ValorOperacion;
                });
                

                valor.ValorOperacion = valorMultiplicacion;

                await _repo.Actualizar (valor);

                valores.Where(x => x.Signo == null && x.Operacion == "Agregar")
                .ToList().ForEach( x => {
                    x.Signo = "*";
                });

                await _repo.ActualizarLista (valores);

                //se agrega la suma como el nuevo operando
                valor = new Valor () {
                    UsuarioId = currentUserId,
                    ValorOperacion = valorMultiplicacion,
                    Operacion = "Agregar"
                };
                //agrego total de la suma
                await _repo.Agregar (valor);

                //obtener el usuario para actualizar el valor total
                Usuario usuario = await _repo.Obtener<Usuario>(x => x.UsuarioId == currentUserId);

                usuario.ValorTotal = valorMultiplicacion;

                await _repo.Actualizar(usuario);

                return Ok (true);
            } catch (Exception ex) {
                return BadRequest ("Error al sumar, comunicarse con el administrador " + ex.Message);
            }

        }

        [HttpGet ("Dividir")]
        public async Task<IActionResult> Dividir () {

            try {
                
                double valorDivision = 1;
                double valorDivisionInicial = 0;
                int currentUserId = int.Parse (User.FindFirst (ClaimTypes.NameIdentifier).Value);

                //listo todos los valores
                List<Valor> valores = await _repo.Listar<Valor> (x => x.UsuarioId == currentUserId);

                if (valores.Where(x => x.Signo == null && x.Operacion == "Agregar").Count() <= 1) {
                    return BadRequest ("Por favor registre otro operando");
                }

                Valor valor = new Valor () {
                    UsuarioId = currentUserId,
                    ValorOperacion = 0,
                    Operacion = "Dividir",
                    Signo = "/"
                };
                //agrego total de la suma
                await _repo.Agregar (valor);

                ///suma del total
                valores.Where(x => x.Signo == null && x.Operacion == "Agregar")
                .ToList().ForEach(x => {
                    if (valorDivisionInicial == 0) {
                        valorDivision = x.ValorOperacion;
                        valorDivisionInicial = 1;
                    } else {
                        valorDivision = valorDivision / x.ValorOperacion;   
                    }
                });
                

                valor.ValorOperacion = valorDivision;

                await _repo.Actualizar (valor);

                valores.Where(x => x.Signo == null && x.Operacion == "Agregar")
                .ToList().ForEach( x => {
                    x.Signo = "/";
                });

                await _repo.ActualizarLista (valores);

                //se agrega la suma como el nuevo operando
                valor = new Valor () {
                    UsuarioId = currentUserId,
                    ValorOperacion = valorDivision,
                    Operacion = "Agregar"
                };
                //agrego total de la suma
                await _repo.Agregar (valor);

                //obtener el usuario para actualizar el valor total
                Usuario usuario = await _repo.Obtener<Usuario>(x => x.UsuarioId == currentUserId);

                usuario.ValorTotal = valorDivision;

                await _repo.Actualizar(usuario);

                return Ok (true);
            } catch (Exception ex) {
                return BadRequest ("Error al sumar, comunicarse con el administrador " + ex.Message);
            }

        }

        [HttpGet ("Potencia")]
        public async Task<IActionResult> Potencia () {

            try {
                
                double valorPotencia = 1;
                double valorPotenciaInicial = 0;
                int currentUserId = int.Parse (User.FindFirst (ClaimTypes.NameIdentifier).Value);

                //listo todos los valores
                List<Valor> valores = await _repo.Listar<Valor> (x => x.UsuarioId == currentUserId);

                

                if (valores.Where(x => x.Signo == null && x.Operacion == "Agregar").Count() <= 1) {
                    return BadRequest ("Por favor registre otro operando");
                }

                Valor valor = new Valor () {
                    UsuarioId = currentUserId,
                    ValorOperacion = 0,
                    Operacion = "Potencia",
                    Signo = "^"
                };
                //agrego total de la suma
                await _repo.Agregar (valor);

                ///suma del total
                valores.Where(x => x.Signo == null && x.Operacion == "Agregar")
                .ToList().ForEach(x => {
                    if (valorPotenciaInicial == 0) {
                        valorPotencia = x.ValorOperacion;
                        valorPotenciaInicial = 1;
                    } else {
                        valorPotencia = Math.Pow(valorPotencia, x.ValorOperacion); 
                    }
                });
                

                valor.ValorOperacion = valorPotencia;

                await _repo.Actualizar (valor);

                valores.Where(x => x.Signo == null && x.Operacion == "Agregar")
                .ToList().ForEach( x => {
                    x.Signo = "^";
                });

                await _repo.ActualizarLista (valores);

                //se agrega la suma como el nuevo operando
                valor = new Valor () {
                    UsuarioId = currentUserId,
                    ValorOperacion = valorPotencia,
                    Operacion = "Agregar"
                };
                //agrego total de la suma
                await _repo.Agregar (valor);

                //obtener el usuario para actualizar el valor total
                Usuario usuario = await _repo.Obtener<Usuario>(x => x.UsuarioId == currentUserId);

                usuario.ValorTotal = valorPotencia;

                await _repo.Actualizar(usuario);

                return Ok (true);
            } catch (Exception ex) {
                return BadRequest ("Error al sumar, comunicarse con el administrador " + ex.Message);
            }

        }
    }
}