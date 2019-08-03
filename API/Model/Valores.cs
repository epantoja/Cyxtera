using System.ComponentModel.DataAnnotations;

namespace API.Model
{

    /// <summary>
    /// Guarda los valores que digita el usuario
    /// </summary>
    public class Valor
    {

        /// <summary>
        /// Llave de la tabla
        /// </summary>
        /// <value></value>
        public int ValorId { get; set; }

        /// <summary>
        /// Valor de operacion
        /// </summary>
        /// <value>Valor</value>
        [Display(Name = "Valor de la operacion")]
        public double  ValorOperacion { get; set; }

        /// <summary>
        /// Operacion del usuario
        /// </summary>
        /// <value></value>
        [Display(Name = "Operacion")]
        public string Operacion { get; set; }

        /// <summary>
        /// Referencia del usuario
        /// </summary>
        /// <value>Usuario</value>
        public Usuario Usuario { get; set; }
        /// <summary>
        /// Llave de la tabla usuario
        /// </summary>
        /// <value>llave</value>
        public int UsuarioId { get; set; }
    }
}