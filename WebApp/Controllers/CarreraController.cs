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
    public class CarreraController : BaseController
    {
        ICarreraDAO carreraDAO = new CarreraDAO();
        IFacultadDAO facultadDAO = new FacultadDAO();

        // GET: Carrera
        [AppAuthorize("00003")]
        public ActionResult Index()
        {
            string mensaje = string.Empty;
            List<Carrera> carreras = carreraDAO.getAllCarrera(ref mensaje);
            if (mensaje != "OK")
                return View();
            else
                return View(carreras);
        }

        // GET: Carrera/Create
        public ActionResult Create()
        {
            string mensaje = string.Empty;
            List<Facultad> facultades = facultadDAO.getAllFacultad(ref mensaje);
            if (mensaje == "OK")
            {
                ViewBag.Facultades = facultades.Where(f => f.Estado);
                return View();
            }
            else
                return RedirectToAction("Index");
        }

        // POST: Carrera/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Carrera carrera)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Datos Enviados Incorrectos");
                    return View(carrera);
                }
                string mensaje = string.Empty;
                carreraDAO.insertCarrera(carrera, GetApplicationUser(), ref mensaje);
                if (mensaje == "OK")
                    return RedirectToAction("Index");
                else
                    return View(carrera);
            }
            catch (Exception ex)
            {
                return View(carrera);
            }
        }

        // GET: Carrera/Edit/5
        public ActionResult Edit(int id)
        {
            string mensaje = string.Empty;
            Carrera carrera = carreraDAO.getCarrera(id, ref mensaje);
            List<Facultad> facultades = facultadDAO.getAllFacultad(ref mensaje);
            ViewBag.Facultades = facultades.Where(f => f.Estado);
            return View(carrera);
        }

        // POST: Carrera/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Carrera carrera)
        {
            try
            {
                string mensaje = string.Empty;
                carreraDAO.updateCarrera(carrera, GetApplicationUser(), ref mensaje);
                if (mensaje == "OK")
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
