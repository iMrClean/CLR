using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_05
{
    public partial class Form1 : Form
    {
        string title = "Текстовый редактор";

        string currentPath = string.Empty;

        string currentFileName = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res;

            if (richTextBox1.Text.Length > 0)
            {
                res = MessageBox.Show("Сохранить изменения в файле " + currentFileName + " ? ", "Блокнот", MessageBoxButtons.YesNoCancel);
                switch (res)
                {
                    case DialogResult.Yes:
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            currentPath = openFileDialog.FileName;
                            currentFileName = openFileDialog.SafeFileName;
                            richTextBox1.SaveFile(currentPath, RichTextBoxStreamType.PlainText);
                        }
                        break;
                    case DialogResult.No:
                        currentPath = string.Empty;
                        currentFileName = string.Empty;
                        this.Text = title;
                        richTextBox1.Clear();
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentPath = openFileDialog.FileName;
                currentFileName = openFileDialog.SafeFileName;
                richTextBox1.LoadFile(currentPath, RichTextBoxStreamType.PlainText);
                this.Text = currentFileName + " - " + title;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentPath == string.Empty)
            {
                сохранитьКакToolStripMenuItem_Click(sender, e);
            }
            else
            {
                richTextBox1.SaveFile(currentPath, RichTextBoxStreamType.PlainText);
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentPath = openFileDialog.FileName;
                currentFileName = openFileDialog.SafeFileName;
                richTextBox1.SaveFile(currentPath, RichTextBoxStreamType.PlainText);
            }
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {
                e.Graphics.DrawString(richTextBox1.Lines[i], richTextBox1.Font, Brushes.Black, 10, 10 * i);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res;
            if (richTextBox1.Text.Length > 0)
            {
                res = MessageBox.Show("Сохранить изменения в файле " + currentFileName + "перед выходом? ", "Блокнот", MessageBoxButtons.YesNoCancel);

                switch (res)
                {
                    case DialogResult.Yes:
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            currentPath = openFileDialog.FileName;
                            richTextBox1.SaveFile(currentPath, RichTextBoxStreamType.PlainText);
                            Application.Exit();
                        }
                        break;
                    case DialogResult.No:
                        Application.Exit();
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Undo();

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Cut();

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Copy();

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Paste();

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.SelectedText = string.Empty;

    }
}
