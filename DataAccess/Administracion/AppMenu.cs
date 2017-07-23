using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Administracion
{
    public class AppMenu
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public string Controlador { get; set; }

        public string Vista { get; set; }

        public bool Estado { get; set; }

        public int IdPadre { get; set; }

        public int Orden { get; set; }

        public int Nivel { get; set; }

        public static AppMenu CreateAppMenuFromDataRecord(IDataReader reader)
        {
            var appMenu = new AppMenu();

            appMenu.Id = int.Parse(reader["me_codigo"].ToString());
            appMenu.Titulo = reader["me_titulo"].ToString();
            appMenu.Descripcion = reader["me_descripcion"].ToString();
            appMenu.Controlador = reader["me_controlador"].ToString();
            appMenu.Vista = reader["me_vista"].ToString();
            appMenu.IdPadre = int.Parse(reader["me_idPadre"].ToString());
            appMenu.Orden = int.Parse(reader["me_orden"].ToString());
            appMenu.Nivel = int.Parse(reader["me_nivel"].ToString());

            return appMenu;
        }

    }
}
