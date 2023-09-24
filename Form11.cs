using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;


namespace WindowsFormsApp8
{
    public partial class Form11 : Form
    {

        public Form11()
        {
            InitializeComponent();
            fromDate.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            toDate.CustomFormat= "dd/MM/yyyy hh:mm:ss";
            fromDate.Value = new DateTime(2010, 05, 03);
            toDate.Value = new DateTime(2021, 12, 03);
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            string _selectQuery = @"SELECT  Kontragent.Naimenovanie AS Kontragent, Nomenklatura.Naimenovanie AS Nomenklatura, EdIzm.Naimenovanie AS EdIzm, SUM(TableTableChast.Kolichestvo) AS Kolichestvo, SUM(TableTableChast.Summa) " +
                         " AS Summa " +
"FROM            TableTableChast LEFT OUTER JOIN " +
                         " Nomenklatura AS Nomenklatura ON TableTableChast.Nomenklatura = Nomenklatura.Id LEFT OUTER JOIN " +
                         " EdIzm AS EdIzm ON TableTableChast.EdIzm = EdIzm.Id LEFT OUTER JOIN " +
                         " TableDoc AS TableDoc ON TableDoc.Id = TableTableChast.Id LEFT OUTER JOIN " +
                         " Kontragent AS Kontragent ON TableDoc.Kontragent = Kontragent.Id " +
" WHERE (TableDoc.DataDoc BETWEEN '" + fromDate.Value + "' AND '" + toDate.Value + "') " +
" GROUP BY Kontragent.Naimenovanie, Nomenklatura.Naimenovanie, EdIzm.Naimenovanie " +
" UNION " +
" SELECT        Kontragent_1.Naimenovanie AS Kontragent, Nomenklatura_1.Naimenovanie AS Nomenklatura, EdIzm_1.Naimenovanie AS EdIzm, SUM(- TableTableChast2.Kolichestvo) AS Kolichestvo, " +
"                         SUM(- TableTableChast2.Summa) AS Summa " +
"FROM            TableTableChast2 LEFT OUTER JOIN " +
                         " Nomenklatura AS Nomenklatura_1 ON TableTableChast2.Nomenklatura = Nomenklatura_1.Id LEFT OUTER JOIN " +
                         " EdIzm AS EdIzm_1 ON TableTableChast2.EdIzm = EdIzm_1.Id LEFT OUTER JOIN " +
                         " TableDoc2 AS TableDoc2 ON TableDoc2.Id = TableTableChast2.Id LEFT OUTER JOIN " +
                         " Kontragent AS Kontragent_1 ON TableDoc2.Kontragent = Kontragent_1.Id " +
            " WHERE(TableDoc2.DataDoc BETWEEN '" + fromDate.Value + "' AND '" + toDate.Value + "') " +
            " GROUP BY Kontragent_1.Naimenovanie, Nomenklatura_1.Naimenovanie, EdIzm_1.Naimenovanie";

            IDbConnection db;
            db = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20");
            db.Open();

            List<DataTable3> dt = db.Query<DataTable3>(_selectQuery).AsList<DataTable3>();
            db.Close();

            this.dataTable1BindingSource.DataSource = dt;
            ReportParameter[] p = new ReportParameter[]
            {
                new ReportParameter("ReportParameter1",fromDate.Value.ToString()),
                new ReportParameter("ReportParameter2",toDate.Value.ToString())
            };
            reportViewer1.LocalReport.SetParameters(p);


            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;

            reportViewer1.RefreshReport();
        }

        private void reportViewer1_ReportRefresh(object sender, CancelEventArgs e)
        {
            Form11_Load(sender, e);
        }
    }
}
