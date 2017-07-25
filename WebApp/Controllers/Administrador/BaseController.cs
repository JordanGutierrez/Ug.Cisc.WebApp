using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers.Administrador
{
    public class BaseController: Controller
    {
        public string GetApplicationUser()
        {
            return User.Identity.Name;
        }
    }
}