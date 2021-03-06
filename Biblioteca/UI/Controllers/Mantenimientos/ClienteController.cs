﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Metodos;
using AutoMapper;


namespace UI.Controllers.Mantenimientos
{
    public class ClienteController : Controller
    {
        private MCliente vloMCliente;

        public ClienteController()
        {
            vloMCliente = new MCliente();
        }

        // GET: Cliente
        public ActionResult Index()
        {
            try
            {
                var _Cliente = vloMCliente.Listar();
                var vloLista = Mapper.Map<List<Models.Cliente>>(_Cliente);
                return PartialView("../../Views/Cliente/Index", vloLista);
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
                      
        public JsonResult Guardar(Models.Cliente cliente)
        {
            try
            {                            
                var _Cliente = Mapper.Map<DATA.Cliente>(cliente);      
                if (vloMCliente.Agregar(_Cliente))
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
            var vloCliente = vloMCliente.Buscar(id);
            var _Cliente = Mapper.Map<Models.Cliente>(vloCliente);


            return PartialView("../../Views/Cliente/Edit", _Cliente);
        }

        public JsonResult Editar(Models.Cliente vloCliente)
        {
            try
            {

                var _Cliente = Mapper.Map<DATA.Cliente>(vloCliente);


                if (vloMCliente.Actualizar(_Cliente))
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

                if (vloMCliente.Eliminar(id))
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