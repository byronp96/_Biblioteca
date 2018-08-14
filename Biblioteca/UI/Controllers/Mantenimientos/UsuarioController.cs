using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Metodos;
using AutoMapper;

namespace UI.Controllers.Mantenimientos
{
    public class UsuarioController : Controller
    {
        private MUsuario vloMUsuario;

        public UsuarioController()
        {
            vloMUsuario = new MUsuario();
        }

        // GET: Usuario
        public ActionResult Index()
        {
            try
            {
                var _Usuario = vloMUsuario.Listar();
                var vloLista = Mapper.Map<List<Models.Usuario>>(_Usuario);
                return PartialView("../../Views/Usuario/Index", vloLista);
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

        public JsonResult Guardar(Models.Usuario Usuario)
        {
            try
            {
                var _Usuario = Mapper.Map<DATA.Usuario>(Usuario);
                if (vloMUsuario.Agregar(_Usuario))
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

        public ActionResult Edit(string id = "1")
        {
            var vloUsuario = vloMUsuario.Buscar(id);
            var _Usuario = Mapper.Map<Models.Usuario>(vloUsuario);


            return PartialView("../../Views/Usuario/Edit", _Usuario);
        }

        public JsonResult Editar(Models.Usuario vloUsuario)
        {
            try
            {

                var _Usuario = Mapper.Map<DATA.Usuario>(vloUsuario);


                if (vloMUsuario.Actualizar(_Usuario))
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

        public ActionResult Delete(string id)
        {
            try
            {

                if (vloMUsuario.Eliminar(id))
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