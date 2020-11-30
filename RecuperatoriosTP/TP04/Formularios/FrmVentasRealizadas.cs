using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using CapaDeNegocio;
using Entidades;

namespace Formularios
{
    public partial class FrmVentasRealizadas : Form
    {
        SoundPlayer sonido;

        ClienteNegocio clienteNegocio;
        EmpleadoNegocio empleadoNegocio;
        ProductoNegocio productoNegocio;
        public FrmVentasRealizadas()
        {
            InitializeComponent();

            clienteNegocio = new ClienteNegocio();
            empleadoNegocio = new EmpleadoNegocio();
            productoNegocio = new ProductoNegocio();
          
            Negocio.ListaVentas = new List<Venta>();
        }
        public void GetDataSource()
        { 
            dataGridViewProductos.DataSource = null;
            dataGridViewProductos.DataSource = Negocio.ListaProductos;

            dataGridViewProductos.AutoResizeRows();

            dataGridViewProductos.Columns[0].ReadOnly = true;
            dataGridViewProductos.Columns[1].ReadOnly = true;
            dataGridViewProductos.Columns[2].ReadOnly = true;
            dataGridViewProductos.Columns[3].ReadOnly = true;
            dataGridViewProductos.Columns[4].ReadOnly = true;
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            FrmClientes frmClientes = new FrmClientes();
            this.Visible = false;
            frmClientes.Show();
        }
        private void FrmVentas_Load(object sender, EventArgs e)
        {

        }
        private void FrmVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
