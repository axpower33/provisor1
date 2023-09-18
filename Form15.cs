using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            FRSPTableAdapter.Fill(fractalsDataSet.FRSP);
            this.reportViewer1.RefreshReport();
        }
        
        private void reportViewer1_ReportRefresh_1(object sender, CancelEventArgs e)
        {
            Form15_Load(sender, e);
        }
    }
}
