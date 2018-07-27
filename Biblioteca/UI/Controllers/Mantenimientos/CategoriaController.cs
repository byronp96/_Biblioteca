using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Metodos;

namespace UI.Controllers.Mantenimientos
{
    public class CategoriaController : Controller
    {
        private MCategoria vloMCategoria;

        public CategoriaController()
        {
           vloMCategoria = new MCategoria();
        }
        // GET: Categoria
        public ActionResult Index()
        {
            try
            {
                var _Categoria = vloMCategoria.Lista();
                var vloLista = Mapper.Map<List<Models.Categoria>>(_Categoria);
                return PartialView("../../Views/Categoria/Index" ,vloLista);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categoria/Create
        public ActionResult vCreate()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        public ActionResult Create(Models.Categoria vloCategoria)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var _Categoria = Mapper.Map<DATA.Categoria>(vloCategoria);

              
                vloMCategoria.Agregar(_Categoria);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Edit/5
        public ActionResult vEdit(int id=1)
        {
            var vloCategoria = vloMCategoria.Buscar(id);
            var _Categoria = Mapper.Map<Models.Categoria>(vloCategoria);
         
            
            return PartialView("../../Views/Categoria/Edit", _Categoria);
        }

        //POST: Categoria/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
