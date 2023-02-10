using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using Microsoft.Data.Sqlite;

namespace WindowsFormsApp8
{
    public partial class Form7 : Form
    {
        public Form7(int pId1)
        {
            InitializeComponent();
            string con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20";

            SqlConnection connection = new SqlConnection(con);
            connection.Open();

            string sql1 = @"Select DataDoc, NomerDoc, Kontragent.Naimenovanie, TableDoc.Id as Kontragent from TableDoc left join Kontragent ON Kontragent.Id = Kontragent where TableDoc.Id=" + pId1;
            DataSet TableDocDataSet = new DataSet();
            SqlCommand cc = new SqlCommand(sql1, connection);
            SqlDataReader r = cc.ExecuteReader();
            r.Read();

            textBox1.Text = r.GetValue(0).ToString();
            textBox2.Text = (string)r.GetValue(1);
            comboBox1.Text = (string)r.GetValue(2);
            tId.Text = r.GetValue(3).ToString();
            r.Close();

            DataSet KontDataSet = new DataSet();
            string sql3 = @"select Id, Kontragent.naimenovanie as Kontragent from Kontragent";
            SqlCommand c3 = new SqlCommand(sql3, connection);
            SqlDataReader r3 = c3.ExecuteReader();
            while (r3.Read())
            {
                comboBox1.Items.Add(r3.GetValue(1));
            }
            r3.Close();
            
            string sql4 = @"select Id, Naimenovanie as Nomenklatura from Nomenklatura";
            SqlCommand c4 = new SqlCommand(sql4, connection);
            SqlDataReader r4 = c4.ExecuteReader();
            int ii = 0;
            int[] idNomen = new int[100];
            Nomenklatura.Items.Clear();
            while (r4.Read())
            {
                ii++;
                Nomenklatura.Items.Add(r4.GetValue(1));
                idNomen[ii] = (int)r4.GetValue(0);

            }
            r4.Close();

            string sql7 = @"select Id, Naimenovanie as EdIzm from EdIzm";
            SqlCommand c7 = new SqlCommand(sql7, connection);
            SqlDataReader r7 = c7.ExecuteReader();
            ii = 0;
            int[] idEdIzm = new int[100];
            EdIzm.Items.Clear();
            while (r7.Read())
            {
                ii++;
                EdIzm.Items.Add(r7.GetValue(1));
                idEdIzm[ii] = (int)r7.GetValue(0);
            }
            r7.Close();

            string sql2 = @"SELECT TableTableChast.Id, Nomenklatura.Naimenovanie as Nomenklatura, EdIzm.Naimenovanie as EdIzm, Kolichestvo, Cena, Summa, UID  FROM TableTableChast left join EdIzm ON EdIzm.Id=EdIzm left join Nomenklatura ON Nomenklatura.Id = Nomenklatura where TableTableChast.Id=" + pId1+" ORDER BY UID";
            SqlCommand c2 = new SqlCommand(sql2, connection);
            SqlDataReader rr = c2.ExecuteReader();

            //this.dataGridView1.DataSource = r;
            dataGridView1.Rows.Clear();
            int i = 0;
            while (rr.Read())
            {
                i++;
                dataGridView1.Rows.Add();
                for (int j = 0; j <= 6; j++)
                {
                    dataGridView1.Rows[i - 1].Cells[j].Value = rr.GetValue(j);
                }
            }
            rr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string pId1 = (string)(this.dataGridView1.Rows[0].Cells[0].Value.ToString().Trim());
            string pId1 = tId.Text.Trim();
            string con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20";
            SqlConnection connection = new SqlConnection(con);
            connection.Open();

            DataSet KontDataSet = new DataSet();
            string sql3 = @"select Id, Kontragent.naimenovanie as Kontragent from Kontragent";
            SqlCommand c3 = new SqlCommand(sql3, connection);
            SqlDataReader r3 = c3.ExecuteReader();
            int[] idKont = new int[100];
            int ii = 0;
            while (r3.Read())
            {   ii++;
                comboBox1.Items.Add(r3.GetValue(1));
                idKont[ii] = (int)r3.GetValue(0);
            }
            r3.Close();

            string sql4 = @"select Id, Naimenovanie as Nomenklatura from Nomenklatura";
            SqlCommand c4 = new SqlCommand(sql4, connection);
            SqlDataReader r4 = c4.ExecuteReader();
            ii = 0;
            int[] idNomen = new int[100];
            Nomenklatura.Items.Clear();
            while (r4.Read())
            {
                ii++;
                Nomenklatura.Items.Add(r4.GetValue(1));
                idNomen[ii] = (int)r4.GetValue(0);

            }
            r4.Close();

            string sql7 = @"select Id, Naimenovanie as EdIzm from EdIzm";
            SqlCommand c7 = new SqlCommand(sql7, connection);
            SqlDataReader r7 = c7.ExecuteReader();
            ii = 0;
            int[] idEdIzm = new int[100];
            EdIzm.Items.Clear();
            while (r7.Read())
            {
                ii++;
                EdIzm.Items.Add(r7.GetValue(1));
                idEdIzm[ii] = (int)r7.GetValue(0);
            }
            r7.Close();

            SqlCommandBuilder cmdBuilder2, cmdBuilder;
            SqlDataAdapter da;
            string sql1 = @"Select DataDoc, NomerDoc, Kontragent as Kontragent from TableDoc";
            DataSet TableDocDataSet = new DataSet();

            da = new SqlDataAdapter(sql1, con);
            //Initialize the SqlCommand object that will be used as the DataAdapter's UpdateCommand
            ////Notice that the WHERE clause uses only the CustId field to locate the record to be updated
            SqlCommand DAUpdate = new SqlCommand(@"UPDATE TableDoc SET DataDoc=@pDataDoc, NomerDoc = @pNomerDoc, Kontragent =@pKont where id="+pId1);
            
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

            string pDataDoc = textBox1.Text;
            string pNomerDoc = textBox2.Text;
            int tt = -1;
            int pKont = 1;
            while (tt <= comboBox1.Items.Count - 1)
            {
                tt++;
                if (comboBox1.Text.Trim() == comboBox1.Items[tt].ToString().Trim())
                {
                    pKont = idKont[tt + 1];
                    break;
                }
            }

            da.UpdateCommand = DAUpdate;

            TableDocDataSet.Tables["TableDoc"].Rows[0]["DataDoc"] = pDataDoc;
            TableDocDataSet.Tables["TableDoc"].Rows[0]["NomerDoc"] = pNomerDoc;
            TableDocDataSet.Tables["TableDoc"].Rows[0]["Kontragent"] = pKont;
            da.Update(TableDocDataSet, "TableDoc");
            //this.textBox1.Text = TableDocDataSet.Tables["TableDoc"].Rows[0]["DataDoc"].ToString();
            //this.textBox2.Text = TableDocDataSet.Tables["TableDoc"].Rows[0]["NomerDoc"].ToString();
            //this.comboBox1.Text = (string)this.comboBox1.Items[pKont-1].ToString(); 
            
            //for tablePart
            SqlConnection cn= new SqlConnection(); 
            DataSet NomenDataSet = new DataSet();
            SqlDataAdapter da2;
            SqlCommand DAUpdateCmd;

            cn.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20";
            cn.Open();
            da2 = new SqlDataAdapter(@"SELECT TableTableChast.Id, Nomenklatura.Naimenovanie as Nomenklatura, Edizm.Naimenovanie as EdIzm, Kolichestvo, Cena, Summa, UID FROM TableTableChast left join EdIzm on EdIzm.Id=EdIzm left join Nomenklatura on Nomenklatura.Id=Nomenklatura where TableTableChast.Id=" + pId1+" ORDER BY UID", cn);
    
            int nn = 0;
            int pNomen;
            int pEdIzm;
            decimal pKol;
            decimal pCena;
            decimal pSumma;
            string pUid = "0";
            int pId = Convert.ToInt32(pId1.Trim());
            bool pZ = false;
            string sqli = "";
            do
            {
                if (nn <= dataGridView1.Rows.Count - 2)
                {
                    if (dataGridView1.Rows[nn].Cells[0].Value == null)
                    {

                        tt = -1;
                        pNomen = 1;
                        while (tt <= Nomenklatura.Items.Count - 1)
                        {
                            tt++;
                            if (dataGridView1.Rows[nn].Cells[1].Value == null)
                            {
                                MessageBox.Show("Nomenklatura не может быть пустым!");
                                return;
                            }
                            if (dataGridView1.Rows[nn].Cells[1].Value.ToString().Trim() == Nomenklatura.Items[tt].ToString().Trim())
                            {

                                pNomen = idNomen[tt + 1];
                                break;
                            }
                        }
                        tt = -1;
                        pEdIzm = 1;
                        while (tt <= EdIzm.Items.Count - 1)
                        {
                            tt++;
                            if (dataGridView1.Rows[nn].Cells[2].Value == null)
                            {
                                MessageBox.Show("EdIzm не может быть пустым!");
                                return;
                            }

                            if (dataGridView1.Rows[nn].Cells[2].Value.ToString().Trim() == EdIzm.Items[tt].ToString().Trim())
                            {
                                pEdIzm = idEdIzm[tt + 1];
                                break;
                            }
                        }
                        if (dataGridView1.Rows[nn].Cells[3].Value == null)
                        {
                            MessageBox.Show("Kolichestvo не может быть пустым!");
                            return;
                        }
                        try
                        {
                            pKol = Convert.ToDecimal(dataGridView1.Rows[nn].Cells[3].Value);
                        }
                        catch { MessageBox.Show("В " + (nn + 1).ToString() + " строке значение Количество имеет неверный формат!"); return; }

                        if (dataGridView1.Rows[nn].Cells[4].Value == null)
                        {
                            MessageBox.Show("Cena не может быть пустым!");
                            return;
                        }
                        try
                        {
                            pCena = Convert.ToDecimal(dataGridView1.Rows[nn].Cells[4].Value);
                        }
                        catch { MessageBox.Show("В " + (nn + 1).ToString() + " строке значение Цена имеет неверный формат!"); return; }

                        if (dataGridView1.Rows[nn].Cells[5].Value == null)
                        {
                            MessageBox.Show("Summa не может быть пустым!");
                            return;
                        }
                        try
                        {
                            pSumma = Convert.ToDecimal(dataGridView1.Rows[nn].Cells[5].Value);
                        }
                        catch { MessageBox.Show("В " + (nn + 1).ToString() + " строке значение Сумма имеет неверный формат!"); return; }
                        
                        if (!pZ)
                        {
                            sqli = "Select Max(UID) as mUid from TableTableChast where Id="+pId1;
                            SqlCommand c9 = new SqlCommand(sqli, connection);
                            SqlDataReader r9 = c9.ExecuteReader();
                            try
                            {
                                r9.Read();
                                pUid = r9.GetValue(0).ToString();
                                pUid = (Convert.ToInt32(pUid) + 1).ToString();
                            }
                            catch
                            {
                                pUid = "1";
                            }
                            pZ = true;
                        }
                        else 
                        {
                            pUid = (Convert.ToInt32(pUid) + 1).ToString();
                        }

                        string query = "INSERT INTO TableTableChast (Id, Nomenklatura, EdIzm, Kolichestvo, Cena, Summa, UID) VALUES(@pId, @pNomen, @pEdIzm, @pKol, @pCena, @pSumma, @pUid)";
                        DAUpdateCmd = new SqlCommand(query, cn);

                        DAUpdateCmd.Parameters.AddWithValue("@pId", pId);
                        DAUpdateCmd.Parameters.AddWithValue("@pNomen", pNomen);
                        DAUpdateCmd.Parameters.AddWithValue("@pEdIzm", pEdIzm);
                        DAUpdateCmd.Parameters.AddWithValue("@pKol", pKol);
                        DAUpdateCmd.Parameters.AddWithValue("@pCena", pCena);
                        DAUpdateCmd.Parameters.AddWithValue("@pSumma", pSumma);
                        DAUpdateCmd.Parameters.AddWithValue("@pUid", pUid);
                        
                        DAUpdateCmd.ExecuteNonQuery();
                    }
                    else if (dataGridView1.Rows[nn].Cells[0].Value.ToString() == pId1)
                    {
                        pUid = dataGridView1.Rows[nn].Cells[6].Value.ToString();
                        DAUpdateCmd = new SqlCommand("Update TableTableChast set TableTableChast.Id=@pId, Nomenklatura=@pNomen, EdIzm=@pEdIzm, Kolichestvo=@pKol, Cena=@pCena, Summa=@pSumma, UID=@pUid  where TableTableChast.Id = " + pId1+ " AND UID = " + pUid, connection);

                        DAUpdateCmd.Parameters.Add(new SqlParameter("@pId", SqlDbType.Int));
                        DAUpdateCmd.Parameters["@pId"].SourceVersion = DataRowVersion.Current;
                        DAUpdateCmd.Parameters["@pId"].SourceColumn = "Id";

                        DAUpdateCmd.Parameters.Add(new SqlParameter("@pNomen", SqlDbType.Int));
                        DAUpdateCmd.Parameters["@pNomen"].SourceVersion = DataRowVersion.Current;
                        DAUpdateCmd.Parameters["@pNomen"].SourceColumn = "Nomenklatura";

                        DAUpdateCmd.Parameters.Add(new SqlParameter("@pEdIzm", SqlDbType.Int));
                        DAUpdateCmd.Parameters["@pEdIzm"].SourceVersion = DataRowVersion.Current;
                        DAUpdateCmd.Parameters["@pEdIzm"].SourceColumn = "EdIzm";

                        DAUpdateCmd.Parameters.Add(new SqlParameter("@pKol", SqlDbType.Decimal));
                        DAUpdateCmd.Parameters["@pKol"].SourceVersion = DataRowVersion.Current;
                        DAUpdateCmd.Parameters["@pKol"].SourceColumn = "Kolichestvo";

                        DAUpdateCmd.Parameters.Add(new SqlParameter("@pCena", SqlDbType.Decimal));
                        DAUpdateCmd.Parameters["@pCena"].SourceVersion = DataRowVersion.Current;
                        DAUpdateCmd.Parameters["@pCena"].SourceColumn = "Cena";

                        DAUpdateCmd.Parameters.Add(new SqlParameter("@pSumma", SqlDbType.Decimal));
                        DAUpdateCmd.Parameters["@pSumma"].SourceVersion = DataRowVersion.Current;
                        DAUpdateCmd.Parameters["@pSumma"].SourceColumn = "Summa";
                        
                        DAUpdateCmd.Parameters.Add(new SqlParameter("@pUid", SqlDbType.NVarChar));
                        DAUpdateCmd.Parameters["@pUid"].SourceVersion = DataRowVersion.Current;
                        DAUpdateCmd.Parameters["@pUid"].SourceColumn = "UID";

                        cmdBuilder2 = new SqlCommandBuilder(da2);
                   
                        da2.Fill(NomenDataSet, "TableTableChast");

                        tt = -1;
                        pNomen = 1;
                        while (tt <= Nomenklatura.Items.Count - 1)
                        {
                            tt++;
                            if (dataGridView1.Rows[nn].Cells[1].Value.ToString().Trim() == Nomenklatura.Items[tt].ToString().Trim())
                            {
                                pNomen = idNomen[tt + 1];
                                break;
                            }
                        }
                        tt = -1;
                        pEdIzm = 1;
                        while (tt <= EdIzm.Items.Count - 1)
                        {
                            tt++;
                            if (dataGridView1.Rows[nn].Cells[2].Value.ToString().Trim() == EdIzm.Items[tt].ToString().Trim())
                            {
                                pEdIzm = idEdIzm[tt + 1];
                                break;
                            }
                        }
                        try
                        {
                            pKol = Convert.ToDecimal(dataGridView1.Rows[nn].Cells[3].Value);
                        }
                        catch { MessageBox.Show("В "+(nn+1).ToString()+" строке значение Количество имеет неверный формат!"); return; }
                        try
                        {
                            pCena = Convert.ToDecimal(dataGridView1.Rows[nn].Cells[4].Value);
                        }
                        catch { MessageBox.Show("В " + (nn+1).ToString() + " строке значение Цена имеет неверный формат!"); return; }
                        try
                        {
                            pSumma = Convert.ToDecimal(dataGridView1.Rows[nn].Cells[5].Value);
                        }
                        catch { MessageBox.Show("В " + (nn + 1).ToString() + " строке значение Сумма имеет неверный формат!"); return; }

                        //Assign the SqlCommand to the UpdateCommand property of the SqlDataAdapter
                        da2.UpdateCommand = DAUpdateCmd;

                        //MessageBox.Show(NomenDataSet.Tables["TableTableChast"].Rows[0]["Nomenklatura"].ToString()+"/"+ this.Nomenklatura.Items[pNomen]);
                        NomenDataSet.Tables["TableTableChast"].Rows[nn]["Nomenklatura"] = pNomen;
                        NomenDataSet.Tables["TableTableChast"].Rows[nn]["EdIzm"] = pEdIzm;
                        NomenDataSet.Tables["TableTableChast"].Rows[nn]["Kolichestvo"] = pKol;
                        NomenDataSet.Tables["TableTableChast"].Rows[nn]["Cena"] = pCena;
                        NomenDataSet.Tables["TableTableChast"].Rows[nn]["Summa"] = pSumma;
                        NomenDataSet.Tables["TableTableChast"].Rows[nn]["UID"] = pUid;
                        NomenDataSet.Tables["TableTableChast"].Rows[nn]["Id"] = pId;

                        da2.Update(NomenDataSet, "TableTableChast");
                        //dataGridView1.DataSource = NomenDataSet.Tables["TableTableChast"];
                    }
                }
                if (nn >= dataGridView1.Rows.Count - 2)
                {
                    break;
                }
                nn++;
            } while (pId1 == pId.ToString());

            Form7.ActiveForm.Close();
            Form6.ActiveForm.Close();
            Form2.ActiveForm.Activate();
            Form x = new Form6();
            x.Show();
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            decimal nsum,nsum1,nsum2;
            try
            {
                if ((e.ColumnIndex == 3) || (e.ColumnIndex == 4))
                {   nsum = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                    nsum1 = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                    nsum2 = nsum * nsum1;
                    dataGridView1.Rows[e.RowIndex].Cells[5].Value = nsum2;
                }
                string con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20";

                SqlConnection connection = new SqlConnection(con);
                connection.Open();
                if (e.ColumnIndex == 1) 
                {
                    {
                        string sql1 = "Select EdIzm.Naimenovanie as EdIzm1, Nomenklatura.naimenovanie from Nomenklatura  Left join EdIzm ON EdIzm.Id=Nomenklatura.EdIzm where RTRIM(Nomenklatura.naimenovanie)='" + dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim() + "'";
                        SqlCommand sqlCm = new SqlCommand(sql1, connection);
                        SqlDataReader SqlR = sqlCm.ExecuteReader();
                        while (SqlR.Read())
                        {
                            dataGridView1.Rows[e.RowIndex].Cells[2].Value = SqlR.GetValue(0);
                            break;
                        }
                        SqlR.Close();
                    }
                }
            }
            catch { }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                string con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20";
                SqlConnection connection = new SqlConnection(con);
                connection.Open();
                
                int pId = Convert.ToInt32(tId.Text.Trim());
                string pUid = dataGridView1.Rows[e.Row.Index].Cells[6].Value.ToString();
                string sql1 = "Delete from TableTableChast where Id=" + pId + " AND UID= " + pUid;
                SqlCommand SqlC = new SqlCommand();
                SqlC.Connection = connection;
                SqlC.CommandText = sql1;
                SqlC.ExecuteNonQuery();
            }
            catch {
                try
                { 
                     dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                }
                catch { }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("  Удалить строки?", "Удаление", MessageBoxButtons.OKCancel);
            
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            
            string con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20";

            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            int pId = Convert.ToInt32(tId.Text.Trim());
            bool pDel = false;
            foreach (DataGridViewRow ppRow in dataGridView1.SelectedRows)
            {
                pDel = true;
                try
                {
                    string pUid = ppRow.Cells[6].Value.ToString().Trim();
                    string sql1 = "Delete from TableTableChast where Id=" + pId + " AND UID= " + pUid;
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
