using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmLogin : Form
    {
        BLLUsuario objetoCN = new BLLUsuario();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            FrmUsuario frmUsuario = new FrmUsuario();            

            try
            {
                //Validación de controles
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Falta Ingresar el Usuario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Focus();
                    return;
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Falta Ingresar la Contraseña", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox2.Focus();
                    return;
                }

                //Validar registro de usuario en base de datos
                bool boolValUsuario = objetoCN.F_ValUsuario(textBox1.Text);

                if (boolValUsuario == false)
                {
                    MessageBox.Show("El Usuario no se encuentra registrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Focus();
                    return;
                }
                else
                {
                    //Validar registro de usuario en base de datos
                    bool boolLoginUsuario = objetoCN.F_LoginUsuario(textBox1.Text, textBox2.Text);

                    if (boolLoginUsuario == false)
                    {
                        MessageBox.Show("El Usuario o Contraseña no Coinciden", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Focus();
                        return;
                    }
                    else {
                        frmUsuario.Show(this);
                        this.Hide();
                    }                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se acceder, se encontro el siguiente error : " + ex);
            }
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
