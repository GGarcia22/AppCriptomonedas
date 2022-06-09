using AppCriptomonedas.Datos;
using AppCriptomonedas.Models;
using AppCriptomonedas.Models.Transacciones;
using Microsoft.AspNetCore.Mvc;

namespace AppCriptomonedas.Controllers
{
    public class CuentaController : Controller
    {
        private CuentaDatos cuentaDatos = new CuentaDatos();
        private UsuarioDatos usuarioDatos = new UsuarioDatos();
        private Usuario usuario = new Usuario();

        public IActionResult InicioSesion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InicioSesion(Usuario oUsuario)
        {  
            if (!ModelState.IsValid)
            {
                return View();
            }

            usuario = usuarioDatos.ValidarUsuario(oUsuario.userName, oUsuario.userPass);

            if (usuario != null)
                return RedirectToAction("MenuPrincipal");
            else
                return View();
        }

        public IActionResult MenuPrincipal()
        {
            return View();
        }


        public IActionResult MisCuentas()
        {
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Comprar(Cuenta cuenta)
        {
            var compra = new Compra();
            compra.cuentaOrigen = cuenta;
            return View(compra);
        }

        [HttpPost]
        public IActionResult Comprar(Compra c)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Compra");
            }

            var cuentaPesos = cuentaDatos.ObtenerCuentaPesos(c.cuentaPesos);
            var cuentaDolares = cuentaDatos.ObtenerCuentaPesos(c.cuentaDolares);
            cuentaDatos.RestarMontoCuenta();
            var respuesta = cuentaDatos.SumarMontoCuenta(c.cuentaOrigen.GetNumeroDeCuenta(), c.cuentaOrigen.GetTipoMoneda().ToString(), c.cuentaOrigen.ConvertirMoneda(c.monto, c.cuentaOrigen.GetTipoMoneda()));

            if (respuesta)
                return RedirectToAction("MisCuentas");
            else
                return View();
        }



        [HttpPost]
        public IActionResult Transferencia(Cuenta cuenta)
        {
            var transferencia = new Transferencia();
            transferencia.cuentaOrigen = cuenta;
            return View(transferencia);
        }

        [HttpPost]
        public IActionResult Transferencia(Transferencia t)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Transferencia");
            }

            var cuentaDestino = cuentaDatos.obtenerCuenta(t.cuentaDestino);
            var respuesta = cuentaDatos.RestarMontoCuenta(t.cuentaOrigen.GetNumeroDeCuenta(), t.cuentaOrigen.GetTipoMoneda().ToString(), t.monto);
            respuesta = cuentaDatos.SumarMontoCuenta(t.cuentaDestino, cuentaDestino.GetTipoMoneda().ToString(), cuentaDestino.ConvertirMoneda(t.monto, cuentaDestino.GetTipoMoneda()));

            if (respuesta)
                return RedirectToAction("MisCuentas");
            else
                return View();
        }


        public IActionResult Deposito()
        {
            var deposito = new Deposito();
            return View(deposito);
        }

        [HttpPost]
        public IActionResult Deposito(Deposito d)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Deposito");
            }

            var cuentaDestino = cuentaDatos.obtenerCuenta(d.cuentaDestino);
            var respuesta = cuentaDatos.SumarMontoCuenta(d.cuentaDestino, cuentaDestino.GetTipoMoneda().ToString(), d.monto);

            if (respuesta)
                return RedirectToAction("MisCuentas");
            else
                return View();
        }

   
        public IActionResult Extraccion()
        {
            var extraccion = new Extraccion();
            return View(extraccion);
        }


        [HttpPost]
        public IActionResult Extraccion(Extraccion e)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Extraccion");
            }

            var cuentaOrigen = cuentaDatos.obtenerCuenta(e.cuentaOrigen);
            var respuesta = cuentaDatos.RestarMontoCuenta(e.cuentaOrigen, cuentaOrigen.GetTipoMoneda().ToString(), e.monto);

            if (respuesta)
                return RedirectToAction("MisCuentas");
            else
                return View();
        }


        //public IActionResult VerMovimientos()
        //{

        //}
    }
}
