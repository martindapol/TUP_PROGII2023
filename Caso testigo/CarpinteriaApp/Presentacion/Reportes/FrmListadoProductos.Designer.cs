namespace CarpinteriaApp.Presentacion.Reportes
{
    partial class FrmListadoProductos
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dSReporte = new CarpinteriaApp.Presentacion.Reportes.DSReporte();
            this.tPRODUCTOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.t_PRODUCTOSTableAdapter = new CarpinteriaApp.Presentacion.Reportes.DSReporteTableAdapters.T_PRODUCTOSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dSReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPRODUCTOSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tPRODUCTOSBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CarpinteriaApp.Presentacion.Reportes.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(645, 311);
            this.reportViewer1.TabIndex = 0;
            // 
            // dSReporte
            // 
            this.dSReporte.DataSetName = "DSReporte";
            this.dSReporte.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tPRODUCTOSBindingSource
            // 
            this.tPRODUCTOSBindingSource.DataMember = "T_PRODUCTOS";
            this.tPRODUCTOSBindingSource.DataSource = this.dSReporte;
            // 
            // t_PRODUCTOSTableAdapter
            // 
            this.t_PRODUCTOSTableAdapter.ClearBeforeFill = true;
            // 
            // FrmListadoProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 311);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.Name = "FrmListadoProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado de productos";
            this.Load += new System.EventHandler(this.FrmListadoProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPRODUCTOSBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DSReporte dSReporte;
        private System.Windows.Forms.BindingSource tPRODUCTOSBindingSource;
        private DSReporteTableAdapters.T_PRODUCTOSTableAdapter t_PRODUCTOSTableAdapter;
    }
}