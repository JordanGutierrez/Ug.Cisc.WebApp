using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlDataAccess.Utils
{
    public class ConsultasSQL
    {
        private readonly SqlConnection _laConexion;
        public SqlCommand Comando {     get; set; }

        private readonly Base _conexion = new Base();

        public ConsultasSQL()
        {
            _laConexion = _conexion.ObtenerConexionSql();
            Comando = new SqlCommand();
        }

        public void AbrirConexion()
        {
            if (_laConexion.State != ConnectionState.Open)
                _laConexion.Open();
        }

        public void CerrarConexion()
        {
            if (_laConexion.State != ConnectionState.Closed)
                _laConexion.Close();
        }

        public IDataReader EjecutaReader(ref string mensaje)
        {
            IDataReader retValue = null;
            try
            {
                AbrirConexion();
                Comando.Connection = _laConexion;
                retValue = Comando.ExecuteReader(CommandBehavior.CloseConnection);
                mensaje = "OK";
                return retValue;
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return retValue;  
        }

        public string EjecutaQuery()
        {
            string mensaje = string.Empty;
            int retValue;

            try
            {
                AbrirConexion();
                Comando.Connection = _laConexion;
                retValue = Comando.ExecuteNonQuery();
                mensaje = "OK";
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                CerrarConexion();
            }
            return mensaje;
        }

        public DataTable EjecutaDataTable(ref string mensaje)
        {
            DataTable dt = new DataTable();
            try
            {
                AbrirConexion();
                Comando.Connection = _laConexion;
                var ad = new SqlDataAdapter(Comando);
                ad.Fill(dt);
                mensaje = "OK";
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                CerrarConexion();
            }
            return dt;
        }

        public DataSet EjecutaDataSet(ref string mensaje)
        {
            DataSet ds = new DataSet();
            try
            {
                AbrirConexion();
                Comando.Connection = _laConexion;
                var ad = new SqlDataAdapter(Comando);
                ad.Fill(ds);
                mensaje = "OK";
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                mensaje = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            finally
            {
                CerrarConexion();
            }
            return ds;
        }
    }
}