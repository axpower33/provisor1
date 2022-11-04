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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "provisorBaseDataDataSet.Kontragent". При необходимости она может быть перемещена или удалена.
            this.kontragentTableAdapter.Fill(this.provisorBaseDataDataSet.Kontragent);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.kontragentTableAdapter.Update(this.provisorBaseDataDataSet);
            Form4.ActiveForm.Close();
        }
    }
}
