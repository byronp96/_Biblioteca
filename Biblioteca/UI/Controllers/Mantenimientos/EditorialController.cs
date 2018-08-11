using AutoMapper;
using DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers.Mantenimientos
{
    public class EditorialController : Controller
    {
        private MEditorial vloMEditorial;

        public EditorialController()
        {
            vloMEditorial = new MEditorial();
        }
        // GET: Editorial
        public ActionResult Index()
        {
            try
            {
                var _Editorial = vloMEditorial.Lista();
                var vloLista = Mapper.Map<List<Models.Editorial>>(_Editorial);
                return PartialView("../../Views/Editorial/Index", vloLista);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: Editorial/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Editorial/Create
        public PartialViewResult Create()
        {
            return PartialView();
        }

        public JsonResult Guardar(Models.Editorial vloEditorial)
        {
            try
            {

                var _Editorial = Mapper.Map<DATA.Editorial>(vloEditorial);


                if (vloMEditorial.Agregar(_Editorial))
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

        // GET: Editorial/Edit/5
        public ActionResult Edit(int id = 1)
        {
            var vloEditorial = vloMEditorial.Buscar(id);
            var _Editorial = Mapper.Map<Models.Editorial>(vloEditorial);


            return PartialView("../../Views/Editorial/Edit", _Editorial);
        }

        //POST: Editorial/Edit/5
        public JsonResult Editar(Models.Editorial vloEditorial)
        {
            try
            {

                var _Editorial = Mapper.Map<DATA.Editorial>(vloEditorial);


                if (vloMEditorial.Actualizar(_Editorial))
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

        // GET: Editorial/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {

                if (vloMEditorial.Eliminar(id))
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