using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmVistaCliente_Venta : Form
    {
        public FrmVistaCliente_Venta()
        {
            InitializeComponent();
        }

        private void FrmVistaCliente_Venta_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        //Metodo para Ocultar columnas
        private void OcultarColumas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Metodo Mostrar Registros
        private void Mostrar()
        {
            this.dataListado.DataSource = NCliente.Mostrar();
            this.OcultarColumas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo Buscar Apellido
        private void BuscarApellido()
        {
            this.dataListado.DataSource = NCliente.BuscarApellido(txtBuscar.Text);
            this.OcultarColumas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo Buscar Documento
        private void BuscarClienteDocumento()
        {
            this.dataListado.DataSource = NCliente.BuscarClienteDocumento(txtBuscar.Text);
            this.OcultarColumas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.cbBuscar.Text.Equals("Apellidos"))
            {
                this.BuscarApellido();
            }
            else if (this.cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarClienteDocumento();
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmVenta form = FrmVenta.GetInstancia();
            int par1;
            string par2;
            par1 =Convert.ToInt32( this.dataListado.CurrentRow.Cells["idcliente"].Value);
            par2 = this.dataListado.CurrentRow.Cells["apellidos"].Value.ToString() + " " + 
                this.dataListado.CurrentRow.Cells["nombre"].Value.ToString();
            form.setCliente(par1, par2);
            this.Hide();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
