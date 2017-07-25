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
    public class TutorController : BaseController
    {
        IPersonaDAO personaDAO = new PersonaDAO();
        ICarreraDAO carreraDAO = new CarreraDAO();

        // GET: Tutor
        public ActionResult Index()
        {
            string mensaje = string.Empty;
            List<Persona> personas = personaDAO.getAllPersona(ref mensaje);
            if (mensaje != "OK")
                return View();
            else
                return View(personas.Where(p => p.RolID == 2));
        }

        // GET: Tutor/Create
        public ActionResult Create()
        {
            string mensaje = string.Empty;
            List<Carrera> carreras = carreraDAO.getAllCarrera(ref mensaje);
            Persona persona = new Persona();
            persona.RolID = 2;
            ViewBag.Carreras = carreras.Where(c => c.Estado);
            return View(persona);
        }

        // POST: Tutor/Create
        [HttpPost]
        public ActionResult Create(Persona persona)
        {
            try
            {
                string mensaje = string.Empty;
                personaDAO.insertPersona(persona, GetApplicationUser(), ref mensaje);
                if (mensaje == "OK")
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Tutor/Edit/5
        public ActionResult Edit(int id)
        {
            Persona persona = null;
            string mensaje = string.Empty;
            List<Carrera> carreras = carreraDAO.getAllCarrera(ref mensaje);
            persona = personaDAO.getPersona(id, ref mensaje);
            ViewBag.Carreras = carreras.Where(c => c.Estado);
            return View(persona);
        }

        // POST: Tutor/Edit/5
        [HttpPost]
        public ActionResult Edit(Persona persona)
        {
            try
            {
                string mensaje = string.Empty;
                personaDAO.updatePersona(persona, GetApplicationUser(), ref mensaje);
                if (mensaje == "OK")
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
