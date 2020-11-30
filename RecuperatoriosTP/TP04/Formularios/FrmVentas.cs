using System;
using System.Collections.Generic;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using CapaDeNegocio;
using Entidades;
using Serializacion;
using Validaciones;

namespace Formularios
{
    public partial class FrmVentas : Form
    {
        SoundPlayer sonido;

        ClienteNegocio clienteNegocio;
        EmpleadoNegocio empleadoNegocio;
        CelularNegocio celularNegocio;
        TecladoNegocio tecladoNegocio;
        VentaNegocio ventaNegocio;
        List<Venta> listPreviaVenta = new List<Venta>();
        string TipoProducto;

        public delegate void TransferenciaDeDatos();
        public event TransferenciaDeDatos transfiero;
        FrmVentasRealizadas frmVentasRealizadas = new FrmVentasRealizadas();

        public FrmVentas()
        {
            InitializeComponent();

            clienteNegocio = new ClienteNegocio();
            empleadoNegocio = new EmpleadoNegocio();
            celularNegocio = new CelularNegocio();
            tecladoNegocio = new TecladoNegocio();
            ventaNegocio = new VentaNegocio();

            Negocio.ListaVentas = new List<Venta>();
        }
        public void GetDataSource()
        {
            celularNegocio.CargarCelulares();
            tecladoNegocio.CargarTeclados();
        }
        public void GetProductoEspecifico(string TipoProducto)
        {
            if (TipoProducto == "Celulares")
            {
                dataGridViewProductos.DataSource = Negocio.ListaCelulares;
                dataGridViewProductos.Refresh();
            }

            if (TipoProducto == "Teclados")
            {
                dataGridViewProductos.DataSource = Negocio.ListaTeclados;
                dataGridViewProductos.Refresh();
            }
        }
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            txtIdProducto.Enabled = true;

            bool validacionNombre = true;
            bool validacionPrecio = true;
            bool validacionCantidad = true;
            bool validacionIdProducto = true;
            bool validacionMarca = true;
            bool validacionPantalla = true;
            bool validacionMicro = true;
            bool validacionTipo = true;

            if (Validar.ValidarString(txtNombre.Text) == "")
            {
                validacionNombre = false;
                MessageBox.Show("Nombre invalido");
            }

            if (Validar.ValidarStringToFloat(txtPrecio.Text) == 0)
            {
                validacionPrecio = false;
                MessageBox.Show("Precio invalido");
            }

            if (Validar.ValidarStringToInt(txtCantidadDeProductos.Text) == 0)
            {
                validacionCantidad = false;
                MessageBox.Show("Cantidad invalida");
            }

            if (Validar.ValidarString(txtMarca.Text) == "")
            {
                validacionMarca = false;
                MessageBox.Show("Marca invalida");
            }

            if (chkEsCelular.Checked == true)
            {
                if (celularNegocio.VerificarCelular(txtIdProducto.Text) == true)
                {
                    if (Validar.ValidarString(txtIdProducto.Text) == "")
                    {
                        validacionIdProducto = false;
                        MessageBox.Show("ID Producto invalido");
                    }

                    if (Validar.ValidarString(txtPantalla.Text) == "")
                    {
                        validacionPantalla = false;
                        MessageBox.Show("Pantalla invalida");
                    }

                    if (Validar.ValidarString(txtMicro.Text) == "")
                    {
                        validacionMicro = false;
                        MessageBox.Show("Microprocesador invalido");
                    }

                    if (validacionNombre == true && validacionPrecio == true && validacionCantidad == true && validacionIdProducto == true && validacionMarca == true && validacionPantalla == true && validacionMicro == true)
                    {
                        Celular celular = new Celular(txtNombre.Text, Convert.ToInt32(txtPrecio.Text), Convert.ToInt32(txtCantidadDeProductos.Text), txtIdProducto.Text, txtMarca.Text, txtPantalla.Text, txtMicro.Text);

                        if (Negocio.ListaCelulares + celular == true)
                        {
                            celularNegocio.InsertarCelular(celular);
                            MessageBox.Show("Celular agregado");
                            GetDataSource();
                            GetProductoEspecifico("Celulares");
                            LimpiarDatos();
                        }

                        else
                        {
                            MessageBox.Show("Ya existe un celular con esos datos");
                            GetDataSource();
                            GetProductoEspecifico("Celulares");
                            LimpiarDatos();
                        }
                    }
                }

                else
                {
                    MessageBox.Show("IdProducto repetido");
                }
            }

