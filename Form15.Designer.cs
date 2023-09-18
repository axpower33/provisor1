
namespace WindowsFormsApp8
{
    partial class Form15
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.FRSPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fractalsDataSet = new WindowsFormsApp8.fractalsDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.FRSPTableAdapter = new WindowsFormsApp8.fractalsDataSetTableAdapters.FRSPTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.FRSPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fractalsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // FRSPBindingSource
            // 
            this.FRSPBindingSource.DataMember = "FRSP";
            this.FRSPBindingSource.DataSource = this.fractalsDataSet;
            // 
            // fractalsDataSet
            // 
            this.fractalsDataSet.DataSetName = "fractalsDataSet";
            this.fractalsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet9";
            reportDataSource1.Value = this.FRSPBindingSource;
            reportDataSource2.Name = "DataSet10";
            reportDataSource2.Value = this.FRSPBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApp8.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(787, 412);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ReportRefresh += new System.ComponentModel.CancelEventHandler(this.reportViewer1_ReportRefresh_1);
            // 
            // FRSPTableAdapter
            // 
            this.FRSPTableAdapter.ClearBeforeFill = true;
            // 
            // Form15
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form15";
            this.Text = "Координаты";
            this.Load += new System.EventHandler(this.Form15_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FRSPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fractalsDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource FRSPBindingSource;
        private fractalsDataSet fractalsDataSet;
        private fractalsDataSetTableAdapters.FRSPTableAdapter FRSPTableAdapter;
    }
}