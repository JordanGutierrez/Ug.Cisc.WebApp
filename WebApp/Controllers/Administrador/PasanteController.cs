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
    public class PasanteController : Controller
    {
        IPersona personaDAO = new PersonaDAO();

        // GET: Pasante
        public ActionResult Index()
        {
            string mensaje = string.Empty;
            List<Persona> personas = personaDAO.getAllPersona(ref mensaje);
            if (mensaje != "OK")
                return View();
            else
                return View(personas.Where(p => p.RolID == 1));
        }

        // GET: Pasante/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Pasante/Create
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

        // GET: Pasante/Edit/5
        public ActionResult Edit(int id)
        {
            Persona persona = null;
            string mensaje = string.Empty;
            persona = personaDAO.getPersona(id, ref mensaje);
            return View(persona);
        }

        // POST: Pasante/Edit/5
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
