using AppCriptomonedas.Models;
using System.Data;
using System.Data.SqlClient;

namespace AppCriptomonedas.Datos
{
    public class UsuarioDatos
    {


        public Usuario ValidarUsuario(string user, string pass)
        {
            var oUsuario = new Usuario();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ValidarUsuario", conexion);
                cmd.Parameters.AddWithValue("User", user);
                cmd.Parameters.AddWithValue("Pass", pass);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oUsuario.id = Convert.ToInt32(dr["id"]);
                        oUsuario.userName = dr["usuario"].ToString();
                        oUsuario.userPass = dr["contraseña"].ToString();
                    }
                }
            }
            return HabilitarCuentasUsuario(oUsuario);
        }


        private Usuario HabilitarCuentasUsuario(Usuario oUsuario)
        {
            oUsuario.cuentaPesos = ObtenerCuentaPesosDe(oUsuario.id);
            oUsuario.cuentaDolares = ObtenerCuentaDolaresDe(oUsuario.id);
            oUsuario.cuentaBtc = ObtenerCuentaBtcDe(oUsuario.id);
            return oUsuario;
        }


        public CuentaPesos ObtenerCuentaPesosDe(int idUsuario)
        {
            var oCuenta = new CuentaPesos();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerCuentaPesosDe", conexion);
                cmd.Parameters.AddWithValue("idUsuario", idUsuario);
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


        public CuentaDolares ObtenerCuentaDolaresDe(int idUsuario)
        {
            var oCuenta = new CuentaDolares();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerCuentaDolaresDe", conexion);
                cmd.Parameters.AddWithValue("idUsuario", idUsuario);
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


        public CuentaBtc ObtenerCuentaBtcDe(int idUsuario)
        {
            var oCuenta = new CuentaBtc();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerCuentaBtcDe", conexion);
                cmd.Parameters.AddWithValue("idUsuario", idUsuario);
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

     
    }
}