            else
            {
                if (tecladoNegocio.VerificarTeclado(txtIdProducto.Text) == true)
                {
                    if (Validar.ValidarString(txtIdProducto.Text) == "")
                    {
                        validacionIdProducto = false;
                        MessageBox.Show("ID Producto invalido");
                    }

                    if (Validar.ValidarString(txtTipo.Text) == "")
                    {
                        validacionMicro = false;
                        MessageBox.Show("Tipo invalido");
                    }

                    if (validacionNombre == true && validacionPrecio == true && validacionCantidad == true && validacionIdProducto == true && validacionMarca == true && validacionTipo == true)
                    {
                        Teclado teclado = new Teclado(txtNombre.Text, Convert.ToInt32(txtPrecio.Text), Convert.ToInt32(txtCantidadDeProductos.Text), txtIdProducto.Text, txtMarca.Text, txtTipo.Text);

                        if (Negocio.ListaTeclados + teclado == true)
                        {
                            tecladoNegocio.InsertarTeclado(teclado);
                            Teclado.TecladoRepetidoSuma(teclado);

                            MessageBox.Show("Teclado agregado");
                            GetDataSource();
                            GetProductoEspecifico("Teclados");
                            LimpiarDatos();
                        }

                        else
                        {
                            MessageBox.Show("Ya existe un teclado con esos datos");
                            GetDataSource();
                            GetProductoEspecifico("Teclados");
                            LimpiarDatos();
                        }
                    }
                }

                else
                {
                    MessageBox.Show("IdProducto repetido");
                }
            }
        }
        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            bool variable = false;

            List<Celular> listaCelularesAEliminar = new List<Celular>();
            List<Teclado> listaTecladosAEliminar = new List<Teclado>();

            if (TipoProducto == "Celulares")
            {
                for (int i = 0; i < dataGridViewProductos.Rows.Count; i++)
                {

                    if (Convert.ToBoolean(dataGridViewProductos.Rows[i].Cells[0].Value) == true)
                    {
                        Celular celularAEliminar = new Celular();

                        celularAEliminar.Nombre = Negocio.ListaCelulares[i].Nombre;
                        celularAEliminar.Precio = Negocio.ListaCelulares[i].Precio;
                        celularAEliminar.Cantidad = Negocio.ListaCelulares[i].Cantidad;
                        celularAEliminar.IdProducto = Negocio.ListaCelulares[i].IdProducto;
                        celularAEliminar.Marca = Negocio.ListaCelulares[i].Marca;
                        celularAEliminar.Pantalla = Negocio.ListaCelulares[i].Pantalla;
                        celularAEliminar.Microprocesador = Negocio.ListaCelulares[i].Microprocesador;

                        listaCelularesAEliminar.Add(celularAEliminar);
                    }
                }

                for (int i = 0; i < listaCelularesAEliminar.Count; i++)
                {
                    if (Negocio.ListaCelulares - listaCelularesAEliminar[i])
                    {
                        variable = true;
                    }
                }

                if (variable == true)
                {
                    foreach (var item in listaCelularesAEliminar)
                    {
                        celularNegocio.EliminarCelular(item);
                    }

                    MessageBox.Show("Celular/es eliminado/os");
                    GetDataSource();
                    GetProductoEspecifico("Celulares");
                    LimpiarDatos();
                }

                else
                {
                    MessageBox.Show("Seleccione el/los celulares que quiere eliminar");
                    LimpiarDatos();
                }

            }

