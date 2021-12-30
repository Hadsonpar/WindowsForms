using System;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmUsuario : Form
    {
        BLLUsuario objetoCN = new BLLUsuario();
        private int idProducto=0;
        private bool Editar = false;

        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ViewAllUsuario();
        }

        private void ViewAllUsuario() {

            BLLUsuario objeto = new BLLUsuario();
            dataGridView1.DataSource = objeto.View();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {            
            if (Editar == false)
            {
                try
                {
                    //Validación de controles
                    if (txtUsuario.Text == "")
                    {
                        MessageBox.Show("Falta Ingresar el Usuario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUsuario.Focus();
                        return;
                    }
                    if (txtContrasena.Text == "")
                    {
                        MessageBox.Show("Falta Ingresar la Contraseña", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtContrasena.Focus();
                        return;
                    }
                    if (txtNroIntentos.Text == "")
                    {
                        MessageBox.Show("Falta Ingresar el Nro de Intentos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNroIntentos.Focus();
                        return;
                    }
                    if (txtNivelSeg.Text == "")
                    {
                        MessageBox.Show("Falta Ingresar el Nivel de Seguridad", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNivelSeg.Focus();
                        return;
                    }
                    if (txtFechaReg.Text == "")
                    {
                        MessageBox.Show("Falta Ingresar la Fecha de Registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFechaReg.Focus();
                        return;
                    }

                    objetoCN.Create(txtUsuario.Text, txtContrasena.Text, Convert.ToInt32(txtNroIntentos.Text), Convert.ToDouble(txtNivelSeg.Text), Convert.ToDateTime(txtFechaReg.Text));
                    MessageBox.Show("Se guardo correctamente");
                    ViewAllUsuario();
                    ClearControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos, se encontro el siguiente error : " + ex);
                }
            }
            
            if (Editar == true) {

                try
                {
                    objetoCN.Update(txtUsuario.Text, txtContrasena.Text, Convert.ToInt32(txtNroIntentos.Text), Convert.ToDouble(txtNivelSeg.Text), Convert.ToDateTime(txtFechaReg.Text), idProducto);
                    MessageBox.Show("Registro actualizado correctamente");
                    ViewAllUsuario();
                    ClearControls();
                    Editar = false;
                }
                catch (Exception ex) {
                    MessageBox.Show("No se pudo insertar los datos, se encontro el siguiente error : " + ex);
                }
            }
        }        

        private void ClearControls() {
            txtContrasena.Clear();
            txtNroIntentos.Clear();
            txtNivelSeg.Clear();
            txtFechaReg.Clear();
            txtUsuario.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                objetoCN.Delete(idProducto);
                MessageBox.Show("Registro eliminado correctamente");
                ViewAllUsuario();
            }
            else
                MessageBox.Show("Por favor debe seleccionar una fila");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtUsuario.Text = dataGridView1.CurrentRow.Cells["usuario"].Value.ToString();
                txtContrasena.Text = dataGridView1.CurrentRow.Cells["contrasena"].Value.ToString();
                txtNroIntentos.Text = dataGridView1.CurrentRow.Cells["intentos"].Value.ToString();
                txtNivelSeg.Text = dataGridView1.CurrentRow.Cells["nivelSeg"].Value.ToString();
                txtFechaReg.Text = dataGridView1.CurrentRow.Cells["fechaReg"].Value.ToString();
                idProducto = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            }
            else
                MessageBox.Show("Por favor debe seleccionar una fila");
        }
    }
}