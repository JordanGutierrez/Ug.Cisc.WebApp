using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Administracion
{
    public class Usuario
    {
        public string UserName { get; set; }

        public string Clave { get; set; }

        public bool Estado { get; set; }

        public int RolID { get; set; }

        public string MaqSitio { get; set; }

        public string Maquina { get; set; }

        public static Usuario CreateUsuarioFromDataRecord(IDataRecord dr)
        {
            Usuario usuario = new Usuario();

            usuario.UserName = dr["Alias"].ToString();
            usuario.Clave = dr["Clave"].ToString();
            usuario.Estado = bool.Parse(dr["Estado"].ToString());
            usuario.RolID = int.Parse(dr["RolID"].ToString());

            return usuario;
        }
    }
}
