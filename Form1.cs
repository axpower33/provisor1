using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void номенклатураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 xForm2 = new Form2();
            xForm2.Show();

        }

        private void контрагентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 xForm = new Form3();
            xForm.Show();
        }
        private void докприходнаянакладнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 xForm = new Form5();
            xForm.Show();
        }
        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 xForm = new Form6();
            xForm.Show();
        }

    }
}
