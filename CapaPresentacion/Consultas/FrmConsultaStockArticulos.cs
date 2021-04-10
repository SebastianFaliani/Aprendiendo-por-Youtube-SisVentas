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

namespace CapaPresentacion.Consultas
{
    public partial class FrmConsultaStockArticulos : Form
    {
        public FrmConsultaStockArticulos()
        {
            InitializeComponent();
        }

        //Metodo para Ocultar columnas
        private void OcultarColumas()
        {
            this.dataListado.Columns[0].Visible = false;
        }

        //Metodo Stock_Articulo
        private void Stock_Articulo()
        {
            this.dataListado.DataSource = NArticulo.Stock_Articulo();
            this.OcultarColumas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void FrmConsultaStockArticulos_Load(object sender, EventArgs e)
        {
            this.Stock_Articulo();
        }
    }
}
