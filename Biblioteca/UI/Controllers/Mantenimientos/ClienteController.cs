using System;
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
    }
}