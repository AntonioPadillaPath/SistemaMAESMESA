using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

using Negocios;
using System.IO;

namespace MAESMESA
{
    public partial class Usuarios : Form
    {
        ConexionSQLN cn = new ConexionSQLN();
            

        public Usuarios()
        {
            InitializeComponent();

            dGVUsuarios.DataSource = cn.ConsultaTablaUsuarios();
            cn.cerrarCon();
            dGVUsuarios.Columns[0].Width = 100;
            dGVUsuarios.Columns[1].Width = 100;
            dGVUsuarios.Columns[2].Width = 180;

            dGVUsuarios.DefaultCellStyle.Font = new Font("Century Gothic", 10);

            
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hand, int hwnd, int wmsg, int lparam);

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Usuarios_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (pboxFoto.Image == Properties.Resources.usuario)
            {
                pboxFoto.Tag = "usuario";
            }

            if (cn.noRepeatUsuario(txtUsername.Text.Trim()) != "Null")
            {
                cn.cerrarCon();

                MessageBox.Show("El Nombre de Usuario ya existe en la Base de Datos y no puede repetirse",
                    "Error al agregar nuevo Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtNombre.Text.Trim() == "Nombre:" || txtApellido.Text.Trim() == "Apellido:" || txtUsername.Text.Trim() == "Nombre de Usuario:"
                || txtPassword.Text.Trim() == "Contraseña:" || txtValidar.Text.Trim() == "Validar Contraseña:" ||
                txtNombre.Text.Trim() == "" || txtApellido.Text.Trim() == "" || txtUsername.Text.Trim() == ""
                || txtPassword.Text.Trim() == "" || txtValidar.Text.Trim() == "")
            {
                MessageBox.Show("Todos los campos son obligatorios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (pboxFoto.Tag == "usuario")
            {
                MessageBox.Show("Debe seleccionar una foto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtPassword.Text.Trim() != txtValidar.Text.Trim())
                {
                    MessageBox.Show("La contraseña debe ser igual en los dos campos", "VALIDACIÓN DE CONTRASEÑA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    byte[] foto = null;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pboxFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        foto = ms.ToArray();
                        cn.cerrarCon();
                    }

                    cn.insertarUsuario(txtNombre.Text.Trim(), txtApellido.Text.Trim(), txtUsername.Text.Trim(),
                        txtPassword.Text.Trim(), foto);
                    cn.cerrarCon();

                    dGVUsuarios.DataSource = cn.ConsultaTablaUsuarios();
                    cn.cerrarCon();

                    MessageBox.Show("Usuario agregado con éxito!", "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtNombre.Text = "Nombre:";
                    txtApellido.Text = "Apellido:";
                    txtUsername.Text = "Nombre de Usuario:";
                    txtPassword.Text = "Contraseña:";
                    txtValidar.Text = "Validar Contraseña:";
                    pboxFoto.Image = Properties.Resources.usuario;
                    pboxFoto.Tag = "";

                    txtNombre.ForeColor = Color.Olive;
                    txtApellido.ForeColor = Color.Olive;
                    txtUsername.ForeColor = Color.Olive;
                    txtPassword.ForeColor = Color.Olive;
                    txtValidar.ForeColor = Color.Olive;


                }
            }

            
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog fo = new OpenFileDialog();
            DialogResult rs = fo.ShowDialog();
            if (rs == DialogResult.OK)
            {
                pboxFoto.Image = Image.FromFile(fo.FileName);
            }
        }

        private void txtNombre_MouseEnter(object sender, EventArgs e)
        {
            //if (txtNombre.Text == "Nombre")
            //{
            //    txtNombre.Text = "";
            //    txtNombre.ForeColor = Color.FromArgb(7, 27, 79);
            //}
        }

        private void txtNombre_MouseLeave(object sender, EventArgs e)
        {
            //if (txtNombre.Text == "")
            //{
            //    txtNombre.Text = "Nombre";
            //    txtNombre.ForeColor = Color.DarkKhaki;
            //}
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "Nombre:")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.White;
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "")
            {
                txtNombre.Text = "Nombre:";
                txtNombre.ForeColor = Color.Olive;
            }
        }

        private void txtApellido_Enter(object sender, EventArgs e)
        {
            if (txtApellido.Text.Trim() == "Apellido:")
            {
                txtApellido.Text = "";
                txtApellido.ForeColor = Color.White;
            }
        }

        private void txtApellido_Leave(object sender, EventArgs e)
        {
            if (txtApellido.Text.Trim() == "")
            {
                txtApellido.Text = "Apellido:";
                txtApellido.ForeColor = Color.Olive;
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "Nombre de Usuario:")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.White;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "")
            {
                txtUsername.Text = "Nombre de Usuario:";
                txtUsername.ForeColor = Color.Olive;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "Contraseña:")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.White;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "")
            {
                txtPassword.Text = "Contraseña:";
                txtPassword.ForeColor = Color.Olive;
            }
        }

        private void txtValidar_Enter(object sender, EventArgs e)
        {
            if (txtValidar.Text.Trim() == "Validar Contraseña:")
            {
                txtValidar.Text = "";
                txtValidar.ForeColor = Color.White;
            }
        }

        private void txtValidar_Leave(object sender, EventArgs e)
        {
            if (txtValidar.Text.Trim() == "")
            {
                txtValidar.Text = "Validar Contraseña:";
                txtValidar.ForeColor = Color.Olive;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Está seguro que desea eliminar éste USUARIO?", "Eliminar Usuario", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string nombre = dGVUsuarios.Rows[dGVUsuarios.CurrentRow.Index].Cells[0].Value.ToString();

                cn.eliminarUsuario(nombre);
                cn.cerrarCon();

                dGVUsuarios.DataSource = cn.ConsultaTablaUsuarios();
                cn.cerrarCon();

                MessageBox.Show("Usuario Eliminado",
                        "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
