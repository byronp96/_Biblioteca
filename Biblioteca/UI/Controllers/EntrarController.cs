using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class EntrarController : Controller
    {
        // GET: Iniciar
        public ActionResult IniciarSesion()
        {
            return View();
        }

        public ActionResult Registrarse()
        {
            return View();
        }
    }
}