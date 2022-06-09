using System.ComponentModel.DataAnnotations;

namespace AppCriptomonedas.Models
{
    public class Usuario
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Escriba un nombre de usuario.")]
        [MinLength(5, ErrorMessage = "Escriba al menos 5 caracteres.")]
        [MaxLength(50, ErrorMessage = "Escriba un maximo de 50 caracteres.")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Escriba la contraseña.")]
        [MinLength(5, ErrorMessage = "Escriba al menos 5 caracteres.")]
        [MaxLength(50, ErrorMessage = "Escriba un maximo de 50 caracteres.")]
        public string userPass { get; set; }      

        public CuentaPesos? cuentaPesos { get; set; }

        public CuentaDolares? cuentaDolares { get; set; }

        public CuentaBtc? cuentaBtc { get; set; }
    }
}
