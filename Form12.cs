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
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
using System.Globalization;

namespace WindowsFormsApp8
{
    public partial class Form12 : Form
    {
        DateTime fromDate;
        DateTime toDate;
        DateTime fromDate2;
        public Form12()
        {
            InitializeComponent();
            tfromDate.Text = "05.03.2010";
            ttoDate.Text = "05.03.2021";
            fromDate2 = Convert.ToDateTime(tfromDate.Text, CultureInfo.CurrentCulture);
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            fromDate = Convert.ToDateTime(tfromDate.Text,CultureInfo.CurrentCulture);
            toDate = Convert.ToDateTime(ttoDate.Text, CultureInfo.CurrentCulture);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ProvisorBaseDataDataSet5.DataTable1". При необходимости она может быть перемещена или удалена.
            string _selectQuery = @"SELECT    Nomenklatura, SUM(NachOst) AS NachOst, SUM(Prihod) AS Prihod, SUM(Rashod) AS Rashod, SUM(KonOst) AS KonOst" +
" FROM            (SELECT   Nomenklatura.Naimenovanie AS Nomenklatura, SUM(0.00) AS NachOst, SUM(TableTableChast.Summa) AS Prihod, SUM(0.00) AS Rashod, SUM(TableTableChast.Summa - 0.00) AS KonOst" +
                          " FROM            TableTableChast LEFT OUTER JOIN" +
                          " Nomenklatura AS Nomenklatura ON TableTableChast.Nomenklatura = Nomenklatura.Id" +
                          " left outer join TableDoc on TableDoc.Id=TableTableChast.Id"+
                          " WHERE (TableDoc.DataDoc BETWEEN '" + fromDate + "' AND '" + toDate + "') " +
                          " GROUP BY Nomenklatura.Naimenovanie" +
                          " UNION" +
                          " SELECT  Nomenklatura.Naimenovanie AS Nomenklatura, SUM(0.00) AS NachOst, SUM(0.00) AS Prihod, SUM(D.Summa) AS Rashod, SUM(0.00 - D.Summa) AS KonOst" +
                          " FROM            TableTableChast2 AS D LEFT OUTER JOIN" +
                          " Nomenklatura AS Nomenklatura ON D.Nomenklatura = Nomenklatura.Id" +
                          " left outer join TableDoc2 on TableDoc2.Id=D.Id" +
                          " WHERE (TableDoc2.DataDoc BETWEEN '" + fromDate + "' AND '" + toDate + "') " +
                          " GROUP BY Nomenklatura.Naimenovanie) AS derivedtbl_1" +
" GROUP BY Nomenklatura";
            string _selectQuery2 = @"SELECT     Nomenklatura, SUM(NachOst) AS NachOst, Sum(0.00) AS Prihod, SUM(0.00) AS Rashod, SUM(0.00) AS KonOst" +
" FROM            (SELECT   Nomenklatura.Naimenovanie AS Nomenklatura, SUM(TableTableChast.Summa) AS NachOst, SUM(0.00) AS Prihod, SUM(0.00) AS Rashod, SUM(0.00) AS KonOst" +
                          " FROM            TableTableChast LEFT OUTER JOIN" +
                          " Nomenklatura AS Nomenklatura ON TableTableChast.Nomenklatura = Nomenklatura.Id" +
                          " left outer join TableDoc on TableDoc.Id=TableTableChast.Id" +
                          " WHERE (TableDoc.DataDoc BETWEEN '" + fromDate2 + "' AND '" + fromDate.AddDays(-1) + "') " +
                          " GROUP BY Nomenklatura.Naimenovanie" +
                          " UNION" +
                          " SELECT  Nomenklatura.Naimenovanie AS Nomenklatura, SUM(-D.Summa) AS NachOst, SUM(0.00) AS Prihod, SUM(0.00) AS Rashod, SUM(0.00) AS KonOst" +
                          " FROM            TableTableChast2 AS D LEFT OUTER JOIN" +
                          " Nomenklatura AS Nomenklatura ON D.Nomenklatura = Nomenklatura.Id" +
                          " left outer join TableDoc2 on TableDoc2.Id=D.Id" +
                          " WHERE (TableDoc2.DataDoc BETWEEN '" + fromDate2 + "' AND '" + fromDate.AddDays(-1) + "') " +
                          " GROUP BY Nomenklatura.Naimenovanie) AS derivedtbl_2" +
" GROUP BY Nomenklatura";

            IDbConnection db;
            db = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Basko\SqlBases\ProvisorBaseData.mdf""; Integrated Security = True; Connect Timeout = 20");
            db.Open();

            List<DataTable4> dt = db.Query<DataTable4>(_selectQuery).AsList<DataTable4>();
            List<DataTable4> dt2 = db.Query<DataTable4>(_selectQuery2).AsList<DataTable4>();
            int i = 0;
            int j;

            while (i<dt.Count())
            {
                j = 0;
                while (j < dt2.Count())
                {
                    if (dt[i].Nomenklatura == dt2[j].Nomenklatura)
                    {
                        dt[i].NachOst = dt2[j].NachOst;
                        dt[i].KonOst = dt[i].NachOst + dt[i].Prihod - dt[i].Rashod;
                    }
                    j++;
                }
                i++;
            }
            db.Close();

            this.DataTable1BindingSource.DataSource = dt;
            ReportParameter[] p = new ReportParameter[]
            {
                new ReportParameter("ReportParameter1",tfromDate.Text.ToString()),
                new ReportParameter("ReportParameter2",ttoDate.Text.ToString())
            };
            reportViewer1.LocalReport.SetParameters(p);

            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;

            reportViewer1.RefreshReport();
        }

        private void reportViewer1_ReportRefresh(object sender, CancelEventArgs e)
        {
            Form12_Load(sender, e);
        }
    }
}
