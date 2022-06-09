namespace AppCriptomonedas.Models.Transacciones
{
    public class Transferencia : Transaccion
    {
        public Cuenta cuentaOrigen { get; set; }
        public string cuentaDestino { get; set; }
        public double monto { get; set; }
        public double RealizarTransaccion(double monto, string moneda, Cuenta cuenta)
        {
            return 0;
        }
    }
}
