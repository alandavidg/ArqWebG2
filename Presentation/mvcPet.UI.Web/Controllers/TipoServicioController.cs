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
    public class TipoServicioController : Controller
    {
        // GET: TipoServicio
        public ActionResult Index()
        {
            ITipoServicioService tiposervicio = new TipoServicioService();
            var lista = tiposervicio.ListarTodos();
            return View(lista);
        }

        // GET: TipoServicio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoServicio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoServicio/Create
        [HttpPost]
        public ActionResult Create(TipoServicio tiposervicio)
        {
            try
            {
                // TODO: Add insert logic here
                ITipoServicioService especie2 = new TipoServicioService();
                var agregar = especie2.Agregar(tiposervicio);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoServicio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Especie/Edit/5
        [HttpPost]
        public ActionResult Edit(TipoServicio tiposervicio)
        {

            try
            {
                // TODO: Add update logic here
                ITipoServicioService tiposervicio2 = new TipoServicioService();
                tiposervicio2.Editar(tiposervicio);
            }
            catch
            {

            }
            return RedirectToAction("Index");
        }

        // GET: TipoServicio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoServicio/Delete/5
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
