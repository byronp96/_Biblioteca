using AutoMapper;
using DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers.Mantenimientos
{
    public class AutorController : Controller
    {

            private MAutor vloMAutor;

        public AutorController()
        {
            vloMAutor = new MAutor();
        }
        // GET: Autor
        public ActionResult Index()
        {
            try
            {
                var _Autor = vloMAutor.Lista();
                var vloLista = Mapper.Map<List<Models.Autor>>(_Autor);
                return PartialView("../../Views/Autor/Index", vloLista);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: Autor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Autor/Create
        public PartialViewResult Create()
        {
            return PartialView();
        }

        public JsonResult Guardar(Models.Autor vloAutor)
        {
            try
            {

                var _Autor = Mapper.Map<DATA.Autor>(vloAutor);


                if (vloMAutor.Agregar(_Autor))
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

        // GET: Autor/Edit/5
        public ActionResult Edit(int id = 1)
        {
            var vloAutor = vloMAutor.Buscar(id);
            var _Autor = Mapper.Map<Models.Autor>(vloAutor);
            //_Autor.aut_foto = Convert.FromBase64String(_Autor._aut_foto);

            return PartialView("../../Views/Autor/Edit", _Autor);
        }

        //POST: Autor/Edit/5
        public JsonResult Editar(Models.Autor vloAutor)
        {
            try
            {

                var _Autor = Mapper.Map<DATA.Autor>(vloAutor);


                if (vloMAutor.Actualizar(_Autor))
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

        // GET: Autor/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {

                if (vloMAutor.Eliminar(id))
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