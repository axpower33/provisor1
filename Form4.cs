using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp8
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "provisorBaseDataDataSet.Kontragent". При необходимости она может быть перемещена или удалена.
            kontragentTableAdapter.Fill(provisorBaseDataDataSet.Kontragent);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kontragentTableAdapter.Update(provisorBaseDataDataSet);
            Form4.ActiveForm.Close();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20";

            var connection = new SqlConnection(con);
            connection.Open();
            string pUid = dataGridView1.Rows[e.Row.Index].Cells[0].Value.ToString();
            string sql2 = "Select Kontragent from Nomenklatura where kontragent=" + pUid;
            SqlCommand SqlC2 = new SqlCommand();
            SqlC2.Connection = connection;
            SqlC2.CommandText = sql2;
            SqlDataReader rr = SqlC2.ExecuteReader();
            bool pDel = false;
            while (rr.Read())
            {
                pDel = true;
                break;
            }
            rr.Close();
            if (pDel)
            {
                MessageBox.Show("В справочнике Контрагент  есть значение " + dataGridView1.Rows[e.Row.Index].Cells[1].Value.ToString().Trim() + ". Удаление невозможно!");
                dataGridView1.Rows[e.Row.Index].Selected = false;
                e.Cancel = true;
                return;
            }

        }
    }
}
