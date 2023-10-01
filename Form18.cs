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
using Dapper;

namespace WindowsFormsApp8
{
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            IDbConnection db;
            db = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\axpower\Source\Repos\fRSH5\fRSH5\fractals.mdf""; Integrated Security = True; Connect Timeout = 20");
            db.Open();
            string _selectQuery = "Select X,Y,Z from FRSP";
            List<FRSP> dt = db.Query<FRSP>(_selectQuery).AsList<FRSP>().ToList();
            db.Close();         
            crystalReport11.SetDataSource(dt);
            
            this.crystalReportViewer1.ReportSource = crystalReport11;
            this.crystalReportViewer1.Refresh();
        }

        private void crystalReportViewer1_ReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
        {
            Form18_Load(source, e);
        }
    }
}
