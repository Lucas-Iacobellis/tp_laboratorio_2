using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaDeNegocio;
using Entidades;
using Validaciones;

namespace Formularios
{
    public partial class FrmEmpleados : Form
    {
        EmpleadoNegocio empleadoNegocio;
        public FrmEmpleados()
        {
            InitializeComponent();

            empleadoNegocio = new EmpleadoNegocio();
        }
        public void GetDataSource()
        {
            dataGridViewEmpleados.DataSource = null;
            empleadoNegocio.CargarEmpleados();
            dataGridViewEmpleados.DataSource = Negocio.ListaEmpleados;

            dataGridViewEmpleados.AutoResizeRows();

            dataGridViewEmpleados.Columns[1].ReadOnly = true;
            dataGridViewEmpleados.Columns[2].ReadOnly = true;
            dataGridViewEmpleados.Columns[3].ReadOnly = true;
            dataGridViewEmpleados.Columns[4].ReadOnly = true;
            dataGridViewEmpleados.Columns[5].ReadOnly = true;
        }
        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            bool validacionNombre = true;
            bool validacionApellido = true;
            bool validacionEdad = true;
            bool validacionDNI = true;
            bool validacionIdEmpleado = true;

            if (Validar.ValidarString(txtNombre.Text) == "")
            {
                validacionNombre = false;
                MessageBox.Show("Nombre invalido");
            }

            if (Validar.ValidarString(txtApellido.Text) == "")
            {
                validacionApellido = false;
                MessageBox.Show("Apellido invalido");
            }

            if (Validar.ValidarEdad(Validar.ValidarStringToInt(txtEdad.Text)) == 0)
            {
                validacionEdad = false;
                MessageBox.Show("Edad invalida");
            }

            if (Validar.ValidarEntero(Validar.ValidarStringToInt(txtDni.Text)) == 0)
            {
                validacionDNI = false;
                MessageBox.Show("DNI invalido");
            }

            if (empleadoNegocio.VerificarEmpleado(Convert.ToInt32(txtIdEmpleado.Text)) == true)
            {
                if (Validar.ValidarEntero(Validar.ValidarStringToInt(txtIdEmpleado.Text)) == 0)
                {
                    validacionIdEmpleado = false;
                    MessageBox.Show("ID Empleado invalido");
                }

                if (validacionNombre == true && validacionApellido == true && validacionEdad == true && validacionDNI == true && validacionIdEmpleado == true)
                {
                    Empleado empleado = new Empleado(txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtEdad.Text), Convert.ToInt32(txtDni.Text), Convert.ToInt32(txtIdEmpleado.Text));

                    if (Negocio.ListaEmpleados + empleado == true)
                    {
                        empleadoNegocio.InsertarEmpleado(empleado);
                        MessageBox.Show("Empleado/a agregado/a");
                        GetDataSource();
                        LimpiarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un/a empleado/a con esos datos");
                        GetDataSource();
                        LimpiarDatos();
                    }
                }
            }

