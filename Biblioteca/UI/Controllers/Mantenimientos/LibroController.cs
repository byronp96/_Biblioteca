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
        private MCategoria vloCategoria;
        private MEditorial vloEditorial;

        public LibroController()
        {
            vloMLibro = new MLibro();
            vloCategoria = new MCategoria();
            vloEditorial = new MEditorial();

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

        public JsonResult Guardar(Models.Libro vloLibro, string pvcAutores, string pvcCategorias)
        {
            try
            {
                List<int> obj = Newtonsoft.Json.JsonConvert.DeserializeObject <List<int>>(pvcAutores);
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


        public ActionResult CargarAutores(string id)
        {
            try
            {
                var _Libro = vloMLibro.ListaAutores(id);
                var vloLista = Mapper.Map<List<Models.LibroXAutor>>(_Libro);
                return PartialView("../../Views/Libro/CargarAutores", vloLista);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult CargarCategorias(string id)
        {
            try
            {
                var _Libro = vloCategoria.ListaCategorias(id);
                var vloLista = Mapper.Map<List<Models.LibroXCategoria>>(_Libro);
                return PartialView("../../Views/Libro/CargarCategorias", vloLista);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult CargarEditoriales(string id)
        {
            try
            {
                var _Libro = vloEditorial.ListaEditorial(id);
                var vloLista = Mapper.Map<List<Models.LibroXEditorial>>(_Libro);
                return PartialView("../../Views/Libro/CargarEditoriales", vloLista);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public JsonResult GuardarLibroAutor(Models.LibroXAutor vloLibro)
        {
            try
            {

                var _Libro = Mapper.Map<DATA.LibroXAutor>(vloLibro);


                if (vloMLibro.AgregarAutorLibro(_Libro))
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
    }
}