using AutoMapper;
using DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class EntrarController : Controller
    {
        private MUsuario vloMUsuario;

        public EntrarController()
        {
            vloMUsuario = new MUsuario();
        }
        // GET: Iniciar
        public ActionResult IniciarSesion()
        {
            try
            {
                return PartialView("../../Views/Entrar/IniciarSesion");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult Registrarse()
        {
            try
            {
                return PartialView("../../Views/Entrar/Registrarse");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public JsonResult Registrar(Models.Usuario Usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json("Faltan datos o contiene errores la información ingresada.");
                }
                var _Usuario = Mapper.Map<DATA.Usuario>(Usuario);
                if (vloMUsuario.Agregar(_Usuario))
                {
                    return Json("REGISTRADO");
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

        public JsonResult IniciarSesioneEvt(Models.Usuario Usuario)
        {
            try
            {
                var _Usuario = Mapper.Map<DATA.Usuario>(Usuario);
                if (vloMUsuario.IniciarSesion(_Usuario))
                {
                    return Json("Biblioteca/Principal");
                }
                else
                {
                    return Json("Error");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
    }
}