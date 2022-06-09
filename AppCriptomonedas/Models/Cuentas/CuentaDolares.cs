namespace AppCriptomonedas.Models
{
    public class CuentaDolares : CuentaFiduciarias
    {
        public static double VALOR_PESO { get; set; } = 0.0083;
        public static double VALOR_BTC { get; set; } = 31076.10;
        public static Moneda moneda { get; set; } = Moneda.DOLAR;

        public override double ConvertirMoneda(double monto, Moneda moneda)
        {
            double total = 0;
            if (moneda == Moneda.PESO)
            {
                total = monto * VALOR_PESO;
            }
            else if (moneda == Moneda.BITCOIN)
            {
                total = monto * VALOR_BTC;
            }
            return total;
        }

        public override Moneda GetTipoMoneda()
        {
            return moneda;
        }

    }
}
