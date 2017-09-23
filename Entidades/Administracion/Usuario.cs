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
        public int UsuarioID { get; set; }

        public string UserName { get; set; }

        public string Clave { get; set; }

        public string Cedula { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public int RolID { get; set; }

        public int HorarioID { get; set; }

        public int CarreraID { get; set; }

        public bool Estado { get; set; }

        public string MaqSitio { get; set; }

        public string Maquina { get; set; }

        public static Usuario CreateUsuarioFromDataRecord(IDataRecord dr)
        {
            Usuario usuario = new Usuario();

            usuario.UsuarioID = int.Parse(dr["UsuarioID"].ToString());
            usuario.UserName = dr["UserName"].ToString();
            usuario.Clave = dr["Clave"].ToString();
            usuario.Cedula = dr["Cedula"].ToString();
            usuario.Nombres = dr["Nombres"].ToString();
            usuario.Apellidos = dr["Apellidos"].ToString();
            usuario.Correo = dr["Correo"].ToString();
            usuario.Telefono = dr["Telefono"].ToString();
            usuario.Celular = dr["Celular"].ToString();
            usuario.RolID = int.Parse(dr["RolID"].ToString());
            usuario.HorarioID = int.Parse(dr["HorarioID"].ToString());
            usuario.CarreraID = int.Parse(dr["CarreraID"].ToString());
            usuario.Estado = bool.Parse(dr["Estado"].ToString());

            return usuario;
        }
    }
}
