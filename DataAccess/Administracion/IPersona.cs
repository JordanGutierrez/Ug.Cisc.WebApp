using Entidades.Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Administracion
{
    public interface IPersona
    {
        List<Persona> getAllPersona(ref string mensaje);

        Persona getPersona(int id, ref string mensaje);

        void insertPersona(Persona persona, string usuario, ref string mensaje);

        void updatePersona(Persona persona, string usuario, ref string mensaje);
    }
}
