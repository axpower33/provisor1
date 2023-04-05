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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ProvisorBaseDataDataSet.DataTable1". При необходимости она может быть перемещена или удалена.
            dataTable1TableAdapter.Fill(ProvisorBaseDataDataSet.DataTable1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ProvisorBaseDataDataSet.TableTableChast". При необходимости она может быть перемещена или удалена.
            dataTable1TableAdapter1.Fill(provisorBaseDataDataSet11.DataTable1);
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }

        private void reportViewer1_ReportRefresh(object sender, CancelEventArgs e)
        {
            Form1_Load(sender, e);
        }
    }
}
