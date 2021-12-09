using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.Data.Sqlite;


namespace WinFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4(int pId1)
        {
            InitializeComponent();
            string con = (@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20");

            var connection = new SqlConnection(con);
            connection.Open();

            DataSet TableDocDataSet = new DataSet();
            SqlDataAdapter da;

            var sql1 = (@"Select DataDoc, NomerDoc, B.Naimenovanie from TableDoc left join Kontragent as B ON B.Id = Kontragent");

            da = new SqlDataAdapter(sql1, con);
            SqlCommand cc = new SqlCommand(sql1, connection);
            SqlDataReader r = cc.ExecuteReader();
            int iu = 0;
            while (r.Read())
            {
                iu++;
                if (pId1 == iu)
                {
                    break;
                }
            }
            this.textBox1.Text = (string)r.GetValue(0).ToString();
            this.textBox2.Text = (string)r.GetValue(1);
            this.comboBox1.Text = (string)r.GetValue(2);

            string con2 = (@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20");
            string sql2 = (@"SELECT Nomenklatura, B.Naimenovanie, Kolichestvo, Cena, Summa, UID FROM TableTableChast left join EdIzm as B ON B.Id=EdIzm where UID=" + pId1);

            var adapt = new SqlDataAdapter(sql2, con2);
            // Создаем объект Dataset
            var ds = new DataSet();
            adapt.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string con = (@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20");

            var connection = new SqlConnection(con);
            connection.Open();
            SqlCommandBuilder cmdBuilder2, cmdBuilder;
            SqlDataAdapter da;
            var sql1 = (@"Select DataDoc, NomerDoc, B.Naimenovanie from TableDoc left join Kontragent as B ON B.Id=Kontragent");
            DataSet TableDocDataSet = new DataSet();

            da = new SqlDataAdapter(sql1, con);
            //Initialize the SqlCommand object that will be used as the DataAdapter's UpdateCommand
            ////Notice that the WHERE clause uses only the CustId field to locate the record to be updated
            SqlCommand DAUpdate = new SqlCommand(@"UPDATE TableDoc SET DataDoc=@pDataDoc, NomerDoc = @pNomerDoc where id=3");

            DAUpdate.Parameters.Add(new SqlParameter("@pDataDoc", SqlDbType.DateTime));
            DAUpdate.Parameters["@pDataDoc"].SourceVersion = DataRowVersion.Current;
            DAUpdate.Parameters["@pDataDoc"].SourceColumn = "DataDoc";

            DAUpdate.Parameters.Add(new SqlParameter("@pNomerDoc", SqlDbType.NVarChar));
            DAUpdate.Parameters["@pNomerDoc"].SourceVersion = DataRowVersion.Current;
            DAUpdate.Parameters["@pNomerDoc"].SourceColumn = "NomerDoc";

            cmdBuilder = new SqlCommandBuilder(da);
            da.Fill(TableDocDataSet, "TableDoc");

            var pDataDoc = this.textBox1.Text;
            string pNomerDoc = (string)this.textBox2.Text;

            da.UpdateCommand = DAUpdate;

            TableDocDataSet.Tables["TableDoc"].Rows[0]["DataDoc"] = pDataDoc;
            TableDocDataSet.Tables["TableDoc"].Rows[0]["NomerDoc"] = pNomerDoc;

            da.Update(TableDocDataSet, "TableDoc");
            this.textBox1.Text = TableDocDataSet.Tables["TableDoc"].Rows[0]["DataDoc"].ToString();
            this.textBox2.Text = TableDocDataSet.Tables["TableDoc"].Rows[0]["NomerDoc"].ToString();


            ///for tablePart
            SqlConnection cn = new SqlConnection();
            DataSet NomenDataSet = new DataSet();
            SqlDataAdapter da2;
            SqlCommand DAUpdateCmd;

            da2 = new SqlDataAdapter(@"SELECT Nomenklatura, EdIzm.Naimenovanie, Kolichestvo, Cena, Summa, UID FROM TableTableChast left join EdIzm ON EdIzm.Id=EdIzm where UID=3", cn);
            cn.ConnectionString = (@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20");
            cn.Open();

            DAUpdateCmd = new SqlCommand("Update TableTableChast set Nomenklatura =@pNomen, Kolichestvo=@pKol, Cena=@pCena, Summa =@pSumma where Id=3", da.SelectCommand.Connection);

            DAUpdateCmd.Parameters.Add(new SqlParameter("@pNomen", SqlDbType.NVarChar));
            DAUpdateCmd.Parameters["@pNomen"].SourceVersion = DataRowVersion.Current;
            DAUpdateCmd.Parameters["@pNomen"].SourceColumn = "Nomenklatura";

            DAUpdateCmd.Parameters.Add(new SqlParameter("@pKol", SqlDbType.Int));
            DAUpdateCmd.Parameters["@pKol"].SourceVersion = DataRowVersion.Current;
            DAUpdateCmd.Parameters["@pKol"].SourceColumn = "Kolichestvo";

            DAUpdateCmd.Parameters.Add(new SqlParameter("@pCena", SqlDbType.Decimal));
            DAUpdateCmd.Parameters["@pCena"].SourceVersion = DataRowVersion.Current;
            DAUpdateCmd.Parameters["@pCena"].SourceColumn = "Cena";

            DAUpdateCmd.Parameters.Add(new SqlParameter("@pSumma", SqlDbType.Decimal));
            DAUpdateCmd.Parameters["@pSumma"].SourceVersion = DataRowVersion.Current;
            DAUpdateCmd.Parameters["@pSumma"].SourceColumn = "Summa";


            cmdBuilder2 = new SqlCommandBuilder(da2);
            da2.Fill(NomenDataSet, "TableTableChast");

            string pNomen = (string)dataGridView1.Rows[0].Cells[0].Value;
            int pKol = (int)dataGridView1.Rows[0].Cells[2].Value;
            decimal pCena = (decimal)dataGridView1.Rows[0].Cells[3].Value;
            decimal pSumma = (decimal)dataGridView1.Rows[0].Cells[4].Value;

            da2.UpdateCommand = DAUpdateCmd;

            NomenDataSet.Tables["TableTableChast"].Rows[0]["Nomenklatura"] = pNomen;
            NomenDataSet.Tables["TableTableChast"].Rows[0]["Kolichestvo"] = pKol;
            NomenDataSet.Tables["TableTableChast"].Rows[0]["Cena"] = pCena;
            NomenDataSet.Tables["TableTableChast"].Rows[0]["Summa"] = pSumma;

            //Assign the SqlCommand to the UpdateCommand property of the SqlDataAdapter

            da2.Update(NomenDataSet, "TableTableChast");
            dataGridView1.DataSource = NomenDataSet;

            Form4.ActiveForm.Close();
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Summa"].Value = (decimal)this.dataGridView1.Rows[e.RowIndex].Cells["Cena"].Value * (int)this.dataGridView1.Rows[e.RowIndex].Cells["Kolichestvo"].Value;
        }
    }
}
