
namespace WindowsFormsApp8
{
    partial class Form13
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nomenklaturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.provisorBaseDataDataSet = new WindowsFormsApp8.ProvisorBaseDataDataSet();
            this.nomenklaturaTableAdapter = new WindowsFormsApp8.ProvisorBaseDataDataSetTableAdapters.NomenklaturaTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.naimenovanieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edIzmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kontragentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomenklaturaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provisorBaseDataDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.naimenovanieDataGridViewTextBoxColumn,
            this.edIzmDataGridViewTextBoxColumn,
            this.kontragentDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.nomenklaturaBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(466, 217);
            this.dataGridView1.TabIndex = 0;
            // 
            // nomenklaturaBindingSource
            // 
            this.nomenklaturaBindingSource.DataMember = "Nomenklatura";
            this.nomenklaturaBindingSource.DataSource = this.provisorBaseDataDataSet;
            // 
            // provisorBaseDataDataSet
            // 
            this.provisorBaseDataDataSet.DataSetName = "ProvisorBaseDataDataSet";
            this.provisorBaseDataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nomenklaturaTableAdapter
            // 
            this.nomenklaturaTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(384, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save changes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Ид";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // naimenovanieDataGridViewTextBoxColumn
            // 
            this.naimenovanieDataGridViewTextBoxColumn.DataPropertyName = "Naimenovanie";
            this.naimenovanieDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.naimenovanieDataGridViewTextBoxColumn.Name = "naimenovanieDataGridViewTextBoxColumn";
            // 
            // edIzmDataGridViewTextBoxColumn
            // 
            this.edIzmDataGridViewTextBoxColumn.DataPropertyName = "EdIzm";
            this.edIzmDataGridViewTextBoxColumn.HeaderText = "Ед. изм.";
            this.edIzmDataGridViewTextBoxColumn.Name = "edIzmDataGridViewTextBoxColumn";
            // 
            // kontragentDataGridViewTextBoxColumn
            // 
            this.kontragentDataGridViewTextBoxColumn.DataPropertyName = "Kontragent";
            this.kontragentDataGridViewTextBoxColumn.HeaderText = "Контрагент";
            this.kontragentDataGridViewTextBoxColumn.Name = "kontragentDataGridViewTextBoxColumn";
            // 
            // Form13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 269);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Location = new System.Drawing.Point(110, 90);
            this.Name = "Form13";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Справочник";
            this.Load += new System.EventHandler(this.Form13_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomenklaturaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provisorBaseDataDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private ProvisorBaseDataDataSet provisorBaseDataDataSet;
        private System.Windows.Forms.BindingSource nomenklaturaBindingSource;
        private ProvisorBaseDataDataSetTableAdapters.NomenklaturaTableAdapter nomenklaturaTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn naimenovanieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn edIzmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kontragentDataGridViewTextBoxColumn;
    }
}