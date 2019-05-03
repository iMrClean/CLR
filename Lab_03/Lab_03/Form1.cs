using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("y = e^x*cos(x)");
            comboBox1.Items.Add("y = x^2*ln(x)");
            comboBox1.Items.Add("y = x^2*e^x");
            comboBox1.SelectedIndex = 0;
            textBox1.Text = "1,0";
            textBox2.Text = "3,0";
            textBox3.Text = "0,1";
            richTextBox1.Clear();
            richTextBox1.AppendText("Тут будут результаты.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double start, step, end, result;
            start = Double.Parse(textBox1.Text);
            end = Double.Parse(textBox2.Text);
            step = Double.Parse(textBox3.Text);

            richTextBox1.Clear();
            while(start <= end)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    //y = e^x*cos(x)
                    result = Math.Exp(start) * Math.Cos(start);
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    //y = x^2*ln(x)
                    result = Math.Pow(start, 2.0) * Math.Log(start);
                }
                else
                {
                    //y = x^2*e^x
                    result = Math.Pow(start, 2.0) * Math.Cos(start);
                }
                richTextBox1.AppendText("X=" + start.ToString() + "; Y=" + result.ToString("F4") + ";\n");
                start += step;
            }
        }
    
        private void button2_Click(object sender, EventArgs e) => Close();

    }
}
