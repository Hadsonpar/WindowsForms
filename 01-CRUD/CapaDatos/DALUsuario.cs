using System;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    /// <summary>
    /// Clase que conforman los métodos para el acceso a datos a través 
    /// de los procedimientos almacenados "Store Procedure".
    /// </summary>
    public class DALUsuario
    {
        private DALConexion conexion = new DALConexion();

        SqlDataReader dataReader;
        DataTable table = new DataTable();
        SqlCommand comando = new SqlCommand();

        /// <summary>
        /// Método para Insertar "Create" los datos
        /// </summary>
        public void CreateUsuario(string usuario, string contrasena, int intentos, double nivelSeg, DateTime fechaReg)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_INSERTAR_USUARIO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@contrasena", contrasena);
            comando.Parameters.AddWithValue("@intentos", intentos);
            comando.Parameters.AddWithValue("@nivelSeg", nivelSeg);
            comando.Parameters.AddWithValue("@fechaReg", fechaReg);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        /// <summary>
        /// Método para Seleccionar "Read" los datos
        /// </summary>
        public DataTable ReadAllUsuario() 
        {        
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_SELECCIONAR_ALL_USUARIO";
            comando.CommandType = CommandType.StoredProcedure;
            dataReader = comando.ExecuteReader();
            table.Load(dataReader);
            conexion.CloseConnection();
            return table;            
        }

        /// <summary>
        /// Método para Actualizar "Update" los datos
        /// </summary>
        /// <param name="id">parámetro para filtra y actualizar el registro de acurdo al id</param>
        public void UpdateUsuario(string usuario, string contrasena, int intentos, double nivelSeg, DateTime fechaReg, int id)
        {
            
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_ACTUALIZAR_USUARIO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@contrasena", contrasena);
            comando.Parameters.AddWithValue("@intentos", intentos);
            comando.Parameters.AddWithValue("@nivelSeg", nivelSeg);
            comando.Parameters.AddWithValue("@fechaReg", fechaReg);
            comando.Parameters.AddWithValue("@id",id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        /// <summary>
        /// Método para Eliminar "Delete" los datos
        /// </summary>
        /// <param name="id">parámetro de entrada para eliminar el registro de acuerdo al filtro id</param>
        public void DeleteUsuario(int id) {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_ELIMINAR_USUARIO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

    }
}