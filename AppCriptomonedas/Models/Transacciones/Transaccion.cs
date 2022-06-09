namespace AppCriptomonedas.Models
{
    public interface Transaccion 
    {
        public abstract double RealizarTransaccion(double monto, string moneda, Cuenta cuenta);

    }
}
