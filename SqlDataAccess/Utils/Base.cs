using System;
using System.Data.SqlClient;
using System.Configuration;

namespace SqlDataAccess.Utils
{
    public class Base
    {

        public SqlConnection ObtenerConexionSql()
        {
            try
            {
                string Server = ConfigurationManager.AppSettings["Server"].ToString();
                string Catalog = ConfigurationManager.AppSettings["Catalog"].ToString();
                string User = ConfigurationManager.AppSettings["User"].ToString();
                string Password = ConfigurationManager.AppSettings["Password"].ToString();
                return new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + Catalog + ";Persist Security Info=True;User ID=" + User + "; Password=" + Password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
