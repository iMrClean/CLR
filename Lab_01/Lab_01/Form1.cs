using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double c, k, f, r;
            c = Double.Parse(textBox1.Text);
            if (c < -273)
            {
                MessageBox.Show("Ниже этого значения температуры не существует");
                return;
            }
            f = 9.0 / 5 * c + 32;
            k = c + 273.15;
            r = 4.0 / 5 * c;
            if (radioButton1.Checked)
            {
                textBox2.Text = f.ToString();
            }
            else if (radioButton2.Checked)
            {
                textBox2.Text = k.ToString();
            }
            else
            {
                textBox2.Text = r.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e) => Close();
    }
}
