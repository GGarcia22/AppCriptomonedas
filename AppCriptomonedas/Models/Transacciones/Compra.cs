namespace AppCriptomonedas.Models.Transacciones
{
    public class Compra : Transaccion
    {
        public string cuentaPesos { get; set; }
        public string cuentaDolares { get; set; }
        public Cuenta cuentaOrigen { get; set; }
        public double monto { get; set; }

        public double RealizarTransaccion(double monto, string moneda, Cuenta cuenta)
        {
            return 0;
        }

    }
}
