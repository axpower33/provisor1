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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "provisorBaseDataDataSet.EdIzm". При необходимости она может быть перемещена или удалена.
            this.edIzmTableAdapter.Fill(this.provisorBaseDataDataSet.EdIzm);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            edIzmTableAdapter.Update(this.provisorBaseDataDataSet);
            Form3.ActiveForm.Close();

        }
    }
}
