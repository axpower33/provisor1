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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ProvisorBaseDataDataSet4.DataTable1". При необходимости она может быть перемещена или удалена.
            dataTable1TableAdapter.Fill(ProvisorBaseDataDataSet4.DataTable1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ProvisorBaseDataDataSet4.TableTableChast2". При необходимости она может быть перемещена или удалена.
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;

            reportViewer1.RefreshReport();
        }
    }
}
