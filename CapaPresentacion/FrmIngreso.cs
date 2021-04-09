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
    public partial class FrmIngreso : Form
    {
        public int IdTrabajador;
        private bool IsNuevo;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;

        private static FrmIngreso _instancia;
        public static FrmIngreso GetInstancia ()
        {
            if (_instancia == null)
            {
                _instancia = new FrmIngreso();
            }
            return _instancia;
        }

        public void setProveedor(int idproveedor,string nombre)
        {
            this.txtIdProveedor.Text = idproveedor.ToString();
            this.txtProveedor.Text = nombre;
        }

        public void setArticulo( int idarticulo, string nombre)
        {
            this.txtIdArticulo.Text = idarticulo.ToString();
            this.txtArticulo.Text = nombre;
        }


        public FrmIngreso()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtProveedor, "Seleccione el Proveedor");
            this.ttMensaje.SetToolTip(this.txtSerie, "Ingrese la serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtCorrelativo, "Ingrese el numero del comprobante");
            this.ttMensaje.SetToolTip(this.txtStock, "Ingrese la cantidad de compra");
            this.ttMensaje.SetToolTip(this.txtArticulo, "Seleccione el Articulo de compra");
            this.txtIdProveedor.Visible = false;
            this.txtIdArticulo.Visible = false;
            this.txtProveedor.ReadOnly = true;
            this.txtArticulo.ReadOnly = true;
        }

        //Metodo Mostrar Mensaje de Confirmacion
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Metodo Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Metodo Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtIdIngreso.Text = string.Empty;
            this.txtIdProveedor.Text = string.Empty;
            this.txtProveedor.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.txtCorrelativo.Text = string.Empty;
            this.txtIgv.Text = string.Empty;
            this.lblTotalPagado.Text = "0.0";
            this.txtIgv.Text = "18";
            this.CrearTabla();
        }

        //Metodo Limpiar detalle
        private void LimpiarDetalle()
        {
            this.txtIdArticulo.Text = string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStock.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
        }

        //Metodo Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdIngreso.ReadOnly = !valor;
            this.txtSerie.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIgv.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.cbTipo_Comprobante.Enabled = valor;
            this.txtStock.ReadOnly = !valor;
            this.txtPrecioCompra.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.dtFechaProduccion.Enabled = valor;
            this.dtFechaVencimiento.Enabled = valor;

            this.btnbuscarArticulo.Enabled = valor;
            this.btnBuscarProveedor.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;

        }

        //Metodo Habilitar los botones del formulario
        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
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
            this.dataListado.DataSource = NIngreso.Mostrar();
            this.OcultarColumas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo BuscarFechas
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NIngreso.BuscarFechas(this.dtFecha1.Value.ToString("dd/MM/yyyy"),this.dtFecha2.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo MostrarDetalle
        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = NIngreso.Mostrardetalle(Convert.ToInt32(this.txtIdIngreso.Text));
            

        }

        //Crar tabla detalle
        private void CrearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("IdArticulo", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("PrecioCompra", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("PrecioVenta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("StockInicial", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("FechaProduccion", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("FechaVencimiento", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("Subtotal", System.Type.GetType("System.Decimal"));

            //Relacionamos nuestro DataGridView con nuestr DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;
        }

        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.CrearTabla();
        }

        private void FrmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            FrmVistaProveedorIngreso vista = new FrmVistaProveedorIngreso();
            vista.ShowDialog();
        }

        private void btnbuscarArticulo_Click(object sender, EventArgs e)
        {
            FrmVistaArticuloIngreso vista = new FrmVistaArticuloIngreso();
            vista.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea anular lo registro", "Sistema de Ventas",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            rpta = NIngreso.Anular(Codigo);

                            if (rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se anulo correctamente el ingreso");
                            }
                            else
                            {
                                this.MensajeError(rpta);
                            }
                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkAnular_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAnular.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.cbTipo_Comprobante.Focus();
            this.LimpiarDetalle();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.LimpiarDetalle();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtIdProveedor.Text == string.Empty || this.txtSerie.Text == string.Empty || this.txtCorrelativo.Text == string.Empty || this.txtIgv.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtIdProveedor, "Ingrese un valor");
                    errorIcono.SetError(txtSerie, "Ingrese un valor");
                    errorIcono.SetError(txtCorrelativo, "Ingrese un valor");
                    errorIcono.SetError(txtIgv, "Ingrese un valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NIngreso.Insertar(this.IdTrabajador, Convert.ToInt32(this.txtIdProveedor.Text),
                            this.dtFecha.Value, this.cbTipo_Comprobante.Text, this.txtSerie.Text, this.txtCorrelativo.Text, Convert.ToDecimal(this.txtIgv.Text), "EMITIDO",
                            dtDetalle);
                    }
                    
                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se insertó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.LimpiarDetalle();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                 if (this.txtIdArticulo.Text == string.Empty || this.txtStock.Text == string.Empty || this.txtPrecioCompra.Text == string.Empty 
                    || this.txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtIdArticulo, "Ingrese un valor");
                    errorIcono.SetError(txtStock, "Ingrese un valor");
                    errorIcono.SetError(txtPrecioCompra, "Ingrese un valor");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese un valor");
                }
                else
                {
                    bool registrar = true;
                    foreach(DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["idarticulo"]) == Convert.ToInt32(txtIdArticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("ya se encuentra el articulo");
                        }
                    }
                    if (registrar)
                    {
                        decimal subtotal = Convert.ToDecimal(this.txtStock.Text) * Convert.ToDecimal(this.txtPrecioCompra.Text);
                        totalPagado = totalPagado + subtotal;
                        this.lblTotalPagado.Text = totalPagado.ToString("#0.00#");
                        //Agregar ese detalle al datalistado detalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["IdArticulo"] = Convert.ToInt32(this.txtIdArticulo.Text);
                        row["Articulo"] = (this.txtArticulo.Text);
                        row["PrecioCompra"] = Convert.ToDecimal(this.txtPrecioCompra.Text);
                        row["PrecioVenta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["StockInicial"] = Convert.ToInt32(this.txtStock.Text);
                        row["FechaProduccion"] = Convert.ToDateTime(this.dtFechaProduccion.Value);
                        row["FechaVencimiento"] = Convert.ToDateTime(this.dtFechaVencimiento.Value);
                        row["Subtotal"] = subtotal;
                        this.dtDetalle.Rows.Add(row);
                        this.LimpiarDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = this.dataListado.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];
                //Disminuir totalpago
                this.totalPagado = this.totalPagado - Convert.ToDecimal(row["SubTotal"].ToString());
                this.lblTotalPagado.Text = totalPagado.ToString("#0.00#");
                //removemos la fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch(Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdIngreso.Text = this.dataListado.CurrentRow.Cells["idingreso"].Value.ToString();
            this.txtProveedor.Text = this.dataListado.CurrentRow.Cells["proveedor"].Value.ToString();
            this.dtFecha.Value =Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha"].Value);
            this.cbTipo_Comprobante.Text = this.dataListado.CurrentRow.Cells["tipo_comprobante"].Value.ToString();
            this.txtSerie.Text = this.dataListado.CurrentRow.Cells["serie"].Value.ToString();
            this.txtCorrelativo.Text = this.dataListado.CurrentRow.Cells["correlativo"].Value.ToString();
            this.lblTotalPagado.Text = this.dataListado.CurrentRow.Cells["total"].Value.ToString();
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }
    }
}
