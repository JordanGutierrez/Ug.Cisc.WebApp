using Entidades.Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Seguridad
{
    public interface ISeguridadDAO
    {
        string authenticateUser(string userName, string password, out List<string> transacciones, out int rolid);

        Usuario getUsuario(string alias, ref string mensaje);

        //List<AppMenu> getAppMenuByTransactions(string transactions);
    }
}
