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

        /// <summary>
        /// Funcion para validar la existencia del registro de la cuenta del usuario
        /// </summary>
        /// <param name="pStr_CodUsuario"></param>
        /// <returns></returns>
        public bool F_ValUsuario(string pStr_CodUsuario)
        {
            int lDec_Existe;

            comando.Connection = conexion.OpenConnection();
            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_VAL_EXISTE_USUARIO";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@PC_USUARIO", pStr_CodUsuario);

                comando.Parameters.Add("@PNO_RETORNO", SqlDbType.Decimal, 10).Direction = ParameterDirection.Output;

                comando.ExecuteNonQuery();
                lDec_Existe = Convert.ToInt32(comando.Parameters["@PNO_RETORNO"].Value);

                if (lDec_Existe == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return false;
            }
            finally
            {
                comando.Connection.Close();
            }
        }

        /// <summary>
        /// Función para el acceso a la aplicación
        /// </summary>
        /// <param name="pStr_CodUsuario">Valor de la cuenta del usuario</param>
        /// <param name="pStr_Contrasena">Contraseña segun la cuenta del usuario</param>
        /// <returns></returns>
        public bool F_LoginUsuario(string pStr_CodUsuario, string pStr_Contrasena)
        {
            int lDec_Existe;

            comando.Connection = conexion.OpenConnection();
            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_LOGIN_USUARIO";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@PC_USUARIO", pStr_CodUsuario);
                comando.Parameters.AddWithValue("@PC_CONTRASENA", pStr_Contrasena);

                comando.Parameters.Add("@PNO_RETORNO", SqlDbType.Decimal, 10).Direction = ParameterDirection.Output;

                comando.ExecuteNonQuery();
                lDec_Existe = Convert.ToInt32(comando.Parameters["@PNO_RETORNO"].Value);

                if (lDec_Existe == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return false;
            }
            finally
            {
                comando.Connection.Close();
            }
        }
    }
}