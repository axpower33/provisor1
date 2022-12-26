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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "provisorBaseDataDataSet3.DataTable1". При необходимости она может быть перемещена или удалена.
            dataTable1TableAdapter1.Fill(provisorBaseDataDataSet3.DataTable1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ProvisorBaseDataDataSet2.DataTable1". При необходимости она может быть перемещена или удалена.
            DataTable1TableAdapter.Fill(ProvisorBaseDataDataSet2.DataTable1);

            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }
    }
}
