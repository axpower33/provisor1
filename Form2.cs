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

        private void ПриходнаяНакладнаяToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form x = new Form1();
            x.Show();
        }

        private void ЕдиницаИзмеренияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new Form3();
            x.Show();
        }

        private void КонтрагентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new Form4();
            x.Show();

        }

        private void НоменклатураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new Form5();
            x.Show();
        }

        private void ПриходнаяНакладнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2.ActiveForm.Activate();
            
            Form x = new Form6();
            x.Show();
        }

        private void РасходнаяНакладнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new Form8();
            x.Show();
        }

        private void РасходнаяНакладнаяToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form x = new Form10();
            x.Show();
        }

        private void ПриходрасходНоменклатурыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new Form11();
            x.Show();

        }

        private void ОборотнаяВедомостьНоменклатураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new Form12();
            x.Show();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20";

            SqlConnection connection = new SqlConnection(con);
            connection.Open();
        }

        private void НоменToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new Form13();
            x.Show();
        }

        private void ghToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new Form15();
            x.Show();
        }

        private void crystalReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form x = new Form18();
            x.Show();
        }

		private void windowsMediaPlayerToolStripMenuItem_Click(object sender, EventArgs e)
		{
            Form x = new Form19();
            x.Show();
        }
	}
}
