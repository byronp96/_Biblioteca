using AutoMapper;
using DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class BibliotecaController : Controller
    {
        private MLibro vloMLibro;

        public BibliotecaController()
        {
            vloMLibro = new MLibro();
        }

        // GET: Biblioteca
        public ActionResult Biblioteca()
        {
            return View();

            //try
            //{
            //    var _Libro = vloMLibro.Lista();
            //    var vloLista = Mapper.Map<List<Models.Libro>>(_Libro);
            //    return PartialView("../../Views/Procesos/Index", vloLista);
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

        }

        public ActionResult Principal()
        {
            return View();
        }

        public PartialViewResult CargarBanner()
        {
            try
            {
                var _Libro = vloMLibro.Lista();
                var vloLista = Mapper.Map<List<Models.Libro>>(_Libro);
                return PartialView("../../Views/Procesos/Index", vloLista);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}