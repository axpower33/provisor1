using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            this.dataGridView1.AutoGenerateColumns = false;
            SqlConnection Con;
            Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 30");
            Con.Open();

            SqlCommand c = new SqlCommand(@"Select  A.Id, A.Naimenovanie, Kontragent.Naimenovanie as Kontragent, EdIzm.Naimenovanie as EdIzm from Nomenklatura as A left join EdIzm ON EdIzm.Id = A.EdIzm  left join Kontragent ON Kontragent.Id = A.Kontragent", Con);
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
        }

 
        private void button1_Click(object sender, System.EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            DataSet NomenDataSet = new DataSet();
            SqlDataAdapter da;
            
            SqlCommandBuilder cmdBuilder;
            da = new SqlDataAdapter(@"Select A.Id, A.Naimenovanie, Kontragent.Naimenovanie as Kontragent, EdIzm.Naimenovanie as EdIzm from Nomenklatura as A left join Kontragent ON Kontragent.Id = A.Kontragent left join EdIzm ON EdIzm.Id = A.EdIzm", cn);

            SqlCommand DAUpdateCmd= da.UpdateCommand;
            cn.ConnectionString = (@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20");
            cn.Open();

            //da2 = new SqlDataAdapter(@"Select A.Id, A.Naimenovanie, Kontragent.Id as Kontragent, EdIzm.Id as EdIzm from Nomenklatura as A left join Kontragent ON Kontragent.Id = A.Kontragent left join EdIzm ON EdIzm.Id = A.EdIzm", cn);
            //Initialize the SqlCommand object that will be used as the DataAdapter's UpdateCommand
            ////Notice that the WHERE clause uses only the CustId field to locate the record to be updated
            DAUpdateCmd = new SqlCommand("Update Nomenklatura set Naimenovanie = @pNomenName where Id=@pId", da.SelectCommand.Connection);

            ////Create and append the parameters for the Update command
            DAUpdateCmd.Parameters.Add(new SqlParameter("@pNomenName", SqlDbType.NVarChar));
            DAUpdateCmd.Parameters["@pNomenName"].SourceVersion = DataRowVersion.Current;
            DAUpdateCmd.Parameters["@pNomenName"].SourceColumn = "Naimenovanie";

            DAUpdateCmd.Parameters.Add(new SqlParameter("@pId", SqlDbType.Int));
            DAUpdateCmd.Parameters["@pId"].SourceVersion = DataRowVersion.Current;
            DAUpdateCmd.Parameters["@pId"].SourceColumn = "Id";

            cmdBuilder = new SqlCommandBuilder(da);

            //Assign the SqlCommand to the UpdateCommand property of the SqlDataAdapter

            da.Fill(NomenDataSet, "Nomenklatura");

            //Modify the value of the CustName field
            int i = 0;
            while (i < 6)
            {
                i++;
                var pId= (int)dataGridView1.Rows[i - 1].Cells[0].Value;
                var pNomenName= (string) dataGridView1.Rows[i - 1].Cells[1].Value;
                
                da.UpdateCommand = DAUpdateCmd;
 
                NomenDataSet.Tables["Nomenklatura"].Rows[i - 1]["Naimenovanie"] = (string)dataGridView1.Rows[i - 1].Cells[1].Value; 
                NomenDataSet.Tables["Nomenklatura"].Rows[i - 1]["Id"] = (int) dataGridView1.Rows[i - 1].Cells[0].Value;
                NomenDataSet.Tables["Nomenklatura"].Rows[i - 1]["Kontragent"] =  (string) dataGridView1.Rows[i - 1].Cells[2].Value;
                NomenDataSet.Tables["Nomenklatura"].Rows[i - 1]["EdIzm"] =  (string) dataGridView1.Rows[i - 1].Cells[3].Value;
            }
         

            ////Modify the value of the CustName field again
            //da2.Update(NomenDataSet, "Nomenklatura");
            da.Update(NomenDataSet, "Nomenklatura");
            dataGridView1.DataSource = NomenDataSet;

            cn.Close();

            Form2.ActiveForm.Close();
        }
    }


}
