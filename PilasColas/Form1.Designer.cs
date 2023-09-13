namespace PilasColas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNuevo = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnPrimero = new System.Windows.Forms.Button();
            this.btnVacia = new System.Windows.Forms.Button();
            this.btnExtraer = new System.Windows.Forms.Button();
            this.lstValores = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtNuevo
            // 
            this.txtNuevo.Location = new System.Drawing.Point(21, 21);
            this.txtNuevo.Name = "txtNuevo";
            this.txtNuevo.Size = new System.Drawing.Size(188, 20);
            this.txtNuevo.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(215, 18);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnPrimero
            // 
            this.btnPrimero.Location = new System.Drawing.Point(37, 232);
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(75, 23);
            this.btnPrimero.TabIndex = 3;
            this.btnPrimero.Text = "Primero";
            this.btnPrimero.UseVisualStyleBackColor = true;
            this.btnPrimero.Click += new System.EventHandler(this.btnPrimero_Click);
            // 
            // btnVacia
            // 
            this.btnVacia.Location = new System.Drawing.Point(118, 232);
            this.btnVacia.Name = "btnVacia";
            this.btnVacia.Size = new System.Drawing.Size(75, 23);
            this.btnVacia.TabIndex = 4;
            this.btnVacia.Text = "Vacía?";
            this.btnVacia.UseVisualStyleBackColor = true;
            this.btnVacia.Click += new System.EventHandler(this.btnVacia_Click);
            // 
            // btnExtraer
            // 
            this.btnExtraer.Location = new System.Drawing.Point(199, 232);
            this.btnExtraer.Name = "btnExtraer";
            this.btnExtraer.Size = new System.Drawing.Size(75, 23);
            this.btnExtraer.TabIndex = 5;
            this.btnExtraer.Text = "Extraer";
            this.btnExtraer.UseVisualStyleBackColor = true;
            this.btnExtraer.Click += new System.EventHandler(this.btnExtraer_Click);
            // 
            // lstValores
            // 
            this.lstValores.FormattingEnabled = true;
            this.lstValores.Location = new System.Drawing.Point(21, 47);
            this.lstValores.Name = "lstValores";
            this.lstValores.Size = new System.Drawing.Size(269, 173);
            this.lstValores.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 271);
            this.Controls.Add(this.lstValores);
            this.Controls.Add(this.btnExtraer);
            this.Controls.Add(this.btnVacia);
            this.Controls.Add(this.btnPrimero);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtNuevo);
            this.Name = "Form1";
            this.Text = "Pilas y Colas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNuevo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnPrimero;
        private System.Windows.Forms.Button btnVacia;
        private System.Windows.Forms.Button btnExtraer;
        private System.Windows.Forms.ListBox lstValores;
    }
}

