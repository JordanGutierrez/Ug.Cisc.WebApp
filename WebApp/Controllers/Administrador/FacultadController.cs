using DataAccess.Administracion;
using Entidades.Administracion;
using SqlDataAccess.Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers.Administrador
{
    public class FacultadController : Controller
    {
        IFacultadDAO facultadDAO = new FacultadDAO();

        // GET: Facultad
        public ActionResult Index()
        {
            string mensaje = string.Empty;
            List<Facultad> facultades = facultadDAO.getAllFacultad(ref mensaje);
            if (mensaje != "OK")
                return View();
            else
                return View(facultades);
        }

        // GET: Facultad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Facultad/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Facultad facultad)
        {
            try
            {
                string mensaje = string.Empty;
                facultadDAO.insertFacultad(facultad, "@Admin",ref mensaje);
                if (mensaje == "OK")
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Facultad/Edit/5
        public ActionResult Edit(int id)
        {
            string mensaje = string.Empty;
            Facultad facultad = facultadDAO.getFacultad(id, ref mensaje);
            return View(facultad);
        }

        // POST: Facultad/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Facultad facultad)
        {
            try
            {
                string mensaje = string.Empty;
                facultadDAO.updateFacultad(facultad, "@Admin", ref mensaje);
                if (mensaje == "OK")
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
