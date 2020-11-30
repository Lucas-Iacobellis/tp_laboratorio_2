using System;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmClientes formularioClientes = new FrmClientes();
            formularioClientes.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmEmpleados formularioEmpleados = new FrmEmpleados();
            formularioEmpleados.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmVentas formularioVentas = new FrmVentas();
            formularioVentas.Show();
        }
        private void menuMiniSuper_MouseEnter(object sender, EventArgs e)
        {
            for (int i = 0; i < menuMiniSuper.Items.Count; i++)
            {
                menuMiniSuper.Items[i].Visible = true;
            }
        }

        private void menuMiniSuper_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < menuMiniSuper.Items.Count; i++)
            {
                menuMiniSuper.Items[i].Visible = false;
            }
        }
        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            this.Close();
        }       
    }
}
