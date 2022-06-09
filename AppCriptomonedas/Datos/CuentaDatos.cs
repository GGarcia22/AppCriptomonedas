using AppCriptomonedas.Models;
using System.Data;
using System.Data.SqlClient;

namespace AppCriptomonedas.Datos
{
    public class CuentaDatos
    {

        public Cuenta obtenerCuenta(string numCuenta)
        {
            Cuenta oCuenta;
            oCuenta = ObtenerCuentaPesos(numCuenta);
            oCuenta = ObtenerCuentaDolares(numCuenta);
            oCuenta = ObtenerCuentaBtc(numCuenta);
            return oCuenta;
        }

        public CuentaPesos ObtenerCuentaPesos(string numCuenta)
        {
            var oCuenta = new CuentaPesos();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerCuentaPesos", conexion);
                cmd.Parameters.AddWithValue("numCuenta", numCuenta);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCuenta.id = Convert.ToInt32(dr["id"]);
                        oCuenta.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                        oCuenta.numeroDeCuenta = dr["nCuenta"].ToString();
                        oCuenta.saldo = Convert.ToDouble(dr["saldo"]);
                        oCuenta.CBU = dr["CBU"].ToString();
                        oCuenta.alias = dr["alias"].ToString();
                    }
                }
            }
            return oCuenta;
        }


        public CuentaDolares ObtenerCuentaDolares(string numCuenta)
        {
            var oCuenta = new CuentaDolares();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerCuentaDolares", conexion);
                cmd.Parameters.AddWithValue("numCuenta", numCuenta);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCuenta.id = Convert.ToInt32(dr["id"]);
                        oCuenta.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                        oCuenta.numeroDeCuenta = dr["nCuenta"].ToString();
                        oCuenta.saldo = Convert.ToDouble(dr["saldo"]);
                        oCuenta.CBU = dr["CBU"].ToString();
                        oCuenta.alias = dr["alias"].ToString();
                    }
                }
            }
            return oCuenta;
        }


        public CuentaBtc ObtenerCuentaBtc(string numCuenta)
        {
            var oCuenta = new CuentaBtc();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerCuentaBtc", conexion);
                cmd.Parameters.AddWithValue("numCuenta", numCuenta);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCuenta.id = Convert.ToInt32(dr["id"]);
                        oCuenta.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                        oCuenta.UUID = dr["UUID"].ToString();
                        oCuenta.saldo = Convert.ToDouble(dr["saldo"]);
                    }
                }
            }
            return oCuenta;
        }


        public bool SumarMontoCuenta(string numCuenta, string moneda, double monto)
        {
            bool respuesta = false;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SumarMontoCuenta", conexion);
                    cmd.Parameters.AddWithValue("numCuenta", numCuenta);
                    cmd.Parameters.AddWithValue("tipoCuenta", moneda.ToString());
                    cmd.Parameters.AddWithValue("monto", monto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
            }

            return respuesta;
        }


        public bool RestarMontoCuenta(string numCuenta, string moneda, double monto)
        {

            bool respuesta = false;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("RestarMontoCuenta", conexion);
                    cmd.Parameters.AddWithValue("numCuenta", numCuenta);
                    cmd.Parameters.AddWithValue("tipoCuenta", moneda.ToString());
                    cmd.Parameters.AddWithValue("monto", monto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
            }

            return respuesta;
        }


    }
}
