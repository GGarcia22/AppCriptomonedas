using AppCriptomonedas.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppCriptomonedas.Controllers
{
    public class RegistroController : Controller
    {
        public IActionResult RegistrarUsuario()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult RegistrarUsuario(Usuario usuario)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    var respuesta = usuario.

        //    if (usuario)
        //        return RedirectToAction("InicioSesion");
        //    else
        //        return View();
        //}

    }
}
