using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Metodos;
using AutoMapper;

namespace UI.Controllers.Mantenimientos
{
    public class RecargoController : Controller
    {
        private MRecargo vloMRecargo;

        public RecargoController()
        {
            vloMRecargo = new MRecargo();
        }

        // GET: Recargo
        public ActionResult Index()
        {
            try
            {
                var _Recargo = vloMRecargo.Listar();
                var vloLista = Mapper.Map<List<Models.Recargo>>(_Recargo);
                return PartialView("../../Views/Recargo/Index", vloLista);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public PartialViewResult Create()
        {
            return PartialView();
        }

        public JsonResult Guardar(Models.Recargo Recargo)
        {
            try
            {
                var _Recargo = Mapper.Map<DATA.Recargo>(Recargo);
                if (vloMRecargo.Agregar(_Recargo))
                {
                    return Json("AGREGADO");
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

        public ActionResult Edit(int id = 1)
        {
            var vloRecargo = vloMRecargo.Buscar(id);
            var _Recargo = Mapper.Map<Models.Recargo>(vloRecargo);


            return PartialView("../../Views/Recargo/Edit", _Recargo);
        }

        public JsonResult Editar(Models.Recargo vloRecargo)
        {
            try
            {

                var _Recargo = Mapper.Map<DATA.Recargo>(vloRecargo);


                if (vloMRecargo.Actualizar(_Recargo))
                {
                    return Json("ACTUALIZADO");
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

        public ActionResult Delete(int id)
        {
            try
            {

                if (vloMRecargo.Eliminar(id))
                {
                    return Json("ELIMINADO");
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