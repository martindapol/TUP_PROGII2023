namespace CarpinteriaApp.formularios
{
    partial class Principal
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
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            presupuestoToolStripMenuItem = new ToolStripMenuItem();
            consultarPresupuestosToolStripMenuItem = new ToolStripMenuItem();
            nuevoPresupuestoToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            reporteDeProductosToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, presupuestoToolStripMenuItem, reportesToolStripMenuItem, acercaDeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(933, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "msPrincipal";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salirToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(96, 22);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // presupuestoToolStripMenuItem
            // 
            presupuestoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { consultarPresupuestosToolStripMenuItem, nuevoPresupuestoToolStripMenuItem });
            presupuestoToolStripMenuItem.Name = "presupuestoToolStripMenuItem";
            presupuestoToolStripMenuItem.Size = new Size(84, 20);
            presupuestoToolStripMenuItem.Text = "Presupuesto";
            // 
            // consultarPresupuestosToolStripMenuItem
            // 
            consultarPresupuestosToolStripMenuItem.Name = "consultarPresupuestosToolStripMenuItem";
            consultarPresupuestosToolStripMenuItem.Size = new Size(198, 22);
            consultarPresupuestosToolStripMenuItem.Text = "Consultar presupuestos";
            consultarPresupuestosToolStripMenuItem.Click += consultarPresupuestosToolStripMenuItem_Click;
            // 
            // nuevoPresupuestoToolStripMenuItem
            // 
            nuevoPresupuestoToolStripMenuItem.Name = "nuevoPresupuestoToolStripMenuItem";
            nuevoPresupuestoToolStripMenuItem.Size = new Size(198, 22);
            nuevoPresupuestoToolStripMenuItem.Text = "Nuevo Presupuesto";
            nuevoPresupuestoToolStripMenuItem.Click += nuevoPresupuestoToolStripMenuItem_Click;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reporteDeProductosToolStripMenuItem });
            reportesToolStripMenuItem.Enabled = false;
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(65, 20);
            reportesToolStripMenuItem.Text = "Reportes";
            // 
            // reporteDeProductosToolStripMenuItem
            // 
            reporteDeProductosToolStripMenuItem.Name = "reporteDeProductosToolStripMenuItem";
            reporteDeProductosToolStripMenuItem.Size = new Size(188, 22);
            reporteDeProductosToolStripMenuItem.Text = "Reporte de Productos";
            reporteDeProductosToolStripMenuItem.Click += reporteDeProductosToolStripMenuItem_Click;
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { acercaDeToolStripMenuItem1 });
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(53, 20);
            acercaDeToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem1
            // 
            acercaDeToolStripMenuItem1.Name = "acercaDeToolStripMenuItem1";
            acercaDeToolStripMenuItem1.Size = new Size(126, 22);
            acercaDeToolStripMenuItem1.Text = "Acerca de";
            acercaDeToolStripMenuItem1.Click += acercaDeToolStripMenuItem1_Click;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Principal";
            Text = "Principal";
            WindowState = FormWindowState.Maximized;
            Load += Principal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presupuestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem consultarPresupuestosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoPresupuestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeProductosToolStripMenuItem;
    }
}