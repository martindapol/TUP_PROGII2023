namespace CarpinteriaApp.formularios
{
    partial class FrmModificarPresupuesto
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtFinal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.cboProductos = new System.Windows.Forms.ComboBox();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.idProdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtDto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNroPresupuesto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(411, 376);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = " Total $";
            // 
            // txtFinal
            // 
            this.txtFinal.BackColor = System.Drawing.Color.White;
            this.txtFinal.Enabled = false;
            this.txtFinal.ForeColor = System.Drawing.Color.White;
            this.txtFinal.Location = new System.Drawing.Point(488, 381);
            this.txtFinal.MaxLength = 10;
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.Size = new System.Drawing.Size(94, 20);
            this.txtFinal.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(379, 348);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Sub Total $";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.Enabled = false;
            this.txtTotal.ForeColor = System.Drawing.Color.White;
            this.txtTotal.Location = new System.Drawing.Point(488, 351);
            this.txtTotal.MaxLength = 10;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(94, 20);
            this.txtTotal.TabIndex = 27;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(274, 424);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 23);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(153, 424);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(115, 23);
            this.btnAceptar.TabIndex = 23;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(320, 164);
            this.txtCantidad.MaxLength = 10;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(141, 20);
            this.txtCantidad.TabIndex = 21;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(467, 162);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(115, 23);
            this.btnAgregar.TabIndex = 22;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // cboProductos
            // 
            this.cboProductos.FormattingEnabled = true;
            this.cboProductos.Location = new System.Drawing.Point(18, 163);
            this.cboProductos.Name = "cboProductos";
            this.cboProductos.Size = new System.Drawing.Size(296, 21);
            this.cboProductos.TabIndex = 20;
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.AllowUserToResizeColumns = false;
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProdCol,
            this.colProd,
            this.precioCol,
            this.colCantidad,
            this.actionCol});
            this.dgvDetalles.Location = new System.Drawing.Point(18, 191);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.Size = new System.Drawing.Size(564, 154);
            this.dgvDetalles.TabIndex = 26;
            this.dgvDetalles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalles_CellContentClick);
            // 
            // idProdCol
            // 
            this.idProdCol.HeaderText = "ID";
            this.idProdCol.Name = "idProdCol";
            this.idProdCol.ReadOnly = true;
            this.idProdCol.Visible = false;
            // 
            // colProd
            // 
            this.colProd.HeaderText = "Producto";
            this.colProd.Name = "colProd";
            this.colProd.ReadOnly = true;
            this.colProd.Width = 220;
            // 
            // precioCol
            // 
            this.precioCol.HeaderText = "Precio";
            this.precioCol.Name = "precioCol";
            this.precioCol.ReadOnly = true;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            // 
            // actionCol
            // 
            this.actionCol.HeaderText = "Acciones";
            this.actionCol.Name = "actionCol";
            this.actionCol.ReadOnly = true;
            this.actionCol.Text = "Quitar";
            this.actionCol.UseColumnTextForButtonValue = true;
            // 
            // txtDto
            // 
            this.txtDto.Location = new System.Drawing.Point(154, 123);
            this.txtDto.MaxLength = 2;
            this.txtDto.Name = "txtDto";
            this.txtDto.Size = new System.Drawing.Size(160, 20);
            this.txtDto.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "% Descuento:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(154, 84);
            this.txtCliente.MaxLength = 100;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(428, 20);
            this.txtCliente.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Cliente:";
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(154, 48);
            this.txtFecha.MaxLength = 10;
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(160, 20);
            this.txtFecha.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Fecha:";
            // 
            // lblNroPresupuesto
            // 
            this.lblNroPresupuesto.AutoSize = true;
            this.lblNroPresupuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroPresupuesto.Location = new System.Drawing.Point(14, 7);
            this.lblNroPresupuesto.Name = "lblNroPresupuesto";
            this.lblNroPresupuesto.Size = new System.Drawing.Size(139, 20);
            this.lblNroPresupuesto.TabIndex = 14;
            this.lblNroPresupuesto.Text = "Presupuesto Nº:";
            // 
            // FrmModificarPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 457);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFinal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cboProductos);
            this.Controls.Add(this.dgvDetalles);
            this.Controls.Add(this.txtDto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNroPresupuesto);
            this.MaximumSize = new System.Drawing.Size(617, 496);
            this.MinimumSize = new System.Drawing.Size(617, 496);
            this.Name = "FrmModificarPresupuesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificar Presupuesto";
            this.Load += new System.EventHandler(this.FrmModificarPresupuesto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ComboBox cboProductos;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewButtonColumn actionCol;
        private System.Windows.Forms.TextBox txtDto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNroPresupuesto;
    }
}