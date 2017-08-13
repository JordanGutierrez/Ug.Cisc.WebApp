using DataAccess.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entidades.Administracion;
using SqlDataAccess.Utils;
using System.Data;
using DataAccess.Administracion;
using SqlDataAccess.Administracion;

namespace SqlDataAccess.Seguridad
{
    public class SeguridadDAO : ISeguridadDAO
    {
        string remoteAddress { get; set; }

        ConsultasSQL sql = new ConsultasSQL();
        IAppMenuDAO appmenuDAO = new AppMenuDAO();
        IPersonaDAO personaDAO = new PersonaDAO();

        public SeguridadDAO(string remoteAddress)
        {
            this.remoteAddress = remoteAddress;
        }

        public string authenticateUser(string userName, string password, out List<string> transacciones, out Persona persona)
        {
            persona = null;
            string mensaje = string.Empty;
            var retValue = string.Empty;
            var loginHelper = new Usuario();
            loginHelper.Clave = password;
            loginHelper.UserName = userName;

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    loginHelper.MaqSitio = ip.ToString();
                }
            }
            loginHelper.Maquina = this.remoteAddress;

            string roles = string.Empty;
            transacciones = null;
            try
            {
                var usuario = getUsuario(userName, ref mensaje);
                if (mensaje == "OK")
                {
                    if (usuario != null)
                    {
                        if (usuario.Estado)
                        {
                            if (usuario.Clave == GetStringSha256Hash(password))
                            {
                                List<AppMenu> menus = appmenuDAO.getAllbyRol(usuario.RolID, ref mensaje);
                                if(mensaje == "OK")
                                {
                                    transacciones = new List<string>();
                                    foreach (AppMenu menu in menus)
                                    {
                                        transacciones.Add(menu.VistaID);
                                    }
                                     persona = personaDAO.getPersonabyUser(usuario.UsuarioID, ref mensaje);
                                }
                            }
                            else
                                mensaje = "La clave o contraseña es incorrecta";
                        }
                        else
                            mensaje = "El usuario se encuentra inactivo";
                    }
                    else
                        mensaje = "El usuario no existe";
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }

        internal static string GetStringSha256Hash(string text)
        {
            if (String.IsNullOrEmpty(text))
                return String.Empty;

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }

        public Usuario getUsuario(string alias, ref string mensaje)
        {
            Usuario usuario = null;
            sql = new ConsultasSQL();
            sql.Comando.CommandType = CommandType.StoredProcedure;
            sql.Comando.CommandText = "pa_getUsuario";
            sql.Comando.Parameters.AddWithValue("@Alias", alias);

            try
            {
                IDataReader reader = sql.EjecutaReader(ref mensaje);
                if (reader.Read())
                {
                    usuario = new Usuario();
                    usuario =  Usuario.CreateUsuarioFromDataRecord(reader);
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                sql.CerrarConexion();
            }

            return usuario;
        }

        private List<string> leerTransacciones(List<AppMenu> menus)
        {
            List<string> result = new List<string>();

            foreach (var menu in menus)
            {
                result.Add(menu.VistaID.ToString());
            }

            return result;
        }

    }
}
