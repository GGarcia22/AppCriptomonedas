using System.ComponentModel.DataAnnotations;

namespace AppCriptomonedas.Models
{
    public abstract class CuentaFiduciarias : Cuenta
    {
        [Required(ErrorMessage = "Escriba el CBU de la cuenta.")]
        public string? CBU { get; set; }

        [Required(ErrorMessage = "Escriba el Alias de la cuenta.")]
        public string? alias { get; set; }

        public string? numeroDeCuenta { get; set; }


        public override abstract double ConvertirMoneda(double monto, Moneda moneda);

        public override string GetNumeroDeCuenta()
        {
            return CBU;
        }

        public override abstract Moneda GetTipoMoneda();

    }
}
