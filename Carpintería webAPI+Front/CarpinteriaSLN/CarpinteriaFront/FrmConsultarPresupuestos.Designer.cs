namespace CarpinteriaFront
{
    partial class FrmConsultarPresupuestos
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
            groupBox1 = new GroupBox();
            txtCliente = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dtpHasta = new DateTimePicker();
            dtpDesde = new DateTimePicker();
            btnConsultar = new Button();
            dgvPresupuestos = new DataGridView();
            colNro = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colCliente = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colDetalles = new DataGridViewButtonColumn();
            btnSalir = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPresupuestos).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCliente);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dtpHasta);
            groupBox1.Controls.Add(dtpDesde);
            groupBox1.Controls.Add(btnConsultar);
            groupBox1.Location = new Point(14, 15);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(709, 132);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(103, 88);
            txtCliente.Margin = new Padding(4, 3, 4, 3);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(408, 23);
            txtCliente.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 89);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 5;
            label3.Text = "Cliente:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(265, 44);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 4;
            label2.Text = "Hasta:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 44);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 3;
            label1.Text = "Fecha Desde:";
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(316, 44);
            dtpHasta.Margin = new Padding(4, 3, 4, 3);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(194, 23);
            dtpHasta.TabIndex = 2;
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(102, 44);
            dtpDesde.Margin = new Padding(4, 3, 4, 3);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(156, 23);
            dtpDesde.TabIndex = 1;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(583, 83);
            btnConsultar.Margin = new Padding(4, 3, 4, 3);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(119, 27);
            btnConsultar.TabIndex = 0;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // dgvPresupuestos
            // 
            dgvPresupuestos.AllowUserToAddRows = false;
            dgvPresupuestos.AllowUserToDeleteRows = false;
            dgvPresupuestos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPresupuestos.Columns.AddRange(new DataGridViewColumn[] { colNro, colFecha, colCliente, colTotal, colDetalles });
            dgvPresupuestos.Location = new Point(14, 153);
            dgvPresupuestos.Margin = new Padding(4, 3, 4, 3);
            dgvPresupuestos.Name = "dgvPresupuestos";
            dgvPresupuestos.ReadOnly = true;
            dgvPresupuestos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPresupuestos.Size = new Size(709, 265);
            dgvPresupuestos.TabIndex = 1;
            dgvPresupuestos.CellContentClick += dgvPresupuestos_CellContentClick;
            dgvPresupuestos.Click += dgvPresupuestos_Click;
            // 
            // colNro
            // 
            colNro.HeaderText = "Presupesto #";
            colNro.Name = "colNro";
            colNro.ReadOnly = true;
            // 
            // colFecha
            // 
            colFecha.HeaderText = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            // 
            // colCliente
            // 
            colCliente.HeaderText = "Cliente";
            colCliente.Name = "colCliente";
            colCliente.ReadOnly = true;
            // 
            // colTotal
            // 
            colTotal.HeaderText = "Total";
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            colTotal.Visible = false;
            // 
            // colDetalles
            // 
            colDetalles.HeaderText = "Acciones";
            colDetalles.Name = "colDetalles";
            colDetalles.ReadOnly = true;
            colDetalles.Text = "Ver Detalles";
            colDetalles.UseColumnTextForButtonValue = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(604, 437);
            btnSalir.Margin = new Padding(4, 3, 4, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(119, 27);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // FrmConsultarPresupuestos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(737, 478);
            Controls.Add(btnSalir);
            Controls.Add(dgvPresupuestos);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmConsultarPresupuestos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Consultar Presupuestos";
            Load += Frm_Consultar_Presupuestos_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPresupuestos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dgvPresupuestos;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewButtonColumn colDetalles;
    }
}