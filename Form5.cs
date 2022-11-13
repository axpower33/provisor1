using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace WindowsFormsApp8
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();

            this.dataGridView1.AutoGenerateColumns = false;
            SqlConnection Con;
            Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 30");
            Con.Open();

            SqlCommand c = new SqlCommand(@"Select  A.Id, A.Naimenovanie, EdIzm.Naimenovanie as EdIzm, Kontragent.Naimenovanie as Kontragent from Nomenklatura as A left join EdIzm ON EdIzm.Id = A.EdIzm  left join Kontragent ON Kontragent.Id = A.Kontragent", Con);
            SqlDataReader r = c.ExecuteReader();

            //this.dataGridView1.DataSource = r;
            this.dataGridView1.Rows.Clear();
            int i = 0;
            while (r.Read())
            {
                i++;
                this.dataGridView1.Rows.Add();

                for (int j = 0; j <= 3; j++)
                {
                    this.dataGridView1.Rows[i - 1].Cells[j].Value = r.GetValue(j);
                }
            }

            r.Close();
            SqlDataAdapter da7;
            var sql7 = (@"select Id, Naimenovanie as EdIzm from EdIzm");
            da7 = new SqlDataAdapter(sql7, Con);
            SqlCommand c7 = new SqlCommand(sql7, Con);
            SqlDataReader r7 = c7.ExecuteReader();
            int ii = 0;
            int[] idEdIzm = new int[100];
            this.edizm.Items.Clear();
            while (r7.Read())
            {
                ii++;
                this.edizm.Items.Add((object)r7.GetValue(1));
                idEdIzm[ii] = (int)r7.GetValue(0);
            }
            r7.Close();

            sql7 = (@"select Id, Naimenovanie as kontragent from Kontragent");
            da7 = new SqlDataAdapter(sql7, Con);
            c7 = new SqlCommand(sql7, Con);
            r7 = c7.ExecuteReader();
            ii = 0;
            int[] idKont = new int[100];
            this.kontragent.Items.Clear();
            while (r7.Read())
            {
                ii++;
                this.kontragent.Items.Add((object)r7.GetValue(1));
                idKont[ii] = (int)r7.GetValue(0);
            }
            r7.Close();
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            DataSet NomenDataSet = new DataSet();
            SqlDataAdapter da;

            SqlCommandBuilder cmdBuilder;
            da = new SqlDataAdapter(@"Select A.Id, A.Naimenovanie, Kontragent.Naimenovanie as Kontragent, EdIzm.Naimenovanie as EdIzm from Nomenklatura as A left join Kontragent ON Kontragent.Id = A.Kontragent left join EdIzm ON EdIzm.Id = A.EdIzm", cn);

            SqlCommand DAUpdateCmd = da.UpdateCommand;
            cn.ConnectionString = (@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20");
            cn.Open();
            SqlDataAdapter da7;
            var sql7 = (@"select Id, Naimenovanie as EdIzm from EdIzm");
            da7 = new SqlDataAdapter(sql7, cn);
            SqlCommand c7 = new SqlCommand(sql7, cn);
            SqlDataReader r7 = c7.ExecuteReader();
            int ii = 0;
            int[] idEdIzm = new int[100];
            this.edizm.Items.Clear();
            while (r7.Read())
            {
                ii++;
                this.edizm.Items.Add((object)r7.GetValue(1));
                idEdIzm[ii] = (int)r7.GetValue(0);
            }
            r7.Close();

            sql7 = (@"select Id, Naimenovanie as kontragent from Kontragent");
            da7 = new SqlDataAdapter(sql7, cn);
            c7 = new SqlCommand(sql7, cn);
            r7 = c7.ExecuteReader();
            ii = 0;
            int[] idKont = new int[100];
            this.kontragent.Items.Clear();
            while (r7.Read())
            {
                ii++;
                this.kontragent.Items.Add((object)r7.GetValue(1));
                idKont[ii] = (int)r7.GetValue(0);
            }
            r7.Close();

            int nn = 0;
            do
            {
                if (nn <= dataGridView1.Rows.Count - 2)
                {
                    if (this.dataGridView1.Rows[nn].Cells[0].Value == null)
                    {
                        int tt = -1;
                        int pEdIzm = 1;
                        while (tt <= this.edizm.Items.Count - 1)
                        {
                            tt++;
                            if (dataGridView1.Rows[nn].Cells[2].Value.ToString().Trim() == this.edizm.Items[tt].ToString().Trim())
                            {
                                pEdIzm = (int)idEdIzm[tt] + 1;
                                break;
                            }
                        }
                        tt = -1;
                        int pKont = 1;
                        while (tt <= this.kontragent.Items.Count - 1)
                        {
                            tt++;
                            if (dataGridView1.Rows[nn].Cells[3].Value.ToString().Trim() == this.kontragent.Items[tt].ToString().Trim())
                            {
                                pKont = (int)idKont[tt] + 1;
                                break;
                            }
                        }

                        string pNaim = (string)dataGridView1.Rows[nn].Cells[1].Value;
                        int pId = nn + 1;

                        string query = "INSERT INTO Nomenklatura (id, naimenovanie, edizm, kontragent) VALUES(@pId, @pNaim, @pEdIzm, @pKont)";
                        DAUpdateCmd = new SqlCommand(query, cn);

                        DAUpdateCmd.Parameters.AddWithValue("@pId", pId);
                        DAUpdateCmd.Parameters.AddWithValue("@pNaim", pNaim);
                        DAUpdateCmd.Parameters.AddWithValue("@pEdIzm", pEdIzm);
                        DAUpdateCmd.Parameters.AddWithValue("@pKont", pKont);

                        DAUpdateCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        int tt = -1;
                        int pEdIzm = 1;
                        while (tt <= this.edizm.Items.Count - 1)
                        {
                            tt++;
                            if (dataGridView1.Rows[nn].Cells[2].Value.ToString().Trim() == this.edizm.Items[tt].ToString().Trim())
                            {
                                pEdIzm = (int)idEdIzm[tt] + 1;
                                break;
                            }
                        }

                        tt = -1;
                        int pKont = 1;
                        while (tt <= this.kontragent.Items.Count - 1)
                        {
                            tt++;
                            if (dataGridView1.Rows[nn].Cells[3].Value.ToString().Trim() == this.kontragent.Items[tt].ToString().Trim())
                            {
                                pKont = (int)idKont[tt] + 1;
                                break;
                            }
                        }

                        string pNaim = (string)dataGridView1.Rows[nn].Cells[1].Value;
                        int pId = (int)dataGridView1.Rows[nn].Cells[0].Value;
                        DAUpdateCmd = new SqlCommand("Update Nomenklatura set naimenovanie = @pNaim, edizm=@pEdIzm, kontragent=@pKont where id=@pId", da.SelectCommand.Connection);

                        ////Create and append the parameters for the Update command
                        DAUpdateCmd.Parameters.Add(new SqlParameter("@pNaim", SqlDbType.NVarChar));
                        DAUpdateCmd.Parameters["@pNaim"].SourceVersion = DataRowVersion.Current;
                        DAUpdateCmd.Parameters["@pNaim"].SourceColumn = "naimenovanie";

                        DAUpdateCmd.Parameters.Add(new SqlParameter("@pId", SqlDbType.Int));
                        DAUpdateCmd.Parameters["@pId"].SourceVersion = DataRowVersion.Current;
                        DAUpdateCmd.Parameters["@pId"].SourceColumn = "Id";

                        DAUpdateCmd.Parameters.Add(new SqlParameter("@pEdIzm", SqlDbType.Int));
                        DAUpdateCmd.Parameters["@pEdIzm"].SourceVersion = DataRowVersion.Current;
                        DAUpdateCmd.Parameters["@pEdIzm"].SourceColumn = "edizm";

                        DAUpdateCmd.Parameters.Add(new SqlParameter("@pKont", SqlDbType.Int));
                        DAUpdateCmd.Parameters["@pKont"].SourceVersion = DataRowVersion.Current;
                        DAUpdateCmd.Parameters["@pKont"].SourceColumn = "kontragent";

                        cmdBuilder = new SqlCommandBuilder(da);

                        da.Fill(NomenDataSet, "Nomenklatura");

                        da.UpdateCommand = DAUpdateCmd;

                        NomenDataSet.Tables["Nomenklatura"].Rows[nn]["Naimenovanie"] = (string)dataGridView1.Rows[nn].Cells[1].Value;
                        NomenDataSet.Tables["Nomenklatura"].Rows[nn]["Id"] = (int)dataGridView1.Rows[nn].Cells[0].Value;
                        NomenDataSet.Tables["Nomenklatura"].Rows[nn]["EdIzm"] = pEdIzm;
                        NomenDataSet.Tables["Nomenklatura"].Rows[nn]["Kontragent"] = pKont;

                        da.Update(NomenDataSet, "Nomenklatura");
                        //dataGridView1.DataSource = NomenDataSet.Tables[0];
                    }
                }
                if (nn >= this.dataGridView1.Rows.Count - 2)
                {
                    break;
                }
                nn++;

            } while (1 == 1) ;

            cn.Close();
            Form5.ActiveForm.Close();
        }
    }
}
