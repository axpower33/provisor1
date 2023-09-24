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
using System.Data.SqlTypes;
using Dapper;
using Microsoft.Reporting.WinForms;


namespace WindowsFormsApp8
{
    public partial class Form17 : Form
    {
        string pId1;

        public Form17(string pId)
        {
            pId1 = pId;
            InitializeComponent();
        }
        private void Form17_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ProvisorBaseDataDataSet2.DataTable1". При необходимости она может быть перемещена или удалена.
            
            string _selectQuery = @"SELECT TableTableChast2.Id, Nomenklatura.Naimenovanie as Nomenklatura, Edizm.Naimenovanie as EdIzm, Kolichestvo, Cena, Summa, UID FROM TableTableChast2 left join EdIzm on EdIzm.Id=EdIzm left join Nomenklatura on Nomenklatura.Id=Nomenklatura where TableTableChast2.Id=" + pId1+" ORDER BY UID";
            string _selectQuery2 = @"Select DataDoc, NomerDoc, Kontragent.Naimenovanie as Kontragent, TableDoc2.Id from TableDoc2 left join Kontragent ON Kontragent.Id = Kontragent where TableDoc2.Id=" + pId1;

            IDbConnection db;
            db = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20");
            db.Open();

            List<DataTable1> dt = db.Query<DataTable1>(_selectQuery).AsList<DataTable1>();
            List<DataTable2> dt2 = db.Query<DataTable2>(_selectQuery2).AsList<DataTable2>();
            db.Close();

            this.DataTable1BindingSource.DataSource = dt;
            this.dataTable1BindingSource1.DataSource = dt2;
            ReportParameter[] p = new ReportParameter[]
            {
                new ReportParameter("ReportParameter1","Петров"),
                new ReportParameter("ReportParameter2","Васечкин")
            };
            reportViewer1.LocalReport.SetParameters(p);

            // TODO: данная строка кода позволяет загрузить данные в таблицу "ProvisorBaseDataDataSet1.DataTable1". При необходимости она может быть перемещена или удалена.
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_ReportRefresh(object sender, CancelEventArgs e)
        {
            Form17_Load(sender, e);
        }
    }
}
