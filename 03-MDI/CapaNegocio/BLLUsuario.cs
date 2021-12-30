using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class BLLUsuario
    {
        private DALUsuario objetoCD = new DALUsuario();

        public DataTable View() {

            DataTable tabla = new DataTable();
            tabla = objetoCD.ReadAllUsuario();
            return tabla;
        }
        public void Create(string usuario, string contrasena, int intentos, double nivelSeg, DateTime fechaReg)
        {

            objetoCD.CreateUsuario(usuario, contrasena, Convert.ToInt32(intentos),Convert.ToDouble(nivelSeg), fechaReg);
    }

        public void Update(string usuario, string contrasena, int intentos, double nivelSeg, DateTime fechaReg, int id)
        {
            objetoCD.UpdateUsuario(usuario, contrasena, Convert.ToInt32(intentos), Convert.ToDouble(nivelSeg), 
                fechaReg, Convert.ToInt32(id));
        }

        public void Delete(int id) {

            objetoCD.DeleteUsuario(id);
        }

        public bool F_ValUsuario(string pStr_CodUsuario)
        {
            return objetoCD.F_ValUsuario(pStr_CodUsuario);
        }

        public bool F_LoginUsuario(string pStr_CodUsuario, string pStr_Contrasena)
        {
            return objetoCD.F_LoginUsuario(pStr_CodUsuario, pStr_Contrasena);
        }
    }
}