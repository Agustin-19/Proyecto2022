namespace Desktop.Views
{
    partial class FrmClientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TabClientes = new System.Windows.Forms.TabControl();
            this.TabEditarClientes = new System.Windows.Forms.TabPage();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.TxtDireccion = new System.Windows.Forms.TextBox();
            this.comboBoxLocalidades = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nudId = new System.Windows.Forms.NumericUpDown();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtTelefono = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDni = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TabListadoCliente = new System.Windows.Forms.TabPage();
            this.gridClientes = new System.Windows.Forms.DataGridView();
            this.BtnEliminar = new FontAwesome.Sharp.IconButton();
            this.BtnEditar = new FontAwesome.Sharp.IconButton();
            this.BtnBuscar = new FontAwesome.Sharp.IconButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.TabClientes.SuspendLayout();
            this.TabEditarClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudId)).BeginInit();
            this.TabListadoCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.panel1.Controls.Add(this.TabClientes);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 376);
            this.panel1.TabIndex = 2;
            // 
            // TabClientes
            // 
            this.TabClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabClientes.Controls.Add(this.TabEditarClientes);
            this.TabClientes.Controls.Add(this.TabListadoCliente);
            this.TabClientes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TabClientes.Location = new System.Drawing.Point(12, 12);
            this.TabClientes.Name = "TabClientes";
            this.TabClientes.SelectedIndex = 0;
            this.TabClientes.Size = new System.Drawing.Size(761, 352);
            this.TabClientes.TabIndex = 2;
            // 
            // TabEditarClientes
            // 
            this.TabEditarClientes.BackColor = System.Drawing.Color.DarkGray;
            this.TabEditarClientes.Controls.Add(this.TxtEmail);
            this.TabEditarClientes.Controls.Add(this.TxtDireccion);
            this.TabEditarClientes.Controls.Add(this.comboBoxLocalidades);
            this.TabEditarClientes.Controls.Add(this.label10);
            this.TabEditarClientes.Controls.Add(this.label9);
            this.TabEditarClientes.Controls.Add(this.label8);
            this.TabEditarClientes.Controls.Add(this.nudId);
            this.TabEditarClientes.Controls.Add(this.btnCancelar);
            this.TabEditarClientes.Controls.Add(this.btnGuardar);
            this.TabEditarClientes.Controls.Add(this.label7);
            this.TabEditarClientes.Controls.Add(this.label5);
            this.TabEditarClientes.Controls.Add(this.TxtTelefono);
            this.TabEditarClientes.Controls.Add(this.label4);
            this.TabEditarClientes.Controls.Add(this.TxtApellido);
            this.TabEditarClientes.Controls.Add(this.label3);
            this.TabEditarClientes.Controls.Add(this.TxtDni);
            this.TabEditarClientes.Controls.Add(this.label2);
            this.TabEditarClientes.Controls.Add(this.TxtNombre);
            this.TabEditarClientes.Controls.Add(this.label1);
            this.TabEditarClientes.ForeColor = System.Drawing.Color.Black;
            this.TabEditarClientes.Location = new System.Drawing.Point(4, 26);
            this.TabEditarClientes.Name = "TabEditarClientes";
            this.TabEditarClientes.Padding = new System.Windows.Forms.Padding(3);
            this.TabEditarClientes.Size = new System.Drawing.Size(753, 322);
            this.TabEditarClientes.TabIndex = 1;
            this.TabEditarClientes.Text = "Agregar Cliente";
            // 
            // TxtEmail
            // 
            this.TxtEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtEmail.Location = new System.Drawing.Point(16, 175);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(176, 25);
            this.TxtEmail.TabIndex = 4;
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtDireccion.Location = new System.Drawing.Point(354, 175);
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(206, 25);
            this.TxtDireccion.TabIndex = 6;
            // 
            // comboBoxLocalidades
            // 
            this.comboBoxLocalidades.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxLocalidades.FormattingEnabled = true;
            this.comboBoxLocalidades.Location = new System.Drawing.Point(567, 175);
            this.comboBoxLocalidades.Name = "comboBoxLocalidades";
            this.comboBoxLocalidades.Size = new System.Drawing.Size(169, 25);
            this.comboBoxLocalidades.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 19);
            this.label10.TabIndex = 71;
            this.label10.Text = "Codigo.";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 19);
            this.label9.TabIndex = 70;
            this.label9.Text = "Email.";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(567, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 19);
            this.label8.TabIndex = 69;
            this.label8.Text = "Localidad ";
            // 
            // nudId
            // 
            this.nudId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nudId.Enabled = false;
            this.nudId.Location = new System.Drawing.Point(16, 112);
            this.nudId.Name = "nudId";
            this.nudId.Size = new System.Drawing.Size(119, 25);
            this.nudId.TabIndex = 68;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.LightCoral;
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.btnCancelar.IconColor = System.Drawing.Color.LightCoral;
            this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize = 20;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(354, 285);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 31);
            this.btnCancelar.TabIndex = 67;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.PaleGreen;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar.IconColor = System.Drawing.Color.PaleGreen;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 20;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(244, 285);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(89, 31);
            this.btnGuardar.TabIndex = 66;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Perpetua Titling MT", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.PeachPuff;
            this.label7.Location = new System.Drawing.Point(152, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(323, 38);
            this.label7.TabIndex = 65;
            this.label7.Text = "Agregar Clientes";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(354, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 19);
            this.label5.TabIndex = 63;
            this.label5.Text = "Dirección";
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtTelefono.Location = new System.Drawing.Point(197, 175);
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.Size = new System.Drawing.Size(151, 25);
            this.TxtTelefono.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 19);
            this.label4.TabIndex = 62;
            this.label4.Text = "Telefono";
            // 
            // TxtApellido
            // 
            this.TxtApellido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtApellido.Location = new System.Drawing.Point(369, 112);
            this.TxtApellido.Name = "TxtApellido";
            this.TxtApellido.Size = new System.Drawing.Size(186, 25);
            this.TxtApellido.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 19);
            this.label3.TabIndex = 60;
            this.label3.Text = "Apellido";
            // 
            // TxtDni
            // 
            this.TxtDni.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtDni.Location = new System.Drawing.Point(561, 112);
            this.TxtDni.Name = "TxtDni";
            this.TxtDni.Size = new System.Drawing.Size(175, 25);
            this.TxtDni.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(561, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 19);
            this.label2.TabIndex = 57;
            this.label2.Text = "DNI";
            // 
            // TxtNombre
            // 
            this.TxtNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtNombre.Location = new System.Drawing.Point(141, 112);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(222, 25);
            this.TxtNombre.TabIndex = 1;
            this.TxtNombre.TextChanged += new System.EventHandler(this.TxtNombre_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 19);
            this.label1.TabIndex = 54;
            this.label1.Text = "Nombre";
            // 
            // TabListadoCliente
            // 
            this.TabListadoCliente.BackColor = System.Drawing.Color.DarkGray;
            this.TabListadoCliente.Controls.Add(this.gridClientes);
            this.TabListadoCliente.Controls.Add(this.BtnEliminar);
            this.TabListadoCliente.Controls.Add(this.BtnEditar);
            this.TabListadoCliente.Controls.Add(this.BtnBuscar);
            this.TabListadoCliente.Controls.Add(this.label6);
            this.TabListadoCliente.Controls.Add(this.label11);
            this.TabListadoCliente.Controls.Add(this.txtBusqueda);
            this.TabListadoCliente.Location = new System.Drawing.Point(4, 26);
            this.TabListadoCliente.Name = "TabListadoCliente";
            this.TabListadoCliente.Padding = new System.Windows.Forms.Padding(3);
            this.TabListadoCliente.Size = new System.Drawing.Size(753, 322);
            this.TabListadoCliente.TabIndex = 0;
            this.TabListadoCliente.Text = "Listado Clientes";
            // 
            // gridClientes
            // 
            this.gridClientes.AllowUserToAddRows = false;
            this.gridClientes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.gridClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridClientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.gridClientes.BackgroundColor = System.Drawing.Color.DarkGray;
            this.gridClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.gridClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Moccasin;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridClientes.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridClientes.EnableHeadersVisualStyles = false;
            this.gridClientes.GridColor = System.Drawing.Color.Black;
            this.gridClientes.Location = new System.Drawing.Point(13, 100);
            this.gridClientes.MinimumSize = new System.Drawing.Size(708, 216);
            this.gridClientes.Name = "gridClientes";
            this.gridClientes.ReadOnly = true;
            this.gridClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridClientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridClientes.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.gridClientes.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gridClientes.RowTemplate.Height = 25;
            this.gridClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridClientes.Size = new System.Drawing.Size(708, 216);
            this.gridClientes.TabIndex = 48;
            this.gridClientes.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridClientes_DataBindingComplete_1);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.ForeColor = System.Drawing.Color.LightCoral;
            this.BtnEliminar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.BtnEliminar.IconColor = System.Drawing.Color.LightCoral;
            this.BtnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnEliminar.IconSize = 20;
            this.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEliminar.Location = new System.Drawing.Point(630, 61);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(91, 33);
            this.BtnEliminar.TabIndex = 47;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditar.ForeColor = System.Drawing.Color.Khaki;
            this.BtnEditar.IconChar = FontAwesome.Sharp.IconChar.Pen;
            this.BtnEditar.IconColor = System.Drawing.Color.Khaki;
            this.BtnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnEditar.IconSize = 20;
            this.BtnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEditar.Location = new System.Drawing.Point(553, 61);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(71, 33);
            this.BtnEditar.TabIndex = 46;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.BtnEditar.UseVisualStyleBackColor = false;
            this.BtnEditar.Click += new System.EventHandler(this.TxtEditar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscar.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.BtnBuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.BtnBuscar.IconColor = System.Drawing.Color.MediumTurquoise;
            this.BtnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnBuscar.IconSize = 20;
            this.BtnBuscar.Location = new System.Drawing.Point(455, 61);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(36, 33);
            this.BtnBuscar.TabIndex = 45;
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.BtnBuscar.UseVisualStyleBackColor = false;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Prestige Elite Std", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Khaki;
            this.label6.Location = new System.Drawing.Point(137, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(318, 31);
            this.label6.TabIndex = 40;
            this.label6.Text = "Listado de Clientes";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 19);
            this.label11.TabIndex = 39;
            this.label11.Text = "Buscar Cliente:";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusqueda.Location = new System.Drawing.Point(131, 69);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(318, 25);
            this.txtBusqueda.TabIndex = 37;
            // 
            // FrmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 376);
            this.Controls.Add(this.panel1);
            this.Name = "FrmClientes";
            this.Text = "FrmClientes";
            this.panel1.ResumeLayout(false);
            this.TabClientes.ResumeLayout(false);
            this.TabEditarClientes.ResumeLayout(false);
            this.TabEditarClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudId)).EndInit();
            this.TabListadoCliente.ResumeLayout(false);
            this.TabListadoCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private TabControl TabClientes;
        private TabPage TabEditarClientes;
        private TabPage TabListadoCliente;
        private NumericUpDown nudId;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private Label label7;
        private Label label5;
        private TextBox TxtTelefono;
        private Label label4;
        private TextBox TxtApellido;
        private Label label3;
        private TextBox TxtDni;
        private Label label2;
        private TextBox TxtNombre;
        private Label label1;
        private Label label8;
        private Label label9;
        private Label label10;
        private ComboBox comboBoxLocalidades;
        private TextBox TxtEmail;
        private TextBox TxtDireccion;
        private FontAwesome.Sharp.IconButton BtnEliminar;
        private FontAwesome.Sharp.IconButton BtnEditar;
        private FontAwesome.Sharp.IconButton BtnBuscar;
        private Label label6;
        private Label label11;
        private TextBox txtBusqueda;
        private DataGridView gridClientes;
    }
}