﻿using System;
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
    public partial class FrmVistaArticulo_Venta : Form
    {
        public FrmVistaArticulo_Venta()
        {
            InitializeComponent();
        }

        //Metodo para Ocultar columnas
        private void OcultarColumas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Metodo Buscar Nombre
        private void MostrarArticulo_Venta_Nombre()
        {
            this.dataListado.DataSource = NVenta.MostrarArticulo_Venta_Nombre((this.txtBuscar.Text));
            this.OcultarColumas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo Buscar Codigo
        private void MostrarArticulo_Venta_Codigo()
        {
            this.dataListado.DataSource = NVenta.MostrarArticulo_Venta_Codigo(this.txtBuscar.Text);
            this.OcultarColumas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmVistaArticulo_Venta_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Código"))
            {
                this.MostrarArticulo_Venta_Codigo();
            }
            else if(cbBuscar.Text.Equals("Nombre"))
            {
                this.MostrarArticulo_Venta_Nombre();
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmVenta form = FrmVenta.GetInstancia();
            int par1;
            string par2;
            decimal par3, par4;
            int par5;
            DateTime par6;

            par1 =Convert.ToInt32( dataListado.CurrentRow.Cells["iddetalle_ingreso"].Value);
            par2 = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            par3 = Convert.ToDecimal(dataListado.CurrentRow.Cells["precio_compra"].Value);
            par4 = Convert.ToDecimal(dataListado.CurrentRow.Cells["precio_venta"].Value);
            par5 = Convert.ToInt32(dataListado.CurrentRow.Cells["stock_actual"].Value);
            par6 = Convert.ToDateTime(dataListado.CurrentRow.Cells["fecha_vencimiento"].Value);
            form.setArticulo(par1, par2, par3, par4, par5, par6);
            this.Hide();
        }
    }
}
