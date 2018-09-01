using AutoMapper;
using DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers.Procesos
{
    public class ProcesosController : Controller
    {
        private MLibro vloMLibro;

        public ProcesosController()
        {
            vloMLibro = new MLibro();
        }

        // GET: Procesos
        public ActionResult Index()
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

        public ActionResult ListarLibros()
        {
            try
            {
                var _Libro = vloMLibro.Lista();
                var vloLista = Mapper.Map<List<Models.Libro>>(_Libro);
                return PartialView("../../Views/Procesos/ListarLibros", vloLista);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}