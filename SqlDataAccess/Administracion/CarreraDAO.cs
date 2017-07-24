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
    public class CarreraDAO : ICarreraDAO
    {
        ConsultasSQL sql = new ConsultasSQL();

        public List<Carrera> getAllCarrera(ref string mensaje)
        {
            List<Carrera> carreras = new List<Carrera>();
            sql = new ConsultasSQL();
            sql.Comando.CommandType = CommandType.StoredProcedure;
            sql.Comando.CommandText = "pa_getAllCarrera";

            try
            {
                IDataReader reader = sql.EjecutaReader(ref mensaje);
                while (reader.Read())
                {
                    carreras.Add(Carrera.CreateCarreraFromDataRecord(reader));
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return carreras;
        }

        public Carrera getCarrera(int id, ref string mensaje)
        {
            Carrera carrera = new Carrera();
            sql = new ConsultasSQL();
            sql.Comando.CommandType = CommandType.StoredProcedure;
            sql.Comando.CommandText = "pa_getCarrera";
            sql.Comando.Parameters.AddWithValue("@CarreraID", id);

            try
            {
                IDataReader reader = sql.EjecutaReader(ref mensaje);
                while (reader.Read())
                {
                    carrera = Carrera.CreateCarreraFromDataRecord(reader);
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return carrera;
        }

        public void insertCarrera(Carrera carrera, string usuario, ref string mensaje)
        {
            sql.Comando.CommandType = CommandType.StoredProcedure;
            sql.Comando.CommandText = "pa_insertCarrera";
            sql.Comando.Parameters.AddWithValue("@Nombre", carrera.Nombre);
            sql.Comando.Parameters.AddWithValue("@FacultadID", carrera.FacultadID);
            sql.Comando.Parameters.AddWithValue("@Usuario", usuario);

            try
            {
                sql.EjecutaQuery(ref mensaje);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
        }

        public void updateCarrera(Carrera carrera, string usuario, ref string mensaje)
        {
            sql.Comando.CommandType = CommandType.StoredProcedure;
            sql.Comando.CommandText = "pa_updateCarrera";
            sql.Comando.Parameters.AddWithValue("@CarreraID", carrera.CarreraID);
            sql.Comando.Parameters.AddWithValue("@FacultadID", carrera.FacultadID);
            sql.Comando.Parameters.AddWithValue("@Nombre", carrera.Nombre);
            sql.Comando.Parameters.AddWithValue("@Usuario", usuario);
            sql.Comando.Parameters.AddWithValue("@Estado", carrera.Estado);

            try
            {
                sql.EjecutaQuery(ref mensaje);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
        }
    }
}
