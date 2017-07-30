using DataAccess.Administracion;
using Entidades.Administracion;
using SqlDataAccess.Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ProcesoController : Controller
    {
        IProcesoDAO procesoDAO = new ProcesoDAO();

        // GET: Proceso
        public ActionResult Index()
        {
            string mensaje = string.Empty;
            List<Proceso> procesos = procesoDAO.getAllProceso(ref mensaje);
            if (mensaje != "OK")
                return View();
            else
                return View(procesos);
        }

        // GET: Proceso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proceso/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proceso/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Proceso/Edit/5
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
    }
}
