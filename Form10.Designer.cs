﻿
namespace WindowsFormsApp8
{
    partial class Form10
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
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProvisorBaseDataDataSet2 = new WindowsFormsApp8.ProvisorBaseDataDataSet2();
            this.dataTable1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.provisorBaseDataDataSet3 = new WindowsFormsApp8.ProvisorBaseDataDataSet3();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataTable1TableAdapter = new WindowsFormsApp8.ProvisorBaseDataDataSet2TableAdapters.DataTable1TableAdapter();
            this.dataTable1TableAdapter1 = new WindowsFormsApp8.ProvisorBaseDataDataSet3TableAdapters.DataTable1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProvisorBaseDataDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provisorBaseDataDataSet3)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.ProvisorBaseDataDataSet2;
            // 
            // ProvisorBaseDataDataSet2
            // 
            this.ProvisorBaseDataDataSet2.DataSetName = "ProvisorBaseDataDataSet2";
            this.ProvisorBaseDataDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataTable1BindingSource1
            // 
            this.dataTable1BindingSource1.DataMember = "DataTable1";
            this.dataTable1BindingSource1.DataSource = this.provisorBaseDataDataSet3;
            // 
            // provisorBaseDataDataSet3
            // 
            this.provisorBaseDataDataSet3.DataSetName = "ProvisorBaseDataDataSet3";
            this.provisorBaseDataDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet3";
            reportDataSource1.Value = this.DataTable1BindingSource;
            reportDataSource2.Name = "DataSet4";
            reportDataSource2.Value = this.dataTable1BindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApp8.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(707, 605);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ReportRefresh += new System.ComponentModel.CancelEventHandler(this.reportViewer1_ReportRefresh);
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // dataTable1TableAdapter1
            // 
            this.dataTable1TableAdapter1.ClearBeforeFill = true;
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 570);
            this.Controls.Add(this.reportViewer1);
            this.Location = new System.Drawing.Point(110, 90);
            this.Name = "Form10";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Отчет";
            this.Load += new System.EventHandler(this.Form10_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProvisorBaseDataDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provisorBaseDataDataSet3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private ProvisorBaseDataDataSet2 ProvisorBaseDataDataSet2;
        private ProvisorBaseDataDataSet2TableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
        private ProvisorBaseDataDataSet3 provisorBaseDataDataSet3;
        private System.Windows.Forms.BindingSource dataTable1BindingSource1;
        private ProvisorBaseDataDataSet3TableAdapters.DataTable1TableAdapter dataTable1TableAdapter1;
    }
}