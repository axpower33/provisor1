using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace WinFormsApp1
{
    public partial class Form6 : Form
    {
        public Form6()
        { //pos
            InitializeComponent();;;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = (@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20");
            cn.Open();

            DataSet NomenDataSet = new DataSet();
            SqlDataAdapter da;

            da = new SqlDataAdapter(@"Select A.Id, A.Naimenovanie, Kontragent.Naimenovanie as Kontragent, EdIzm.Naimenovanie as EdIzm from Nomenklatura as A left join Kontragent ON Kontragent.Id = A.Kontragent left join EdIzm ON EdIzm.Id = A.EdIzm", cn);

            SqlCommand c = new SqlCommand(@"Select  A.Id, A.Naimenovanie, Kontragent.Naimenovanie as Kontragent, EdIzm.Naimenovanie as EdIzm from Nomenklatura as A left join EdIzm ON EdIzm.Id = A.EdIzm  left join Kontragent ON Kontragent.Id = A.Kontragent", cn);

            da.Fill(NomenDataSet, "Nomenklatura");

            SqlDataReader r = c.ExecuteReader();

            int i = 0;
            while (r.Read())
            {
                i++;
                for (int j = 0; j <= 3; j++)
                {
                   
                    if ((j == 1) & (i==1))
                    {
                        this.textBox1.Text = r.GetValue(j).ToString();
                    }
                    else if ((j == 2)&(i==1))
                    {
                        this.textBox2.Text = r.GetValue(j).ToString();
                    }
                    else if ((j == 3) & (i == 1))
                    {
                        this.textBox3.Text = r.GetValue(j).ToString();
                    }
                    else if ((i == 2) & (j==1))
                    {
                        this.textBox4.Text = r.GetValue(j).ToString();
                    }
                    else if ((i == 2) & (j == 2))
                    {
                        this.textBox5.Text = r.GetValue(j).ToString();
                    }
                    else if ((i == 2) & (j == 3))
                    {
                        this.textBox6.Text = r.GetValue(j).ToString();
                    }
                    else if ((i == 3) & (j == 1))
                    {
                        this.textBox7.Text = r.GetValue(j).ToString();
                    }
                    else if ((i == 3) & (j == 2))
                    {
                        this.textBox8.Text = r.GetValue(j).ToString();
                    }
                    else if ((i == 3) & (j == 3))
                    {
                        this.textBox9.Text = r.GetValue(j).ToString();
                    }
                    else if ((i == 4) & (j == 1))
                    {
                        this.textBox10.Text = r.GetValue(j).ToString();
                    }
                    else if ((i == 4) & (j == 2))
                    {
                        this.textBox11.Text = r.GetValue(j).ToString();
                    }
                    else if ((i == 4) & (j == 3))
                    {
                        this.textBox12.Text = r.GetValue(j).ToString();
                    }
                    else if ((i == 5) & (j == 1))
                    {
                        this.textBox13.Text = r.GetValue(j).ToString();
                    }
                    else if ((i == 5) & (j == 2))
                    {
                        this.textBox14.Text = r.GetValue(j).ToString();
                    }
                    else if ((i == 5) & (j == 3))
                    {
                        this.textBox15.Text = r.GetValue(j).ToString();
                    }
                    else if ((i == 6) & (j == 1))
                    {
                        this.textBox16.Text = r.GetValue(j).ToString();
                    }
                    else if ((i == 6) & (j == 2))
                    {
                        this.textBox17.Text = r.GetValue(j).ToString();
                    }
                    else if ((i == 6) & (j == 3))
                    {
                        this.textBox18.Text = r.GetValue(j).ToString();
                    }
                }
            }
        }

     
        //public Microsoft.Reporting.WinForms.Report reportPanel1;
        private System.ComponentModel.IContainer components;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox15;
        private TextBox textBox16;
        private TextBox textBox17;
        private TextBox textBox18;
        private Button button1;
    }
}