            else
            {
                MessageBox.Show("IdEmpleado repetido");
            }
        }
        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            bool variable = false;

            Empleado empleadoAEliminar = new Empleado();

            List<Empleado> listaAEliminar = new List<Empleado>();

            for (int i = 0; i < Negocio.ListaEmpleados.Count; i++)
            {

                if (Convert.ToBoolean(dataGridViewEmpleados.Rows[i].Cells[0].Value) == true)
                {
                    empleadoAEliminar.IdEmpleado = Convert.ToInt32(dataGridViewEmpleados.Rows[i].Cells[1].Value);
                    empleadoAEliminar.Nombre = dataGridViewEmpleados.Rows[i].Cells[2].Value.ToString();
                    empleadoAEliminar.Apellido = dataGridViewEmpleados.Rows[i].Cells[3].Value.ToString();
                    empleadoAEliminar.Edad = Convert.ToInt32(dataGridViewEmpleados.Rows[i].Cells[4].Value);
                    empleadoAEliminar.Dni = Convert.ToInt32(dataGridViewEmpleados.Rows[i].Cells[5].Value);

                    listaAEliminar.Add(empleadoAEliminar);
                }

            }

            for (int i = 0; i < listaAEliminar.Count; i++)
            {
                if (Negocio.ListaEmpleados - listaAEliminar[i])
                {
                    variable = true;
                }
            }

            if (variable == true)
            {
                empleadoNegocio.EliminarEmpleado(empleadoAEliminar);
                MessageBox.Show("Empleado/os eliminado/os");
                GetDataSource();
                LimpiarDatos();
            }

            else
            {
                MessageBox.Show("Seleccione el/los empleado/s que quiere eliminar");
                LimpiarDatos();
            }
        }
        private void btnModificarEmpleado_Click(object sender, EventArgs e)
        {
            bool variable = false;

            Empleado empleadoModificado = new Empleado();

            for (int i = 0; i < Negocio.ListaEmpleados.Count; i++)
            {

                if (Convert.ToBoolean(dataGridViewEmpleados.Rows[i].Cells[0].Value) == true)
                {
                    empleadoModificado.IdEmpleado = Convert.ToInt32(txtIdEmpleado.Text);
                    empleadoModificado.Nombre = txtNombre.Text;
                    empleadoModificado.Apellido = txtApellido.Text;
                    empleadoModificado.Edad = Convert.ToInt32(txtEdad.Text);
                    empleadoModificado.Dni = Convert.ToInt32(txtDni.Text);

                    variable = true;
                }

            }
            
            if (variable == true)
            {
                empleadoNegocio.ModificarEmpleado(empleadoModificado);
                MessageBox.Show("Empleado/a modificado/a");
                GetDataSource();
                LimpiarDatos();
            }

            else
            {
                MessageBox.Show("Seleccione el/la empleado/a que quiere modificar");
                LimpiarDatos();
            }

            txtIdEmpleado.ReadOnly = false;
        }
        private void dataGridViewEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdEmpleado.ReadOnly = true;

            btnEliminarEmpleado.Enabled = true;

            int contador = 0;
            for (int i = 0; i < dataGridViewEmpleados.Rows.Count; i++)
            {
                if (dataGridViewEmpleados.Rows[i].Cells["Seleccionar"].Value != null)
                {
                    bool tilde = (bool)dataGridViewEmpleados.Rows[i].Cells["Seleccionar"].Value;

                    if (tilde == true)
                    {
                        contador++;
                    }
                }

            }

            if (contador == 1)
            {
                btnModificarEmpleado.Enabled = true;

                if (e.RowIndex != -1)
                {
                    for (int i = 0; i < Negocio.ListaEmpleados.Count; i++)
                    {

                        if (Convert.ToBoolean(dataGridViewEmpleados.Rows[i].Cells[0].Value) == true)
                        {
                            txtNombre.Text = Negocio.ListaEmpleados[i].Nombre;
                            txtApellido.Text = Negocio.ListaEmpleados[i].Apellido;
                            txtEdad.Text = Negocio.ListaEmpleados[i].Edad.ToString();
                            txtDni.Text = Negocio.ListaEmpleados[i].Dni.ToString();
                            txtIdEmpleado.Text = Negocio.ListaEmpleados[i].IdEmpleado.ToString();
                        }
                    }
                }
            }

            else
            {
                btnModificarEmpleado.Enabled = false;
                LimpiarDatos();
            }
        }

        private void dataGridViewEmpleados_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewEmpleados.IsCurrentCellDirty)
            {
                dataGridViewEmpleados.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            this.Visible = false;
            this.Close();
            frmMenu.Show();
        }
        public void LimpiarDatos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";
            txtDni.Text = "";
            txtIdEmpleado.Text = "";
        }
        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
           GetDataSource();   
        }
        private void FrmEmpleados_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Negocio.ListaEmpleados.Count == 0)
            {
                Negocio.TodoBorradoEmpleados = true;
            }
            
            this.Dispose();
            this.Close();
        }
    }
}