            else
            {
                for (int i = 0; i < dataGridViewProductos.Rows.Count; i++)
                {

                    if (Convert.ToBoolean(dataGridViewProductos.Rows[i].Cells[0].Value) == true)
                    {
                        Teclado tecladoAEliminar = new Teclado();

                        tecladoAEliminar.Nombre = Negocio.ListaTeclados[i].Nombre;
                        tecladoAEliminar.Precio = Negocio.ListaTeclados[i].Precio;
                        tecladoAEliminar.Cantidad = Negocio.ListaTeclados[i].Cantidad;
                        tecladoAEliminar.IdProducto = Negocio.ListaTeclados[i].IdProducto;
                        tecladoAEliminar.Marca = Negocio.ListaTeclados[i].Marca;
                        tecladoAEliminar.Tipo = Negocio.ListaTeclados[i].Tipo;

                        listaTecladosAEliminar.Add(tecladoAEliminar);
                    }
                }

                for (int i = 0; i < listaTecladosAEliminar.Count; i++)
                {
                    if (Negocio.ListaTeclados - listaTecladosAEliminar[i])
                    {
                        variable = true;
                    }
                }

                if (variable == true)
                {
                    foreach (var item in listaTecladosAEliminar)
                    {
                        tecladoNegocio.EliminarTeclado(item);
                    }

                    MessageBox.Show("Teclado/os eliminado/os");
                    GetDataSource();
                    GetProductoEspecifico("Teclados");
                    LimpiarDatos();
                }

                else
                {
                    MessageBox.Show("Seleccione el/los teclados que quiere eliminar");
                    LimpiarDatos();
                }
            }
        }
        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            bool variable = false;

            Celular celularModificado = new Celular();
            Teclado tecladoModificado = new Teclado();

            if (TipoProducto == "Celulares")
            {
                for (int i = 0; i < Negocio.ListaCelulares.Count; i++)
                {
                    if (Convert.ToBoolean(dataGridViewProductos.Rows[i].Cells[0].Value) == true)
                    {
                        celularModificado.Nombre = txtNombre.Text;
                        celularModificado.Precio = Validar.ValidarStringToFloat(txtPrecio.Text);
                        celularModificado.Cantidad = Convert.ToInt32(txtCantidadDeProductos.Text);
                        celularModificado.IdProducto = txtIdProducto.Text;
                        celularModificado.Marca = txtMarca.Text;
                        celularModificado.Pantalla = txtPantalla.Text;
                        celularModificado.Microprocesador = txtMicro.Text;

                        variable = true;
                    }

                }

                if (variable == true)
                {
                    celularNegocio.ModificarCelular(celularModificado);
                    MessageBox.Show("Celular modificado");
                    GetDataSource();
                    GetProductoEspecifico("Celulares");
                    LimpiarDatos();
                    txtIdProducto.Enabled = true;
                }

                else
                {
                    MessageBox.Show("Seleccione el celular que quiere modificar");
                    LimpiarDatos();
                }
            }

            else
            {
                for (int i = 0; i < Negocio.ListaTeclados.Count; i++)
                {
                    if (Convert.ToBoolean(dataGridViewProductos.Rows[i].Cells[0].Value) == true)
                    {
                        tecladoModificado.Nombre = txtNombre.Text;
                        tecladoModificado.Precio = Validar.ValidarStringToFloat(txtPrecio.Text);
                        tecladoModificado.Cantidad = Convert.ToInt32(txtCantidadDeProductos.Text);
                        tecladoModificado.IdProducto = txtIdProducto.Text;
                        tecladoModificado.Marca = txtMarca.Text;
                        tecladoModificado.Tipo = txtTipo.Text;

                        variable = true;
                    }

                }

                if (variable == true)
                {
                    tecladoNegocio.ModificarTeclado(tecladoModificado);
                    MessageBox.Show("Teclado modificado");
                    GetDataSource();
                    GetProductoEspecifico("Teclados");
                    LimpiarDatos();
                    txtIdProducto.Enabled = true;
                }

                else
                {
                    MessageBox.Show("Seleccione el teclado que quiere modificar");
                    LimpiarDatos();
                }

            }

            txtIdProducto.ReadOnly = false;
        }
        private void dataGridViewProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   
            btnEliminarProducto.Enabled = true;

            int contador = 0;

            if (TipoProducto == "Celulares")
            {
                for (int i = 0; i < dataGridViewProductos.Rows.Count; i++)
                {
                    if (dataGridViewProductos.Rows[i].Cells["Seleccionar"].Value != null)
                    {
                        bool tilde = (bool)dataGridViewProductos.Rows[i].Cells["Seleccionar"].Value;

                        if (tilde == true)
                        {
                            contador++;
                        }
                    }
                }

                if (contador == 1)
                {
                    btnModificarProducto.Enabled = true;

                    if (e.RowIndex != -1)
                    {
                        for (int i = 0; i < Negocio.ListaCelulares.Count; i++)
                        {

                            if (Convert.ToBoolean(dataGridViewProductos.Rows[i].Cells[0].Value) == true)
                            {
                                txtNombre.Text = Negocio.ListaCelulares[i].Nombre;
                                txtPrecio.Text = Negocio.ListaCelulares[i].Precio.ToString();
                                txtCantidadDeProductos.Text = Negocio.ListaCelulares[i].Cantidad.ToString();
                                txtIdProducto.Text = Negocio.ListaCelulares[i].IdProducto;
                                txtMarca.Text = Negocio.ListaCelulares[i].Marca;
                                txtPantalla.Text = Negocio.ListaCelulares[i].Pantalla;
                                txtMicro.Text = Negocio.ListaCelulares[i].Microprocesador;
                            }
                        }
                    }
                }

                else
                {
                    btnModificarProducto.Enabled = false;
                    LimpiarDatos();
                }
            }

            else
            {
                for (int i = 0; i < dataGridViewProductos.Rows.Count; i++)
                {
                    if (dataGridViewProductos.Rows[i].Cells["Seleccionar"].Value != null)
                    {
                        bool tilde = (bool)dataGridViewProductos.Rows[i].Cells["Seleccionar"].Value;

                        if (tilde == true)
                        {
                            contador++;
                        }
                    }
                }

                if (contador == 1)
                {
                    btnModificarProducto.Enabled = true;

                    if (e.RowIndex != -1)
                    {
                        for (int i = 0; i < Negocio.ListaTeclados.Count; i++)
                        {

                            if (Convert.ToBoolean(dataGridViewProductos.Rows[i].Cells[0].Value) == true)
                            {
                                txtNombre.Text = Negocio.ListaTeclados[i].Nombre;
                                txtPrecio.Text = Negocio.ListaTeclados[i].Precio.ToString();
                                txtCantidadDeProductos.Text = Negocio.ListaTeclados[i].Cantidad.ToString();
                                txtIdProducto.Text = Negocio.ListaTeclados[i].IdProducto;
                                txtMarca.Text = Negocio.ListaTeclados[i].Marca;
                                txtTipo.Text = Negocio.ListaTeclados[i].Tipo;
                            }
                        }
                    }
                }

                else
                {
                    btnModificarProducto.Enabled = false;
                    LimpiarDatos();
                }
            }
        }
        private void dataGridViewProductos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewProductos.IsCurrentCellDirty)
            {
                dataGridViewProductos.CommitEdit(DataGridViewDataErrorContexts.Commit);
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
            txtPrecio.Text = "";
            txtCantidadDeProductos.Text = "";
            txtIdProducto.Text = "";
            txtMarca.Text = "";
            txtPantalla.Text = "";
            txtMicro.Text = "";
            txtTipo.Text = "";
        }
        private void FrmVentas_Load(object sender, EventArgs e)
        {
            lblPantalla.Visible = false;
            lblMicro.Visible = false;

            GetDataSource();
            CargarComboCliente();
            CargarVendedor();
        }
        private void FrmVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Negocio.ListaProductos.Count == 0)
            {
                Negocio.TodoBorradoProductos = true;
            }

            this.Dispose();
            this.Close();
        }
        private void btnCelulares_Click(object sender, EventArgs e)
        {
            TipoProducto = "Celulares";

            dataGridViewProductos.DataSource = null;
            celularNegocio.CargarCelulares();
            dataGridViewProductos.DataSource = Negocio.ListaCelulares;

            dataGridViewProductos.AutoResizeRows();

            dataGridViewProductos.Columns[1].ReadOnly = true;
            dataGridViewProductos.Columns[2].ReadOnly = true;
            dataGridViewProductos.Columns[3].ReadOnly = true;
            dataGridViewProductos.Columns[4].ReadOnly = true;
            dataGridViewProductos.Columns[5].ReadOnly = true;
        }
        private void btnTeclados_Click(object sender, EventArgs e)
        {
            TipoProducto = "Teclados";

            dataGridViewProductos.DataSource = null;
            tecladoNegocio.CargarTeclados();
            dataGridViewProductos.DataSource = Negocio.ListaTeclados;

            dataGridViewProductos.AutoResizeRows();

            dataGridViewProductos.Columns[1].ReadOnly = true;
            dataGridViewProductos.Columns[2].ReadOnly = true;
            dataGridViewProductos.Columns[3].ReadOnly = true;
            dataGridViewProductos.Columns[4].ReadOnly = true;
            dataGridViewProductos.Columns[5].ReadOnly = true;
            dataGridViewProductos.Columns[6].ReadOnly = true;
        }
        private void btnCargarRich_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewProductos.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridViewProductos.Rows[i].Cells[0].Value) == true)
                {
                    if (TipoProducto == "Celulares")
                    {
                        Celular cel = new Celular(dataGridViewProductos.Rows[i].Cells["Nombre"].Value.ToString(), Convert.ToInt32(dataGridViewProductos.Rows[i].Cells["Precio"].Value.ToString()), Convert.ToInt32(dataGridViewProductos.Rows[i].Cells["Cantidad"].Value) -1 , dataGridViewProductos.Rows[i].Cells["IdProducto"].Value.ToString(), dataGridViewProductos.Rows[i].Cells["Marca"].Value.ToString(), dataGridViewProductos.Rows[i].Cells["Pantalla"].Value.ToString(), dataGridViewProductos.Rows[i].Cells["MIcroprocesador"].Value.ToString());

                        if (Negocio.ListaCelulares[i].Cantidad != 0)
                        {
                            Negocio.ListaCelulares.Add(cel);
                            Negocio.ListaCelulares[i].Cantidad = Negocio.ListaCelulares[i].Cantidad - 1;

                            Venta venta = new Venta(cel.Nombre, cel.Precio, 1, cel.IdProducto, ventaNegocio.NewIdVentas(), cel.Marca, "", cel.Pantalla, cel.Microprocesador);
                            listPreviaVenta.Add(venta);
                            
                            GetProductoEspecifico("Celulares");

                            richTextBoxVentas.Text += venta.Nombre + " " + venta.Precio + " " + venta.Cantidad + " " + venta.IdProducto + " " + venta.Marca + " " + venta.Pantalla + " " + venta.Microprocesador + " " + System.Environment.NewLine;
                        }

                        else
                        {
                            MessageBox.Show("No hay stock del producto " + cel.Nombre);
                        }

                    }

                    else
                    {
                        Teclado teclado = new Teclado(dataGridViewProductos.Rows[i].Cells["Nombre"].Value.ToString(), float.Parse(dataGridViewProductos.Rows[i].Cells["Precio"].Value.ToString()), 1, dataGridViewProductos.Rows[i].Cells["IdProducto"].Value.ToString(), dataGridViewProductos.Rows[i].Cells["Marca"].Value.ToString(), dataGridViewProductos.Rows[i].Cells["Tipo"].Value.ToString());

                        if (Negocio.ListaTeclados[i].Cantidad != 0)
                        {
                            Negocio.ListaTeclados.Add(teclado);
                            Negocio.ListaTeclados[i].Cantidad = Negocio.ListaTeclados[i].Cantidad - 1;

                            Venta venta = new Venta(teclado.Nombre, teclado.Precio, 1, teclado.IdProducto, ventaNegocio.NewIdVentas(), teclado.Marca, teclado.Tipo);
                            listPreviaVenta.Add(venta);

                            GetProductoEspecifico("Teclados");

                            richTextBoxVentas.Text += venta.Nombre + " " + venta.Precio + " " + venta.Cantidad + " " + venta.IdProducto + " " + venta.Marca + " " + venta.Tipo + System.Environment.NewLine;
                        }

                        else
                        {
                            MessageBox.Show("No hay stock del producto " + teclado.Nombre);
                        }
                    }
                }
            }
        }
        private void chkEsCelular_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEsCelular.Checked == true)
            {
                lblPantalla.Visible = true;
                lblMicro.Visible = true;
                lblTipo.Visible = false;

                txtPantalla.Visible = true;
                txtMicro.Visible = true;
                txtTipo.Visible = false;
            }

            else
            {
                lblPantalla.Visible = false;
                lblMicro.Visible = false;
                lblTipo.Visible = true;

                txtPantalla.Visible = false;
                txtMicro.Visible = false;
                txtTipo.Visible = true;
            }
        }
        private void btnComprar_Click(object sender, EventArgs e)

        {

            for (int i = 0; i < listPreviaVenta.Count; i++)
            {
                if (listPreviaVenta[i].Pantalla != "" && listPreviaVenta[i].Microprocesador != "")
                {
                    celularNegocio.ModificarCelular(new Celular(listPreviaVenta[i].Nombre, listPreviaVenta[i].Precio, Negocio.ListaCelulares[i].Cantidad - 1, listPreviaVenta[i].IdProducto, listPreviaVenta[i].Marca, listPreviaVenta[i].Pantalla, listPreviaVenta[i].Microprocesador));
                }
                else
                {
                    tecladoNegocio.ModificarTeclado(new Teclado(listPreviaVenta[i].Nombre, listPreviaVenta[i].Precio, Negocio.ListaTeclados[i].Cantidad - 1, listPreviaVenta[i].IdProducto, listPreviaVenta[i].Marca, listPreviaVenta[i].Tipo));
                }


                if (ventaNegocio.VerificarVenta(listPreviaVenta[i].IdProducto, listPreviaVenta[i].IdVenta) == false)
                {
                    listPreviaVenta[i].Cantidad++;
                    ventaNegocio.ModificarVenta(listPreviaVenta[i]);
                    ventaNegocio.CargarVentas();
                }
                else
                {
                    listPreviaVenta[i].Cantidad = 1;
                    ventaNegocio.InsertarVenta(listPreviaVenta[i]);
                    ventaNegocio.CargarVentas();
                }
            }

            string mensaje = "";
            string comprador = "";
            string vendedor = "";

            for (int i = 0; i < listPreviaVenta.Count; i++)
            {
                comprador = "Compra realizada por: " + comboBoxNombreCliente.Text + " " + comboBoxApellidoCliente.Text + "\r\n";
                vendedor = "Venta realizada por: " + txtEmpleado.Text + "\r\n";
                mensaje += "Producto: " + listPreviaVenta[i].Nombre + "\r\n" + "Precio: $" + listPreviaVenta[i].Precio + "\r\n" + "Cantidad: " + listPreviaVenta[i].Cantidad + "\r\n";
            }


            mensaje += "Cantidad total: " + Producto.CantidadTotalProductos(listPreviaVenta) + "\r\n" + "Precio total: $" + Producto.SumaProductos(listPreviaVenta);

            MessageBox.Show(mensaje);
            MessageBox.Show("Gracias por su compra !!!");

            sonido = new SoundPlayer(Application.StartupPath + @"\sonido\CajaRegistradora.wav");
            sonido.Play();

            SerializacionTXT serializar = new SerializacionTXT();
            serializar.Guardar(RutaDeArchivos.PATHCOMPRASTXT, "Compra_" + ventaNegocio.NewIdVentas() + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year  + ".txt", comprador + mensaje);
            serializar.Guardar(RutaDeArchivos.PATHVENTASTXT, "Ventas_"  + ventaNegocio.NewIdVentas() + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + ".txt", vendedor + mensaje);
            
            transfiero += new TransferenciaDeDatos(cargarCombo);

            transfiero();

            Hilo();

            if (!frmVentasRealizadas.Visible)
            {
                frmVentasRealizadas.Show();
            }
        }


        public void CargarComboCliente()
        {
            clienteNegocio.CargarClientes();
            this.comboBoxNombreCliente.DataSource = Negocio.ListaClientes;
            this.comboBoxNombreCliente.ValueMember = "Nombre";
            this.comboBoxNombreCliente.DisplayMember = "Nombre";

            this.comboBoxApellidoCliente.DataSource = Negocio.ListaClientes;
            this.comboBoxApellidoCliente.ValueMember = "Apellido";
            this.comboBoxApellidoCliente.DisplayMember = "Apellido";
        }
        public void CargarVendedor()
        {
            empleadoNegocio.CargarEmpleados();
            this.comboBoxVendedor.DataSource = Negocio.ListaEmpleados;
            this.comboBoxVendedor.ValueMember = "Nombre";
            this.comboBoxVendedor.DisplayMember = "Nombre";
        }
        public void CargarComboIdVenta()
        {
            FrmVentasRealizadas frmVentasRealizadas = new FrmVentasRealizadas();

            if (frmVentasRealizadas.cbIdVenta.InvokeRequired)
            {
                frmVentasRealizadas.cbIdVenta.BeginInvoke((MethodInvoker)delegate ()
                {
                    frmVentasRealizadas.cbIdVenta.DataSource = Negocio.ListaVentas;
                    frmVentasRealizadas.cbIdVenta.DisplayMember = "idVenta";
                    frmVentasRealizadas.cbIdVenta.ValueMember = "idVenta";
                    frmVentasRealizadas.cbIdVenta.Refresh();
                });
            }
            else
            {

                frmVentasRealizadas.cbIdVenta.DataSource = Negocio.ListaVentas;
                frmVentasRealizadas.cbIdVenta.DisplayMember = "idProducto";
                frmVentasRealizadas.cbIdVenta.ValueMember = "idProducto";
                frmVentasRealizadas.cbIdVenta.Refresh();
            }
        }

        public void Hilo()
        {
            Thread hiloUno = new Thread(cargarGrilla);
            
            hiloUno.Start();
        }
        public void cargarCombo()
        {

            if (frmVentasRealizadas.cbIdVenta.InvokeRequired)
            {
                frmVentasRealizadas.cbIdVenta.BeginInvoke((MethodInvoker)delegate ()
                {

                    
                    frmVentasRealizadas.cbIdVenta.Items.Clear();
                    bool existe = false;
                 
                    for (int i = 0; i < Negocio.ListaVentas.Count; i++)
                    {

                        for (int j = 0; j < frmVentasRealizadas.cbIdVenta.Items.Count; j++)
                        {
                            if (Negocio.ListaVentas[i].IdProducto == frmVentasRealizadas.cbIdVenta.Items[j].ToString())
                            {
                                existe = true;
                                break;
                            }
                        }
                       
                        if (existe == false)
                        {
                            frmVentasRealizadas.cbIdVenta.Items.Add(Negocio.ListaVentas[i].IdProducto);
                        }
                        
                    }
                   
                    frmVentasRealizadas.cbIdVenta.DisplayMember = "idVenta";
                    frmVentasRealizadas.cbIdVenta.ValueMember = "idVenta";
                    frmVentasRealizadas.cbIdVenta.Refresh();
                });
            }
            else
            {
                frmVentasRealizadas.cbIdVenta.Items.Clear();
                bool existe = false;

                for (int i = 0; i < Negocio.ListaVentas.Count; i++)
                {

                    for (int j = 0; j < frmVentasRealizadas.cbIdVenta.Items.Count; j++)
                    {
                        if (Negocio.ListaVentas[i].IdProducto == frmVentasRealizadas.cbIdVenta.Items[j].ToString())
                        {
                            existe = true;
                            break;
                        }
                    }
                    
                    if (existe == false)
                    {
                        frmVentasRealizadas.cbIdVenta.Items.Add(Negocio.ListaVentas[i].IdProducto);
                    }

                }
                
                frmVentasRealizadas.cbIdVenta.DisplayMember = "idVenta";
                frmVentasRealizadas.cbIdVenta.ValueMember = "idVenta";
                frmVentasRealizadas.cbIdVenta.Refresh();

            }

        }

        public void cargarGrilla()
        {
            if (frmVentasRealizadas.dataGridViewProductos.InvokeRequired)
            {
                frmVentasRealizadas.dataGridViewProductos.BeginInvoke((MethodInvoker)delegate ()
                {
                   
                    frmVentasRealizadas.dataGridViewProductos.Rows.Clear();

                    for (int i = 0; i < Negocio.ListaVentas.Count; i++)
                    {
                       

                        DataGridViewRow nuevaRow = new DataGridViewRow();



                        frmVentasRealizadas.dataGridViewProductos.Rows.Insert(0, nuevaRow);
                        frmVentasRealizadas.dataGridViewProductos.Rows[0].Cells["Nombre"].Value = Negocio.ListaVentas[i].Nombre;
                        frmVentasRealizadas.dataGridViewProductos.Rows[0].Cells["Precio"].Value = Negocio.ListaVentas[i].Precio;
                        frmVentasRealizadas.dataGridViewProductos.Rows[0].Cells["Cantidad"].Value = Negocio.ListaVentas[i].Cantidad;
                        frmVentasRealizadas.dataGridViewProductos.Rows[0].Cells["IdProducto"].Value = Negocio.ListaVentas[i].IdProducto;
                        frmVentasRealizadas.dataGridViewProductos.Rows[0].Cells["IdVenta"].Value = Negocio.ListaVentas[i].IdVenta;
                        frmVentasRealizadas.dataGridViewProductos.Rows[0].Cells["Marca"].Value = Negocio.ListaVentas[i].Marca;
                        frmVentasRealizadas.dataGridViewProductos.Rows[0].Cells["Tipo"].Value = Negocio.ListaVentas[i].Tipo;
                        frmVentasRealizadas.dataGridViewProductos.Rows[0].Cells["Pantalla"].Value = Negocio.ListaVentas[i].Pantalla;
                        frmVentasRealizadas.dataGridViewProductos.Rows[0].Cells["Microprocesador"].Value = Negocio.ListaVentas[i].Microprocesador;


                    }
                });
            }
            else
            {
                frmVentasRealizadas.dataGridViewProductos.Rows.Clear();
                for (int i = 0; i < Negocio.ListaVentas.Count; i++)
                {

                    CrearRowEnBlanco();
                    frmVentasRealizadas.dataGridViewProductos.Rows[0].Cells["Nombre"].Value = Negocio.ListaVentas[i].Nombre;
                    frmVentasRealizadas.dataGridViewProductos.Rows[0].Cells["Precio"].Value = Negocio.ListaVentas[i].Precio;
                    frmVentasRealizadas.dataGridViewProductos.Rows[0].Cells["Cantidad"].Value = Negocio.ListaVentas[i].Cantidad;
                    frmVentasRealizadas.dataGridViewProductos.Rows[0].Cells["IdProducto"].Value = Negocio.ListaVentas[i].IdProducto;
                    frmVentasRealizadas.dataGridViewProductos.Rows[0].Cells["IdVenta"].Value = Negocio.ListaVentas[i].IdVenta;
                    frmVentasRealizadas.dataGridViewProductos.Rows[0].Cells["Marca"].Value = Negocio.ListaVentas[i].Marca;
                    frmVentasRealizadas.dataGridViewProductos.Rows[0].Cells["Tipo"].Value = Negocio.ListaVentas[i].Tipo;
                    frmVentasRealizadas.dataGridViewProductos.Rows[0].Cells["Pantalla"].Value = Negocio.ListaVentas[i].Pantalla;
                    frmVentasRealizadas.dataGridViewProductos.Rows[0].Cells["Microprocesador"].Value = Negocio.ListaVentas[i].Microprocesador;


                }
            }
        }

        public void CrearRowEnBlanco()
        {
            DataGridViewRow nuevaRow = new DataGridViewRow();
            frmVentasRealizadas.dataGridViewProductos.Rows.Insert(0, nuevaRow);
        }
    }
}
