using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp8
{

    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();

            string con2 = (@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20");
            string sql2 = (@"SELECT Uid, DataDoc, NomerDoc, Kontragent.naimenovanie as kontragent FROM TableDoc left join Kontragent ON Kontragent.id=Kontragent");
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
            int pId = (int)this.dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            Form xForm = new Form7(pId);
            xForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form6.ActiveForm.Close();
            Form2.ActiveForm.Activate();
        }
    }
}
