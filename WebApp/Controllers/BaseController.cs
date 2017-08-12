using DataAccess.Administracion;
using Entidades.Administracion;
using SqlDataAccess.Administracion;
using SqlDataAccess.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class BaseController: Controller
    {
        IAppMenuDAO appmenuDAO = new AppMenuDAO();

        public string GetApplicationUser()
        {
            return User.Identity.Name;
        }

        public ActionResult Menu()
        {
            if (Request.IsAuthenticated)
            {
                var claimsIdentity = ClaimsPrincipal.Current.Identities.FirstOrDefault();
                var aux = claimsIdentity.Claims.FirstOrDefault(c => c.Type == "RolID");
                string mensaje = string.Empty;
                List<AppMenu> menus = appmenuDAO.getAllbyRol(int.Parse(aux.Value), ref mensaje);
                return PartialView("_Menu", menus);
            }
            return null;
        }
    }
}