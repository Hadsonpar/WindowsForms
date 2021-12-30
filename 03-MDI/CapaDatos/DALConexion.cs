using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DALConexion
    {
        /// <summary>
        /// Cadena de conexión para el acceso a la base de datos SQL Server
        /// </summary>
        private SqlConnection Conexion = new 
            SqlConnection("Server=DESKTOP-CVDA991;DataBase=BD_TEST;User Id=sa; Password=desa1;");

        /// <summary>
        /// Abrir la conexión hacia la base de datos
        /// </summary>
        /// <returns></returns>
        public SqlConnection OpenConnection()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }

        /// <summary>
        /// Cerrar la conexión hacia la base de datos
        /// </summary>
        /// <returns></returns>
        public SqlConnection CloseConnection()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}