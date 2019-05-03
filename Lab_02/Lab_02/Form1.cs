using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            double x1, x2, dx, result;
            double a = 2.3;
            x1 = Double.Parse(textBox1.Text);
            x2 = Double.Parse(textBox2.Text);
            dx = Double.Parse(textBox3.Text);
            if (x1 > x2)
            {
                MessageBox.Show("Неверные значения переменных");
                return;
            }
            for (double i = x1; i <= x2; i = i + dx)
            {
                if (i < 1)
                {
                    result = 1.5 * Math.Pow(Math.Cos(i), 2);
                    listBox1.Items.Add(String.Format("X = " + i + "\t S = " + result.ToString("F4")));
                }
                else if (i == 1)
                {
                    result = 1.8 * a * i;
                    listBox1.Items.Add(String.Format("X = " + i + "\t S = " + result.ToString("F4")));
                }
                else if (i < 2 && i > 1)
                {
                    result = Math.Pow(i - 2, 2) + 6;
                    listBox1.Items.Add(String.Format("X = " + i + "\t S = " + result.ToString("F4")));
                }
                else if (i > 2)
                {
                    result = 3 * Math.Tan(i);
                    listBox1.Items.Add(String.Format("X = " + i + "\t S = " + result.ToString("F4")));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) => Close();
    }
}
