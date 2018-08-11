using AutoMapper;
using DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers.Mantenimientos
{
    public class LibroController : Controller
    {
        private MLibro vloMLibro;

        public LibroController()
        {
            vloMLibro = new MLibro();
        }
        // GET: Libro
        public ActionResult Index()
        {
            try
            {
                var _Libro = vloMLibro.Lista();
                var vloLista = Mapper.Map<List<Models.Libro>>(_Libro);
                return PartialView("../../Views/Libro/Index", vloLista);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: Libro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Libro/Create
        public PartialViewResult Create()
        {
            return PartialView();
        }

        public JsonResult Guardar(Models.Libro vloLibro)
        {
            try
            {

                var _Libro = Mapper.Map<DATA.Libro>(vloLibro);


                if (vloMLibro.Agregar(_Libro))
                {
                    return Json("Agregado");
                }
                else
                {
                    return Json("Error");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        // GET: Libro/Edit/5
        public ActionResult Edit(int id = 1)
        {
            var vloLibro = vloMLibro.Buscar(id);
            var _Libro = Mapper.Map<Models.Libro>(vloLibro);
            _Libro.lib_portada = Convert.FromBase64String(_Libro._lib_portada);

            return PartialView("../../Views/Libro/Edit", _Libro);
        }

        //POST: Libro/Edit/5
        public JsonResult Editar(Models.Libro vloLibro)
        {
            try
            {

                var _Libro = Mapper.Map<DATA.Libro>(vloLibro);


                if (vloMLibro.Actualizar(_Libro))
                {
                    return Json("Actualizado");
                }
                else
                {
                    return Json("Error");
                }
                return Json("Actualizado");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        // GET: Libro/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {

                if (vloMLibro.Eliminar(id))
                {
                    return Json("Eliminado");
                }
                else
                {
                    return Json("Error");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}