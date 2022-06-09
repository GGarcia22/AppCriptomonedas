namespace AppCriptomonedas.Models.Transacciones
{
    public class Deposito : Transaccion
    {
        public string cuentaDestino { get; set; }
        public double monto { get; set; }

        public double RealizarTransaccion(double monto, string moneda, Cuenta cuenta)
        {
            return 0;
        }
    }
}
