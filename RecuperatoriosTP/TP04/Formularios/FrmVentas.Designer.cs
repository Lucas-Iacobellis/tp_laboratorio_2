namespace Formularios
{
    partial class FrmVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVentas));
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblCantidadDeProductos = new System.Windows.Forms.Label();
            this.lblIdProducto = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtCantidadDeProductos = new System.Windows.Forms.TextBox();
            this.txtIdProducto = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.dataGridViewProductos = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnModificarProducto = new System.Windows.Forms.Button();
            this.btnTeclados = new System.Windows.Forms.Button();
            this.btnCelulares = new System.Windows.Forms.Button();
            this.richTextBoxVentas = new System.Windows.Forms.RichTextBox();
            this.btnCargarRich = new System.Windows.Forms.Button();
            this.txtPantalla = new System.Windows.Forms.TextBox();
            this.txtMicro = new System.Windows.Forms.TextBox();
            this.lblPantalla = new System.Windows.Forms.Label();
            this.lblMicro = new System.Windows.Forms.Label();
            this.chkEsCelular = new System.Windows.Forms.CheckBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.btnComprar = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.comboBoxNombreCliente = new System.Windows.Forms.ComboBox();
            this.comboBoxApellidoCliente = new System.Windows.Forms.ComboBox();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.comboBoxVendedor = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(32, 112);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 19);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(32, 143);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(47, 19);
            this.lblPrecio.TabIndex = 3;
            this.lblPrecio.Text = "Precio";
            // 
            // lblCantidadDeProductos
            // 
            this.lblCantidadDeProductos.AutoSize = true;
            this.lblCantidadDeProductos.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadDeProductos.Location = new System.Drawing.Point(261, 145);
            this.lblCantidadDeProductos.Name = "lblCantidadDeProductos";
            this.lblCantidadDeProductos.Size = new System.Drawing.Size(64, 19);
            this.lblCantidadDeProductos.TabIndex = 4;
            this.lblCantidadDeProductos.Text = "Cantidad";
            // 
            // lblIdProducto
            // 
            this.lblIdProducto.AutoSize = true;
            this.lblIdProducto.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdProducto.Location = new System.Drawing.Point(561, 109);
            this.lblIdProducto.Name = "lblIdProducto";
            this.lblIdProducto.Size = new System.Drawing.Size(86, 19);
            this.lblIdProducto.TabIndex = 5;
            this.lblIdProducto.Text = "ID Producto";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(143, 110);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(261, 111);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(47, 19);
            this.lblMarca.TabIndex = 7;
            this.lblMarca.Text = "Marca";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(143, 144);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 8;
            // 
            // txtCantidadDeProductos
            // 
            this.txtCantidadDeProductos.Location = new System.Drawing.Point(401, 145);
            this.txtCantidadDeProductos.Name = "txtCantidadDeProductos";
            this.txtCantidadDeProductos.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadDeProductos.TabIndex = 9;
            // 
            // txtIdProducto
            // 
            this.txtIdProducto.Location = new System.Drawing.Point(689, 109);
            this.txtIdProducto.Name = "txtIdProducto";
            this.txtIdProducto.Size = new System.Drawing.Size(100, 20);
            this.txtIdProducto.TabIndex = 10;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(401, 112);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(100, 20);
            this.txtMarca.TabIndex = 11;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProducto.Location = new System.Drawing.Point(401, 53);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(88, 31);
            this.btnAgregarProducto.TabIndex = 12;
            this.btnAgregarProducto.Text = "Agregar";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.Enabled = false;
            this.btnEliminarProducto.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarProducto.Location = new System.Drawing.Point(509, 53);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(77, 31);
            this.btnEliminarProducto.TabIndex = 13;
            this.btnEliminarProducto.Text = "Eliminar";
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            // 
            // dataGridViewProductos
            // 
            this.dataGridViewProductos.AllowUserToDeleteRows = false;
            this.dataGridViewProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewProductos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.dataGridViewProductos.Location = new System.Drawing.Point(193, 263);
            this.dataGridViewProductos.Name = "dataGridViewProductos";
            this.dataGridViewProductos.Size = new System.Drawing.Size(307, 474);
            this.dataGridViewProductos.TabIndex = 0;
            this.dataGridViewProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProductos_CellContentClick);
            this.dataGridViewProductos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewProductos_CurrentCellDirtyStateChanged);
            // 
            // Seleccionar
            // 
            this.Seleccionar.Frozen = true;
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Width = 69;
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.Location = new System.Drawing.Point(860, 13);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(101, 28);
            this.btnAtras.TabIndex = 14;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnModificarProducto
            // 
            this.btnModificarProducto.Enabled = false;
            this.btnModificarProducto.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarProducto.Location = new System.Drawing.Point(606, 53);
            this.btnModificarProducto.Name = "btnModificarProducto";
            this.btnModificarProducto.Size = new System.Drawing.Size(82, 31);
            this.btnModificarProducto.TabIndex = 19;
            this.btnModificarProducto.Text = "Modificar";
            this.btnModificarProducto.UseVisualStyleBackColor = true;
            this.btnModificarProducto.Click += new System.EventHandler(this.btnModificarProducto_Click);
            // 
            // btnTeclados
            // 
            this.btnTeclados.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeclados.Location = new System.Drawing.Point(16, 323);
            this.btnTeclados.Name = "btnTeclados";
            this.btnTeclados.Size = new System.Drawing.Size(122, 27);
            this.btnTeclados.TabIndex = 20;
            this.btnTeclados.Text = "Ver Teclados";
            this.btnTeclados.UseVisualStyleBackColor = true;
            this.btnTeclados.Click += new System.EventHandler(this.btnTeclados_Click);
            // 
            // btnCelulares
            // 
            this.btnCelulares.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCelulares.Location = new System.Drawing.Point(16, 263);
            this.btnCelulares.Name = "btnCelulares";
            this.btnCelulares.Size = new System.Drawing.Size(122, 27);
            this.btnCelulares.TabIndex = 21;
            this.btnCelulares.Text = "Ver Celulares";
            this.btnCelulares.UseVisualStyleBackColor = true;
            this.btnCelulares.Click += new System.EventHandler(this.btnCelulares_Click);
            // 
            // richTextBoxVentas
            // 
            this.richTextBoxVentas.Location = new System.Drawing.Point(631, 224);
            this.richTextBoxVentas.Name = "richTextBoxVentas";
            this.richTextBoxVentas.Size = new System.Drawing.Size(305, 474);
            this.richTextBoxVentas.TabIndex = 22;
            this.richTextBoxVentas.Text = "";
            // 
            // btnCargarRich
            // 
            this.btnCargarRich.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarRich.Location = new System.Drawing.Point(539, 361);
            this.btnCargarRich.Name = "btnCargarRich";
            this.btnCargarRich.Size = new System.Drawing.Size(76, 66);
            this.btnCargarRich.TabIndex = 23;
            this.btnCargarRich.Text = "CARGAR";
            this.btnCargarRich.UseVisualStyleBackColor = true;
            this.btnCargarRich.Click += new System.EventHandler(this.btnCargarRich_Click);
            // 
            // txtPantalla
            // 
            this.txtPantalla.Location = new System.Drawing.Point(401, 184);
            this.txtPantalla.Name = "txtPantalla";
            this.txtPantalla.Size = new System.Drawing.Size(100, 20);
            this.txtPantalla.TabIndex = 27;
            this.txtPantalla.Visible = false;
            // 
            // txtMicro
            // 
            this.txtMicro.Location = new System.Drawing.Point(401, 224);
            this.txtMicro.Name = "txtMicro";
            this.txtMicro.Size = new System.Drawing.Size(100, 20);
            this.txtMicro.TabIndex = 26;
            this.txtMicro.Visible = false;
            // 
            // lblPantalla
            // 
            this.lblPantalla.AutoSize = true;
            this.lblPantalla.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPantalla.Location = new System.Drawing.Point(261, 185);
            this.lblPantalla.Name = "lblPantalla";
            this.lblPantalla.Size = new System.Drawing.Size(58, 19);
            this.lblPantalla.TabIndex = 25;
            this.lblPantalla.Text = "Pantalla";
            // 
            // lblMicro
            // 
            this.lblMicro.AutoSize = true;
            this.lblMicro.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMicro.Location = new System.Drawing.Point(261, 225);
            this.lblMicro.Name = "lblMicro";
            this.lblMicro.Size = new System.Drawing.Size(112, 19);
            this.lblMicro.TabIndex = 24;
            this.lblMicro.Text = "Microprocesador";
            // 
            // chkEsCelular
            // 
            this.chkEsCelular.AutoSize = true;
            this.chkEsCelular.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEsCelular.Location = new System.Drawing.Point(12, 81);
            this.chkEsCelular.Name = "chkEsCelular";
            this.chkEsCelular.Size = new System.Drawing.Size(143, 23);
            this.chkEsCelular.TabIndex = 28;
            this.chkEsCelular.Text = "Tilde si es celular";
            this.chkEsCelular.UseVisualStyleBackColor = true;
            this.chkEsCelular.CheckedChanged += new System.EventHandler(this.chkEsCelular_CheckedChanged);
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(689, 142);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(100, 20);
            this.txtTipo.TabIndex = 30;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(561, 143);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(36, 19);
            this.lblTipo.TabIndex = 29;
            this.lblTipo.Text = "Tipo";
            // 
            // btnComprar
            // 
            this.btnComprar.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprar.Location = new System.Drawing.Point(950, 352);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(84, 66);
            this.btnComprar.TabIndex = 31;
            this.btnComprar.Text = "COMPRAR";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(35, 9);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(52, 19);
            this.lblCliente.TabIndex = 32;
            this.lblCliente.Text = "Cliente";
            // 
            // comboBoxNombreCliente
            // 
            this.comboBoxNombreCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNombreCliente.FormattingEnabled = true;
            this.comboBoxNombreCliente.Location = new System.Drawing.Point(122, 7);
            this.comboBoxNombreCliente.Name = "comboBoxNombreCliente";
            this.comboBoxNombreCliente.Size = new System.Drawing.Size(121, 21);
            this.comboBoxNombreCliente.TabIndex = 33;
            // 
            // comboBoxApellidoCliente
            // 
            this.comboBoxApellidoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxApellidoCliente.FormattingEnabled = true;
            this.comboBoxApellidoCliente.Location = new System.Drawing.Point(265, 7);
            this.comboBoxApellidoCliente.Name = "comboBoxApellidoCliente";
            this.comboBoxApellidoCliente.Size = new System.Drawing.Size(121, 21);
            this.comboBoxApellidoCliente.TabIndex = 34;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendedor.Location = new System.Drawing.Point(35, 41);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(68, 19);
            this.lblVendedor.TabIndex = 35;
            this.lblVendedor.Text = "Vendedor";
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Location = new System.Drawing.Point(265, 53);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.ReadOnly = true;
            this.txtEmpleado.Size = new System.Drawing.Size(121, 20);
            this.txtEmpleado.TabIndex = 36;
            this.txtEmpleado.Visible = false;
            // 
            // comboBoxVendedor
            // 
            this.comboBoxVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVendedor.FormattingEnabled = true;
            this.comboBoxVendedor.Location = new System.Drawing.Point(122, 42);
            this.comboBoxVendedor.Name = "comboBoxVendedor";
            this.comboBoxVendedor.Size = new System.Drawing.Size(121, 21);
            this.comboBoxVendedor.TabIndex = 37;
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1028, 749);
            this.Controls.Add(this.comboBoxVendedor);
            this.Controls.Add(this.txtEmpleado);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.comboBoxApellidoCliente);
            this.Controls.Add(this.comboBoxNombreCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.chkEsCelular);
            this.Controls.Add(this.txtPantalla);
            this.Controls.Add(this.txtMicro);
            this.Controls.Add(this.lblPantalla);
            this.Controls.Add(this.lblMicro);
            this.Controls.Add(this.btnCargarRich);
            this.Controls.Add(this.richTextBoxVentas);
            this.Controls.Add(this.btnCelulares);
            this.Controls.Add(this.btnTeclados);
            this.Controls.Add(this.btnModificarProducto);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnEliminarProducto);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.txtIdProducto);
            this.Controls.Add(this.txtCantidadDeProductos);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblIdProducto);
            this.Controls.Add(this.lblCantidadDeProductos);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.dataGridViewProductos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVentas_FormClosing);
            this.Load += new System.EventHandler(this.FrmVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblCantidadDeProductos;
        private System.Windows.Forms.Label lblIdProducto;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtCantidadDeProductos;
        private System.Windows.Forms.TextBox txtIdProducto;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.DataGridView dataGridViewProductos;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnModificarProducto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.Button btnTeclados;
        private System.Windows.Forms.Button btnCelulares;
        private System.Windows.Forms.RichTextBox richTextBoxVentas;
        private System.Windows.Forms.Button btnCargarRich;
        private System.Windows.Forms.TextBox txtPantalla;
        private System.Windows.Forms.TextBox txtMicro;
        private System.Windows.Forms.Label lblPantalla;
        private System.Windows.Forms.Label lblMicro;
        private System.Windows.Forms.CheckBox chkEsCelular;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox comboBoxNombreCliente;
        private System.Windows.Forms.ComboBox comboBoxApellidoCliente;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.ComboBox comboBoxVendedor;
    }
}