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

             
            DataSet KontDataSet = new DataSet();
            SqlDataAdapter da3;
            var sql3 = (@"select Id, Kontragent.naimenovanie as Kontragent from Kontragent");
            da3 = new SqlDataAdapter(sql3, con);
            SqlCommand c3 = new SqlCommand(sql3, connection);
            SqlDataReader r3 = c3.ExecuteReader();
            while (r3.Read())
            {
               this.comboBox1.Items.Add((object)r3.GetValue(1)); }
            r3.Close();
            var sql1 = (@"Select DataDoc, NomerDoc, Kontragent.Naimenovanie as Kontragent from TableDoc left join Kontragent ON Kontragent.Id = Kontragent");
            
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
            r.Close();

            SqlDataAdapter da4;
            var sql4 = (@"select Id, Naimenovanie as Nomenklatura from Nomenklatura");
            da4 = new SqlDataAdapter(sql4, con);
            SqlCommand c4 = new SqlCommand(sql4, connection);
            SqlDataReader r4 = c4.ExecuteReader();
            int ii = 0;
            int[] idNomen = new int[10];

            while (r4.Read())
            {
                ii++;
                this.Nomenklatura.Items.Add((object)r4.GetValue(1));
                idNomen[ii] = (int)r4.GetValue(0);

            }
            r4.Close();

            SqlDataAdapter da7;
            var sql7 = (@"select Id, Naimenovanie as EdIzm from EdIzm");
            da7 = new SqlDataAdapter(sql7, con);
            SqlCommand c7 = new SqlCommand(sql7, connection);
            SqlDataReader r7 = c7.ExecuteReader();
            ii = 0;
            int[] idEdIzm = new int[10];
            while (r7.Read())
            { ii++;
                this.EdIzm.Items.Add((object)r7.GetValue(1));
                idEdIzm[ii] =(int) r7.GetValue(0);
            }
            r7.Close();

            var sql2 = (@"SELECT Nomenklatura.Naimenovanie as Nomenklatura, EdIzm.Naimenovanie as EdIzm, Kolichestvo, Cena, Summa FROM TableTableChast left join EdIzm ON EdIzm.Id=EdIzm left join Nomenklatura ON Nomenklatura.Id = Nomenklatura where UID =" + pId1);
            SqlCommand c2 = new SqlCommand(sql2, connection);
            SqlDataReader rr = c2.ExecuteReader();

            //this.dataGridView1.DataSource = r;
            this.dataGridView1.Rows.Clear();
            int i = 0;
            while (rr.Read())
            {
                i++;
                this.dataGridView1.Rows.Add();
                for (int j = 0; j <= 4; j++)
                {
                    this.dataGridView1.Rows[i - 1].Cells[j].Value = rr.GetValue(j);
                }
            }
            rr.Close();
        }
                
        private void button1_Click(object sender, EventArgs e)
        {
            string con = (@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20");
            var connection = new SqlConnection(con);
            connection.Open();
            
            SqlDataAdapter da4;
            var sql4 = (@"select Id, Naimenovanie as Nomenklatura from Nomenklatura");
            da4 = new SqlDataAdapter(sql4, con);
            SqlCommand c4 = new SqlCommand(sql4, connection);
            SqlDataReader r4 = c4.ExecuteReader();
            int ii = 0;
            int[] idNomen = new int[10];
            while (r4.Read())
            {
                ii++;
                this.Nomenklatura.Items.Add((object)r4.GetValue(1));
                idNomen[ii] = (int)r4.GetValue(0);

            }
            r4.Close();

            SqlDataAdapter da7;
            var sql7 = (@"select Id, Naimenovanie as EdIzm from EdIzm");
            da7 = new SqlDataAdapter(sql7, con);
            SqlCommand c7 = new SqlCommand(sql7, connection);
            SqlDataReader r7 = c7.ExecuteReader();
            ii = 0;
            int[] idEdIzm = new int[10];
            while (r7.Read())
            {
                ii++;
                this.EdIzm.Items.Add((object)r7.GetValue(1));
                idEdIzm[ii] = (int)r7.GetValue(0);
            }
            r7.Close();


            SqlCommandBuilder cmdBuilder2, cmdBuilder;
            SqlDataAdapter da;
            var sql1 = (@"Select DataDoc, NomerDoc, Kontragent.Naimenovanie as Kontragent from TableDoc left join Kontragent ON Kontragent.Id=Kontragent");
            DataSet TableDocDataSet = new DataSet();

            da = new SqlDataAdapter(sql1, con);
            //Initialize the SqlCommand object that will be used as the DataAdapter's UpdateCommand
            ////Notice that the WHERE clause uses only the CustId field to locate the record to be updated
            SqlCommand DAUpdate = new SqlCommand(@"UPDATE TableDoc SET DataDoc=@pDataDoc, NomerDoc = @pNomerDoc, Kontragent =@pKont where id=3");

            DAUpdate.Parameters.Add(new SqlParameter("@pDataDoc", SqlDbType.DateTime));
            DAUpdate.Parameters["@pDataDoc"].SourceVersion = DataRowVersion.Current;
            DAUpdate.Parameters["@pDataDoc"].SourceColumn = "DataDoc";

            DAUpdate.Parameters.Add(new SqlParameter("@pNomerDoc", SqlDbType.NVarChar));
            DAUpdate.Parameters["@pNomerDoc"].SourceVersion = DataRowVersion.Current;
            DAUpdate.Parameters["@pNomerDoc"].SourceColumn = "NomerDoc";

            DAUpdate.Parameters.Add(new SqlParameter("@pKont", SqlDbType.Int));
            DAUpdate.Parameters["@pKont"].SourceVersion = DataRowVersion.Current;
            DAUpdate.Parameters["@pKont"].SourceColumn = "Kontragent";

            cmdBuilder = new SqlCommandBuilder(da);
            da.Fill(TableDocDataSet, "TableDoc");

            var pDataDoc = this.textBox1.Text;
            string pNomerDoc = (string)this.textBox2.Text;
            int pKont = (int)this.comboBox1.SelectedIndex+1;

            da.UpdateCommand = DAUpdate;

            TableDocDataSet.Tables["TableDoc"].Rows[0]["DataDoc"] = pDataDoc;
            TableDocDataSet.Tables["TableDoc"].Rows[0]["NomerDoc"] = pNomerDoc;
            TableDocDataSet.Tables["TableDoc"].Rows[0]["Kontragent"] = pKont;
            da.Update(TableDocDataSet, "TableDoc");
            this.textBox1.Text = TableDocDataSet.Tables["TableDoc"].Rows[0]["DataDoc"].ToString();
            this.textBox2.Text = TableDocDataSet.Tables["TableDoc"].Rows[0]["NomerDoc"].ToString();
            

            ///for tablePart
            SqlConnection cn = new SqlConnection();
            DataSet NomenDataSet = new DataSet();
            SqlDataAdapter da2;
            SqlCommand DAUpdateCmd;

            da2 = new SqlDataAdapter(@"SELECT Nomenklatura.Naimenovanie as Nomenklatura, Edizm.Naimenovanie as EdIzm, Kolichestvo, Cena, Summa, UID FROM TableTableChast left join EdIzm on EdIzm.Id=EdIzm left join Nomenklatura on Nomenklatura.Id=Nomenklatura where UID=3", cn);
            cn.ConnectionString = (@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20");
            cn.Open();

            DAUpdateCmd = new SqlCommand("Update TableTableChast set Nomenklatura=@pNomen, EdIzm=@pEdIzm, Kolichestvo=@pKol, Cena=@pCena, Summa =@pSumma where Id=3", da.SelectCommand.Connection);

            DAUpdateCmd.Parameters.Add(new SqlParameter("@pNomen", SqlDbType.Int));
            DAUpdateCmd.Parameters["@pNomen"].SourceVersion = DataRowVersion.Current;
            DAUpdateCmd.Parameters["@pNomen"].SourceColumn = "Nomenklatura";

            DAUpdateCmd.Parameters.Add(new SqlParameter("@pEdIzm", SqlDbType.Int));
            DAUpdateCmd.Parameters["@pEdIzm"].SourceVersion = DataRowVersion.Current;
            DAUpdateCmd.Parameters["@pEdIzm"].SourceColumn = "EdIzm";

            DAUpdateCmd.Parameters.Add(new SqlParameter("@pKol", SqlDbType.NVarChar));
            DAUpdateCmd.Parameters["@pKol"].SourceVersion = DataRowVersion.Current;
            DAUpdateCmd.Parameters["@pKol"].SourceColumn = "Kolichestvo";

            DAUpdateCmd.Parameters.Add(new SqlParameter("@pCena", SqlDbType.NVarChar));
            DAUpdateCmd.Parameters["@pCena"].SourceVersion = DataRowVersion.Current;
            DAUpdateCmd.Parameters["@pCena"].SourceColumn = "Cena";

            DAUpdateCmd.Parameters.Add(new SqlParameter("@pSumma", SqlDbType.NVarChar));
            DAUpdateCmd.Parameters["@pSumma"].SourceVersion = DataRowVersion.Current;
            DAUpdateCmd.Parameters["@pSumma"].SourceColumn = "Summa";


            cmdBuilder2 = new SqlCommandBuilder(da2);
            da2.Fill(NomenDataSet, "TableTableChast");

            
            int tt = 0;
            int pNomen = 1;
            while (tt <= 6)
            {
                tt++;
                if (dataGridView1.Rows[0].Cells[0].Value.ToString().Trim() == this.Nomenklatura.Items[tt].ToString().Trim())
                {
                    pNomen = (int)idNomen[tt]+1;
                    break;
                }
            }
            tt = 0;
            int pEdIzm = 1;
            while (tt <= 6)
            {
                tt++;
                if (dataGridView1.Rows[0].Cells[1].Value.ToString().Trim() == this.EdIzm.Items[tt].ToString().Trim())
                {
                    pEdIzm = (int)idEdIzm[tt]+1;
                    break;
                }
            }
            string pKol =(string) dataGridView1.Rows[0].Cells[2].Value;
            string pCena =(string)  dataGridView1.Rows[0].Cells[3].Value;
            string pSumma =(string) dataGridView1.Rows[0].Cells[4].Value;

            da2.UpdateCommand = DAUpdateCmd;

            //MessageBox.Show(NomenDataSet.Tables["TableTableChast"].Rows[0]["Nomenklatura"].ToString()+"/"+ this.Nomenklatura.Items[pNomen]);

            NomenDataSet.Tables["TableTableChast"].Rows[0]["Nomenklatura"] = (int)pNomen;
            NomenDataSet.Tables["TableTableChast"].Rows[0]["EdIzm"] =(int) pEdIzm;
            NomenDataSet.Tables["TableTableChast"].Rows[0]["Kolichestvo"] = (string) pKol;
            NomenDataSet.Tables["TableTableChast"].Rows[0]["Cena"] = (string)pCena;
            NomenDataSet.Tables["TableTableChast"].Rows[0]["Summa"] = (string) pSumma;

            //Assign the SqlCommand to the UpdateCommand property of the SqlDataAdapter

            da2.Update(NomenDataSet, "TableTableChast");
            dataGridView1.DataSource = NomenDataSet;

            Form4.ActiveForm.Close();
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
             //MessageBox.Show(this.dataGridView1.Rows[0].Cells[3].Value.ToString());
             //int nsum = (int)this.dataGridView1.Rows[0].Cells[3].Value * (int)this.dataGridView1.Rows[0].Cells[2].Value;
             //this.dataGridView1.Rows[0].Cells[4].Value=nsum.ToString();
            
        }
    }
}
