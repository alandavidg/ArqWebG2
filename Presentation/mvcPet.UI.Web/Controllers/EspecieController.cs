using mvcPet.Entities;
using mvcPet.Services;
using mvcPet.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcPet.UI.Web.Controllers
{
    public class EspecieController : Controller
    {
        // GET: Especie
        public ActionResult Index()
        {
            IEspecieService especie = new EspecieService();
            var lista = especie.ListarTodos();
            return View(lista);
        }

        // GET: Especie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Especie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Especie/Create
        [HttpPost]
        public ActionResult Create(Especie especie)
        {
            try
            {
                // TODO: Add insert logic here
                IEspecieService especie2 = new EspecieService();
                var agregar = especie2.Agregar(especie);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Especie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Especie/Edit/5
        [HttpPost]
        public void Edit(Especie especie)
        {

            try
            {
                // TODO: Add update logic here
                IEspecieService especie2 = new EspecieService();
                especie2.Editar(especie);
            }
            catch
            {
                
            }
        }

        // GET: Especie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Especie/Delete/5
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
