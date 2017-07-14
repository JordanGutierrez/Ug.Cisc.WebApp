using DataAccess.Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Administracion;
using SqlDataAccess.Utils;
using System.Data;

namespace SqlDataAccess.Administracion
{
    public class PersonaDAO : IPersona
    {
        ConsultasSQL sql = new ConsultasSQL();

        public List<Persona> getAllPersona(ref string mensaje)
        {
            List<Persona> personas = new List<Persona>();
            sql = new ConsultasSQL();
            sql.Comando.CommandType = CommandType.StoredProcedure;
            sql.Comando.CommandText = "pa_getAllPersona";

            try
            {
                sql.AbrirConexion();
                IDataReader reader = sql.EjecutaReader(ref mensaje);
                while (reader.Read())
                {
                    personas.Add(Persona.CreatePersonaFromDataRecord(reader));
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

            return personas;
        }

        public Persona getPersona(int id)
        {
            throw new NotImplementedException();
        }
    }
}
