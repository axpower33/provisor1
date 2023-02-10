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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "provisorBaseDataDataSet.Nomenklatura". При необходимости она может быть перемещена или удалена.
            nomenklaturaTableAdapter.Fill(provisorBaseDataDataSet.Nomenklatura);

        }

        private void button1_Click(object sender, EventArgs e)
        {

                nomenklaturaTableAdapter.Update(provisorBaseDataDataSet);
                Form13.ActiveForm.Close();

        }
    }
}
