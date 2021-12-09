using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsApp1
{
 
    public partial class Form5 : Form
    { 
        public Form5()
        {
            InitializeComponent();
            
            string con2 = (@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20");
            string sql2 = (@"SELECT Id, DataDoc, NomerDoc, Kontragent.naimenovanie FROM TableDoc left join kontragent on kontragent.id=kontragent");
            var adapt = new SqlDataAdapter(sql2, con2);
            // Создаем объект Dataset
            var ds = new DataSet();
            // Заполняем Dataset
            adapt.Fill(ds);
            // Отображаем данные
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int pId = (int) this.dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            Form4 xForm = new Form4(pId);
            xForm.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form5.ActiveForm.Close();
        }
        
    }
}
