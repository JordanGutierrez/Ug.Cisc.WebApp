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
    public class PersonaController : Controller
    {
        IPersona personaDAO = new PersonaDAO();

        // GET: Pasantes
        public ActionResult IndexPasantes()
        {
            string mensaje = string.Empty;
            List<Persona> personas = personaDAO.getAllPersona(ref mensaje);
            if (mensaje != "OK")
                return View();
            else
                return View(personas.Where(p => p.TipoPersona == 1));
        }

        // GET: Tutores
        public ActionResult IndexTutores()
        {
            string mensaje = string.Empty;
            List<Persona> personas = personaDAO.getAllPersona(ref mensaje);
            if (mensaje != "OK")
                return View();
            else
                return View(personas.Where(p => p.TipoPersona == 2));
        }

        // GET: Persona/Create
        public ActionResult CreatePasante()
        {

            return View();
        }

        // POST: Persona/Create
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

        // GET: Persona/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Persona/Edit/5
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

        // GET: Persona/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Persona/Delete/5
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
