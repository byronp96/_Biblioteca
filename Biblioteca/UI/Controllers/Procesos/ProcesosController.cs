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
        private MProceso vloMProceso;

        public ProcesosController()
        {
            vloMLibro = new MLibro();
            vloMProceso = new MProceso();
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

        public JsonResult AgregarLibroReserva(int idLibro)
        {
            var listaReservas = (List<int>)Session["listaReservados"];

            if (listaReservas.Find(item => item == idLibro) ==0)
            {
                listaReservas.Add(idLibro);
                return Json("El libro ha sido agregado a tu lista de reservas");
            }
            else
            {
                return Json(String.Format("El libro con el codigo {0} ya lo reservaste", idLibro));
            }
        }

        public ActionResult Reservas()
        {
            try
            {
                var listaReservas = (List<int>)Session["listaReservados"];
                string vlcLibros = "";

                foreach (int item in listaReservas)
                {
                    vlcLibros += item.ToString() + ","; 
                }
                var _Libro = vloMLibro.Reservas(vlcLibros.TrimEnd(','));

                var vloLista = Mapper.Map<List<Models.Libro>>(_Libro);
                return PartialView("../../Views/Procesos/Reservas", vloLista);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult GuardarReservas()
        {
            try
            {
                var listaReservas = (List<int>)Session["listaReservados"];
                string vlcLibros = "";

                int idPrestamo = vloMProceso.AgregarPrestamo(1,DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd"), 1) ;


                foreach (int item in listaReservas)
                {
                    vloMProceso.AgregarPrestamoLibro(idPrestamo, item);
                }
                
                return Json("Reservado Correctamente");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}