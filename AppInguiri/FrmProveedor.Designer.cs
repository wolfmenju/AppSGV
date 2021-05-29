namespace AppInguiri
{
    partial class FrmProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProveedor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanOpciones = new System.Windows.Forms.Panel();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnRefrescar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.PanInferior = new System.Windows.Forms.Panel();
            this.ChkTodos = new System.Windows.Forms.CheckBox();
            this.LblTotal = new System.Windows.Forms.Label();
            this.PanTodo = new System.Windows.Forms.Panel();
            this.DgPresentacion = new System.Windows.Forms.DataGridView();
            this.IdPresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanOpciones.SuspendLayout();
            this.PanInferior.SuspendLayout();
            this.PanTodo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgPresentacion)).BeginInit();
            this.SuspendLayout();
            // 
            // PanOpciones
            // 
            this.PanOpciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.PanOpciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanOpciones.Controls.Add(this.BtnEliminar);
            this.PanOpciones.Controls.Add(this.BtnSalir);
            this.PanOpciones.Controls.Add(this.BtnRefrescar);
            this.PanOpciones.Controls.Add(this.BtnBuscar);
            this.PanOpciones.Controls.Add(this.BtnAgregar);
            this.PanOpciones.Controls.Add(this.BtnModificar);
            this.PanOpciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanOpciones.Location = new System.Drawing.Point(893, 0);
            this.PanOpciones.Name = "PanOpciones";
            this.PanOpciones.Size = new System.Drawing.Size(109, 482);
            this.PanOpciones.TabIndex = 12;
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnEliminar.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.ForeColor = System.Drawing.Color.Black;
            this.BtnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("BtnEliminar.Image")));
            this.BtnEliminar.Location = new System.Drawing.Point(3, 243);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(102, 52);
            this.BtnEliminar.TabIndex = 4;
            this.BtnEliminar.TabStop = false;
            this.BtnEliminar.Text = "&Eliminar  [F5]";
            this.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnEliminar.UseVisualStyleBackColor = true;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.BtnSalir.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.ForeColor = System.Drawing.Color.Black;
            this.BtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("BtnSalir.Image")));
            this.BtnSalir.Location = new System.Drawing.Point(3, 417);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(102, 52);
            this.BtnSalir.TabIndex = 5;
            this.BtnSalir.TabStop = false;
            this.BtnSalir.Text = "&Salir      [Esc]";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnSalir.UseVisualStyleBackColor = true;
            // 
            // BtnRefrescar
            // 
            this.BtnRefrescar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnRefrescar.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRefrescar.ForeColor = System.Drawing.Color.Black;
            this.BtnRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("BtnRefrescar.Image")));
            this.BtnRefrescar.Location = new System.Drawing.Point(3, 127);
            this.BtnRefrescar.Name = "BtnRefrescar";
            this.BtnRefrescar.Size = new System.Drawing.Size(102, 52);
            this.BtnRefrescar.TabIndex = 2;
            this.BtnRefrescar.TabStop = false;
            this.BtnRefrescar.Text = "&Recargar [F3]";
            this.BtnRefrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnRefrescar.UseVisualStyleBackColor = true;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnBuscar.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.ForeColor = System.Drawing.Color.Black;
            this.BtnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.Image")));
            this.BtnBuscar.Location = new System.Drawing.Point(3, 185);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(102, 52);
            this.BtnBuscar.TabIndex = 3;
            this.BtnBuscar.TabStop = false;
            this.BtnBuscar.Text = "  &Buscar  [F4]";
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnAgregar.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.ForeColor = System.Drawing.Color.Black;
            this.BtnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("BtnAgregar.Image")));
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAgregar.Location = new System.Drawing.Point(3, 11);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(102, 52);
            this.BtnAgregar.TabIndex = 0;
            this.BtnAgregar.TabStop = false;
            this.BtnAgregar.Text = "  &Nuevo  [F1]";
            this.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAgregar.UseVisualStyleBackColor = true;
            // 
            // BtnModificar
            // 
            this.BtnModificar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnModificar.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificar.ForeColor = System.Drawing.Color.Black;
            this.BtnModificar.Image = ((System.Drawing.Image)(resources.GetObject("BtnModificar.Image")));
            this.BtnModificar.Location = new System.Drawing.Point(3, 69);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(102, 52);
            this.BtnModificar.TabIndex = 1;
            this.BtnModificar.TabStop = false;
            this.BtnModificar.Text = "&Actualizar [F2]";
            this.BtnModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnModificar.UseVisualStyleBackColor = true;
            // 
            // PanInferior
            // 
            this.PanInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.PanInferior.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanInferior.Controls.Add(this.ChkTodos);
            this.PanInferior.Controls.Add(this.LblTotal);
            this.PanInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanInferior.Location = new System.Drawing.Point(0, 462);
            this.PanInferior.Name = "PanInferior";
            this.PanInferior.Size = new System.Drawing.Size(893, 20);
            this.PanInferior.TabIndex = 15;
            // 
            // ChkTodos
            // 
            this.ChkTodos.AutoSize = true;
            this.ChkTodos.Checked = true;
            this.ChkTodos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkTodos.Dock = System.Windows.Forms.DockStyle.Right;
            this.ChkTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkTodos.ForeColor = System.Drawing.Color.Blue;
            this.ChkTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChkTodos.Location = new System.Drawing.Point(821, 0);
            this.ChkTodos.Name = "ChkTodos";
            this.ChkTodos.Size = new System.Drawing.Size(68, 16);
            this.ChkTodos.TabIndex = 19;
            this.ChkTodos.Text = "Activos";
            this.ChkTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChkTodos.UseVisualStyleBackColor = true;
            // 
            // LblTotal
            // 
            this.LblTotal.AutoSize = true;
            this.LblTotal.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblTotal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotal.ForeColor = System.Drawing.Color.Blue;
            this.LblTotal.Location = new System.Drawing.Point(0, 0);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(174, 13);
            this.LblTotal.TabIndex = 17;
            this.LblTotal.Text = " Se Encontraron 00 Registros";
            // 
            // PanTodo
            // 
            this.PanTodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanTodo.Controls.Add(this.DgPresentacion);
            this.PanTodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanTodo.Location = new System.Drawing.Point(0, 0);
            this.PanTodo.Name = "PanTodo";
            this.PanTodo.Size = new System.Drawing.Size(893, 462);
            this.PanTodo.TabIndex = 16;
            // 
            // DgPresentacion
            // 
            this.DgPresentacion.AllowUserToAddRows = false;
            this.DgPresentacion.AllowUserToDeleteRows = false;
            this.DgPresentacion.AllowUserToResizeColumns = false;
            this.DgPresentacion.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.DgPresentacion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgPresentacion.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DgPresentacion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgPresentacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgPresentacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgPresentacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdPresentacion,
            this.Descripcion,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.DgPresentacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgPresentacion.Location = new System.Drawing.Point(0, 0);
            this.DgPresentacion.MultiSelect = false;
            this.DgPresentacion.Name = "DgPresentacion";
            this.DgPresentacion.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgPresentacion.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgPresentacion.RowHeadersVisible = false;
            this.DgPresentacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgPresentacion.Size = new System.Drawing.Size(891, 460);
            this.DgPresentacion.TabIndex = 11;
            // 
            // IdPresentacion
            // 
            this.IdPresentacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IdPresentacion.DataPropertyName = "IdProveedor";
            this.IdPresentacion.HeaderText = "IdProveedor";
            this.IdPresentacion.Name = "IdPresentacion";
            this.IdPresentacion.ReadOnly = true;
            this.IdPresentacion.Visible = false;
            this.IdPresentacion.Width = 73;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Descripcion.DataPropertyName = "Descripcion";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Descripcion.DefaultCellStyle = dataGridViewCellStyle3;
            this.Descripcion.HeaderText = "Razón Social";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 95;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Ruc";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Dirección";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Celular";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Contacto";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // FrmProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 482);
            this.ControlBox = false;
            this.Controls.Add(this.PanTodo);
            this.Controls.Add(this.PanInferior);
            this.Controls.Add(this.PanOpciones);
            this.KeyPreview = true;
            this.Name = "FrmProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimientos de Proveedor";
            this.PanOpciones.ResumeLayout(false);
            this.PanInferior.ResumeLayout(false);
            this.PanInferior.PerformLayout();
            this.PanTodo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgPresentacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel PanOpciones;
        internal System.Windows.Forms.Button BtnEliminar;
        internal System.Windows.Forms.Button BtnSalir;
        internal System.Windows.Forms.Button BtnRefrescar;
        internal System.Windows.Forms.Button BtnBuscar;
        internal System.Windows.Forms.Button BtnAgregar;
        internal System.Windows.Forms.Button BtnModificar;
        internal System.Windows.Forms.Panel PanInferior;
        internal System.Windows.Forms.CheckBox ChkTodos;
        internal System.Windows.Forms.Label LblTotal;
        internal System.Windows.Forms.Panel PanTodo;
        internal System.Windows.Forms.DataGridView DgPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}