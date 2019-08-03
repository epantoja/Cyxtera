namespace API.Model
{
    /// <summary>
    /// Usuario Logueaddo
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Llave del usuario
        /// </summary>
        /// <value></value>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Id del usuario logueado
        /// </summary>
        /// <value>Token llave unica</value>
        public string Token { get; set; }
    }
}