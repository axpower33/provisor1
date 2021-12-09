using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Data.SqlClient;


namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
      
        public Form3()
        {
            InitializeComponent();

            string connectionString =(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20");
            string sql = "SELECT A.Id, A.Naimenovanie FROM Kontragent as A";
            var connection = new SqlConnection(connectionString);
            
            var adapt = new SqlDataAdapter(sql, connectionString);
            // Создаем объект Dataset
            var ds = new DataSet();
            // Заполняем Dataset
            adapt.Fill(ds);
            // Отображаем данные
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.DataSource = ds.Tables[0];
         
            //this.dataGridView1.Rows.Clear();
            //int i = 0;
            //while (r.Read())
            //{
            //    i++;
            //    this.dataGridView1.Rows.Add();
            //    for (int j = 0; j <= 1; j++)
            //    {
            //        this.dataGridView1.Rows[i - 1].Cells[j].Value = r.GetValue(j);
            //    }
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            DataSet KontDataSet = new DataSet();
            SqlDataAdapter da;
            SqlCommandBuilder cmdBuilder;
         
            cn.ConnectionString = (@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20");
            cn.Open();
            da = new SqlDataAdapter(@"select Id, Naimenovanie from Kontragent", cn);

            cmdBuilder = new SqlCommandBuilder(da); 
            da.Fill(KontDataSet, "Kontragent");
    
            //Modify the value of the CustName field
            int i=0;
            while (i < 4)
            {
                i++;
                KontDataSet.Tables["Kontragent"].Rows[i - 1]["Naimenovanie"] = (string) dataGridView1.Rows[i-1].Cells[1].Value;
                KontDataSet.Tables["Kontragent"].Rows[i - 1]["Id"] = (int) dataGridView1.Rows[i - 1].Cells[0].Value;
            }

            ////Modify the value of the CustName field again
            da.Update(KontDataSet, "Kontragent");
            dataGridView1.DataSource = KontDataSet;

            cn.Close();
            
            Form3.ActiveForm.Close();
        }
    }
}
