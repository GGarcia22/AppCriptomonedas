namespace AppCriptomonedas.Models
{
    public class CuentaPesos : CuentaFiduciarias
    {
        public static double VALOR_DOLAR { get; set; } = 205;
        public static Moneda moneda { get; set; } = Moneda.PESO;

        public override double ConvertirMoneda(double monto, Moneda moneda)
        {
            double total = 0;
            if (moneda == Moneda.DOLAR)
            {
                total = monto * VALOR_DOLAR;
            }
            return total;
        }

        public override Moneda GetTipoMoneda()
        {
            return moneda;
        }

    }
}