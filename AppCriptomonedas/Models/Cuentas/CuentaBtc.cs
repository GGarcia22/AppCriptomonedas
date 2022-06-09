using System.ComponentModel.DataAnnotations;

namespace AppCriptomonedas.Models
{
    public class CuentaBtc : Cuenta
    {
        [Required(ErrorMessage = "Escriba el UUID de la cuenta.")]
        public string? UUID { get; set; }
        public static double VALOR_DOLAR { get; set; } = 0.000032;
        public static Moneda moneda { get; set; } = Moneda.BITCOIN;


        public override double ConvertirMoneda(double monto, Moneda moneda)
        {
            double total = 0;
            if (moneda == Moneda.DOLAR)
            {
                total = monto * VALOR_DOLAR;
            }
            return total;
        }

        public override string GetNumeroDeCuenta()
        {
            return UUID;
        }

        public override Moneda GetTipoMoneda()
        {
            return moneda;
        }

    }
}
