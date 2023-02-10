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

    public partial class Form8: Form
    {
        public Form8()
        {
            InitializeComponent();

            string con2 = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20";
            string sql2 = @"SELECT Uid, DataDoc, NomerDoc, Kontragent.Naimenovanie as Kontragent FROM TableDoc2 left join Kontragent ON Kontragent.id=Kontragent";
            SqlConnection connection = new SqlConnection(con2);
            SqlCommand daCmd = new SqlCommand();
            daCmd.CommandText = sql2;
            daCmd.Connection = connection;
            connection.Open();
            SqlDataReader rr=daCmd.ExecuteReader();
            // Создаем объект Dataset
            dataGridView1.Rows.Clear();
            int i = 0;
            while (rr.Read())
            {
                i++;
                dataGridView1.Rows.Add();
                for (int j = 0; j <= 3; j++)
                {
                    dataGridView1.Rows[i - 1].Cells[j].Value = rr.GetValue(j);
                }
            }
            rr.Close();
            
            DataSet KontDataSet = new DataSet();
            var sql3 = @"select Id, Kontragent.naimenovanie as Kontragent from Kontragent";
            SqlCommand c3 = new SqlCommand(sql3, connection);
            SqlDataReader r3 = c3.ExecuteReader();
            while (r3.Read())
            {
                Kontragent.Items.Add(r3.GetValue(1));
            }
            r3.Close();

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
            int pId = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            Form xForm = new Form9(pId);
            xForm.Show();
            } catch { MessageBox.Show("Сохраните изменения!");}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form8.ActiveForm.Close();
            Form2.ActiveForm.Activate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20";
            var connection = new SqlConnection(con);
            connection.Open();
            Kontragent.Items.Clear();
            DataSet KontDataSet = new DataSet();
            var sql3 = @"select Id, Kontragent.naimenovanie as Kontragent from Kontragent";
            SqlCommand c3 = new SqlCommand(sql3, connection);
            SqlDataReader r3 = c3.ExecuteReader();
            int[] idKont = new int[100];
            int ii = 0;
            while (r3.Read())
            {
                ii++;
                Kontragent.Items.Add(r3.GetValue(1));
                idKont[ii] = (int)r3.GetValue(0);
            }
            r3.Close();


            int nn = 0;
            string pDataDoc, pNomerDoc;
            bool pZ = false;
            string sqli = "";
            int pId = 0;
            do
            {
                if (nn <= dataGridView1.Rows.Count - 2)
                {
                    if (dataGridView1.Rows[nn].Cells[0].Value == null)
                    {
                        pDataDoc = (string)dataGridView1.Rows[nn].Cells[1].Value;
                        if (pDataDoc == null)
                        {
                            MessageBox.Show("DataDoc не может быть пустым!");
                            return;
                        }

                        pNomerDoc = (string)dataGridView1.Rows[nn].Cells[2].Value;
                        if (pNomerDoc == null)
                        {
                            MessageBox.Show("NomerDoc не может быть пустым!");
                            return;
                        }

                        int tt = -1;
                        int pKont = 0;
                        while (tt <= Kontragent.Items.Count - 1)
                        {
                            if (dataGridView1.Rows[nn].Cells[3].Value==null)
                            {
                                MessageBox.Show("Kontragent не может быть пустым!");
                                return;
                            }
                            tt++;
                            if (dataGridView1.Rows[nn].Cells[3].Value.ToString().Trim() == Kontragent.Items[tt].ToString().Trim())
                            {
                                pKont = idKont[tt + 1];
                                break;
                            }
                        }
                        
                        if (!pZ)
                        {
                            sqli = "Select Max(Id) as mId from TableDoc2";
                            SqlCommand c9 = new SqlCommand(sqli, connection);
                            SqlDataReader r9 = c9.ExecuteReader();
                            try
                            {
                                r9.Read();
                                pId = (int)r9.GetValue(0);
                                pId = Convert.ToInt32(pId) + 1;
                            }
                            catch
                            {
                                pId = 1;
                            }
                            pZ = true;
                            r9.Close();
                        }
                        else
                        {
                            pId = Convert.ToInt32(pId) + 1;
                        }


                        string query = "INSERT INTO TableDoc2 (Id, DataDoc, NomerDoc, Kontragent, UID) VALUES(@pId, @pDataDoc, @pNomerDoc, @pKont, @pId)";

                        SqlCommand DAUpdateCmd = new SqlCommand(query, connection);

                        DAUpdateCmd.Parameters.AddWithValue("@pId", pId);
                        DAUpdateCmd.Parameters.AddWithValue("@pDataDoc", pDataDoc);
                        DAUpdateCmd.Parameters.AddWithValue("@pNomerDoc", pNomerDoc);
                        DAUpdateCmd.Parameters.AddWithValue("@pKont", pKont);

                        DAUpdateCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        int pId1 = (int)dataGridView1.Rows[nn].Cells[0].Value;
                        SqlCommandBuilder cmdBuilder;
                        SqlDataAdapter da;
                        var sql1 = @"Select DataDoc, NomerDoc, Kontragent as Kontragent from TableDoc2";
                        DataSet TableDoc2DataSet = new DataSet();

                        da = new SqlDataAdapter(sql1, con);
                        //Initialize the SqlCommand object that will be used as the DataAdapter's UpdateCommand
                        ////Notice that the WHERE clause uses only the CustId field to locate the record to be updated
                        SqlCommand DAUpdate = new SqlCommand(@"UPDATE TableDoc2 SET DataDoc=@pDataDoc, NomerDoc = @pNomerDoc, Kontragent =@pKont where id=" + pId1);

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
                        da.Fill(TableDoc2DataSet, "TableDoc2");

                        pDataDoc = dataGridView1.Rows[nn].Cells[1].Value.ToString();
                        pNomerDoc = dataGridView1.Rows[nn].Cells[2].Value.ToString();
                        int tt = -1;
                        int pKont = 1;
                        while (tt <= Kontragent.Items.Count - 1)
                        {
                            tt++;
                            if (dataGridView1.Rows[nn].Cells[3].Value.ToString().Trim() == Kontragent.Items[tt].ToString().Trim())
                            {
                                pKont = idKont[tt + 1];
                                break;
                            }
                        }

                        da.UpdateCommand = DAUpdate;

                        TableDoc2DataSet.Tables["TableDoc2"].Rows[0]["DataDoc"] = pDataDoc;
                        TableDoc2DataSet.Tables["TableDoc2"].Rows[0]["NomerDoc"] = pNomerDoc;
                        TableDoc2DataSet.Tables["TableDoc2"].Rows[0]["Kontragent"] = pKont;
                        da.Update(TableDoc2DataSet, "TableDoc2");
                    }
                }
                if (nn >= dataGridView1.Rows.Count - 2)
                {
                    break;
                }
                nn++;
            } while (1 == 1);
  
            string sql2 = @"SELECT TableDoc2.id, DataDoc, NomerDoc, Kontragent.Naimenovanie as Kontragent FROM TableDoc2 left join Kontragent ON Kontragent.id=Kontragent";
            SqlCommand daCmd = new SqlCommand();
            daCmd.CommandText = sql2;
            daCmd.Connection = connection;
            SqlDataReader rr = daCmd.ExecuteReader();
    
            dataGridView1.Rows.Clear();
            int i = 0;
            while (rr.Read())
            {
                i++;
                dataGridView1.Rows.Add();
                for (int j = 0; j <= 3; j++)
                {
                    dataGridView1.Rows[i - 1].Cells[j].Value = rr.GetValue(j);
                }
            }
            rr.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("  Удалить строки?", "Удаление", MessageBoxButtons.OKCancel);

            if (dr == DialogResult.Cancel)
            {
                return;
            }

            string con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20";

            var connection = new SqlConnection(con);
            connection.Open();

            bool pDel = false;
            foreach (DataGridViewRow ppRow in dataGridView1.SelectedRows)
            {
                pDel = true;
                try
                {
                    string pId = ppRow.Cells[0].Value.ToString().Trim();
                    string sql2 = "Delete from TableTableChast2 where Id=" + pId;
                    string sql1 = "Delete from TableDoc2 where Id=" + pId;
                    SqlCommand SqlC2 = new SqlCommand();
                    SqlC2.Connection = connection;
                    SqlC2.CommandText = sql2;
                    SqlC2.ExecuteNonQuery();
                    SqlCommand SqlC = new SqlCommand();
                    SqlC.Connection = connection;
                    SqlC.CommandText = sql1;
                    SqlC.ExecuteNonQuery();
                    dataGridView1.Rows.Remove(ppRow);
                }
                catch
                {
                    try
                    {
                        dataGridView1.Rows.Remove(ppRow);
                    }
                    catch { ppRow.Selected = false; }
                }
            }
            if (!pDel) MessageBox.Show("0 строк выбрано!");
        }
    }
}
