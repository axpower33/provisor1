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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void приходнаяНакладнаяToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form x = new Form1();
            x.Show();
        }

        private void единицаИзмеренияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new Form3();
            x.Show();
        }

        private void контрагентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new Form4();
            x.Show();

        }

        private void номенклатураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new Form5();
            x.Show();
        }

        private void приходнаяНакладнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2.ActiveForm.Activate();
            
            Form x = new Form6();
            x.Show();
        }

        private void расходнаяНакладнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new Form8();
            x.Show();
        }

        private void расходнаяНакладнаяToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form x = new Form10();
            x.Show();
        }

        private void приходрасходНоменклатурыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new Form11();
            x.Show();

        }

        private void оборотнаяВедомостьНоменклатураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new Form12();
            x.Show();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20";

            var connection = new SqlConnection(con);
            connection.Open();
        }

        private void номенToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new Form13();
            x.Show();
        }
    }
}
