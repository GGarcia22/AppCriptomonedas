namespace AppCriptomonedas.Models
{
    public abstract class Cuenta 
    {
        public int id { get; set; }

        public int idUsuario { get; set; }

        public double? saldo { get; set; }

        public List<Movimiento> movimientos { get; set; }


        public abstract double ConvertirMoneda(double monto, Moneda moneda);

        public abstract string GetNumeroDeCuenta();

        public abstract Moneda GetTipoMoneda();

    }
}
