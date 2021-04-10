using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            lblHora.Text = DateTime.Now.ToString();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this.Ingresar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.Ingresar(); 
            }
        }

        private void Ingresar()
        {
            DataTable Datos = CapaNegocio.NTrabajador.Login(this.txtUsuario.Text, this.txtPassword.Text);

            //Evaluear si existe el usuario
            if (Datos.Rows.Count == 0)
            {
                MessageBox.Show("No Tiene Acceso al Sistema", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmPrincipal frm = new FrmPrincipal();
                frm.idTrabajador = Datos.Rows[0][0].ToString();
                frm.apellido = Datos.Rows[0][1].ToString();
                frm.nombre = Datos.Rows[0][2].ToString();
                frm.acceso = Datos.Rows[0][3].ToString();
                frm.Show();
                this.Hide();
            }
        }

    }
}
