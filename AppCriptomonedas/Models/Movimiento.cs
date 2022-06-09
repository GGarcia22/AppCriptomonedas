namespace AppCriptomonedas.Models
{
    public class Movimiento
    {
        public int Id { get; set; }

        public string? tipoDeMovimiento { get; set; }

        public double monto { get; set; }

        public string? cuentaOrigen { get; set; }

        public string? cuentaDestino { get; set; }
    }
}
