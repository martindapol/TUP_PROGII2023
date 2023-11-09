
namespace Produccion.Presentacion
{
    partial class FrmAlta
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
            txtDT = new TextBox();
            label3 = new Label();
            cboComponente = new ComboBox();
            btnAgregar = new Button();
            dgvDetalles = new DataGridView();
            colComponente = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colSubTotal = new DataGridViewTextBoxColumn();
            acciones = new DataGridViewButtonColumn();
            btnAceptar = new Button();
            btnCancelar = new Button();
            nudCantidad = new NumericUpDown();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            dtpFecha = new DateTimePicker();
            numericUpDown1 = new NumericUpDown();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // txtDT
            // 
            txtDT.Location = new Point(80, 45);
            txtDT.Margin = new Padding(4, 3, 4, 3);
            txtDT.Name = "txtDT";
            txtDT.Size = new Size(530, 23);
            txtDT.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 48);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 3;
            label3.Text = "Modelo:";
            // 
            // cboComponente
            // 
            cboComponente.FormattingEnabled = true;
            cboComponente.Location = new Point(20, 138);
            cboComponente.Margin = new Padding(4, 3, 4, 3);
            cboComponente.Name = "cboComponente";
            cboComponente.Size = new Size(201, 23);
            cboComponente.TabIndex = 2;
            cboComponente.SelectedIndexChanged += cboComponente_SelectedIndexChanged;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(388, 135);
            btnAgregar.Margin = new Padding(4, 3, 4, 3);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(114, 27);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Columns.AddRange(new DataGridViewColumn[] { colComponente, colCantidad, colSubTotal, acciones });
            dgvDetalles.Location = new Point(20, 170);
            dgvDetalles.Margin = new Padding(4, 3, 4, 3);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.RowHeadersWidth = 51;
            dgvDetalles.Size = new Size(592, 172);
            dgvDetalles.TabIndex = 10;
            // 
            // colComponente
            // 
            colComponente.HeaderText = "Componente";
            colComponente.MinimumWidth = 6;
            colComponente.Name = "colComponente";
            colComponente.ReadOnly = true;
            colComponente.Width = 125;
            // 
            // colCantidad
            // 
            colCantidad.HeaderText = "Cantidad";
            colCantidad.Name = "colCantidad";
            colCantidad.ReadOnly = true;
            colCantidad.Width = 140;
            // 
            // colSubTotal
            // 
            colSubTotal.HeaderText = "Sub Total";
            colSubTotal.Name = "colSubTotal";
            colSubTotal.ReadOnly = true;
            // 
            // acciones
            // 
            acciones.HeaderText = "Acciones";
            acciones.MinimumWidth = 6;
            acciones.Name = "acciones";
            acciones.ReadOnly = true;
            acciones.Text = "Quitar";
            acciones.UseColumnTextForButtonValue = true;
            acciones.Width = 125;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(222, 363);
            btnAceptar.Margin = new Padding(4, 3, 4, 3);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(88, 27);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(314, 363);
            btnCancelar.Margin = new Padding(4, 3, 4, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(88, 27);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += BtnCancelar_Click;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(80, 76);
            nudCantidad.Margin = new Padding(2);
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(127, 23);
            nudCantidad.TabIndex = 5;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 14);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 19;
            label2.Text = "Fecha:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 120);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 21;
            label1.Text = "Componente:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 78);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 22;
            label4.Text = "Cantidad:";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(80, 14);
            dtpFecha.Margin = new Padding(4, 3, 4, 3);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(126, 23);
            dtpFecha.TabIndex = 25;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(227, 138);
            numericUpDown1.Margin = new Padding(2);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(155, 23);
            numericUpDown1.TabIndex = 26;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(225, 119);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 27;
            label5.Text = "Cantidad:";
            // 
            // FrmAlta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(625, 398);
            Controls.Add(label5);
            Controls.Add(numericUpDown1);
            Controls.Add(dtpFecha);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(nudCantidad);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(dgvDetalles);
            Controls.Add(btnAgregar);
            Controls.Add(cboComponente);
            Controls.Add(txtDT);
            Controls.Add(label3);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MaximumSize = new Size(641, 437);
            MinimumSize = new Size(641, 437);
            Name = "FrmAlta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Órdenes de Producción|Llaves GNC";
            Load += FrmAlta_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox txtDT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboComponente;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubTotal;
        private System.Windows.Forms.DataGridViewButtonColumn acciones;
    }
}