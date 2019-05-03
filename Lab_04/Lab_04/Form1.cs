using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "1,0";
            textBox2.Text = "15,0";
            textBox3.Text = "10";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double pervoobResult, rectResult, trapezResult;
            double a, b, tempPrecis, rectSearchResult, rectSearchPrecis;
            double trapezSearchResult, trapezSearchPrecis;
            int NRazb, i, rectSearchRazb, TrapezSearchRazb;
            //Точность 10^-3, с которой вычисляется интеграл при не фиксированном количестве разбиений.
            double FixPrecis = 0.001;
            richTextBox1.Clear();

            a = Double.Parse(textBox1.Text);
            b = Double.Parse(textBox2.Text);
            NRazb = Int32.Parse(textBox3.Text);
            
            //Вычисляем значение определённого интеграла по первообразной.
            pervoobResult = CalcIntegByPervoobr(a, b);

            //Вычисляем определённый интеграл методом средних прямоугольников с заданным числом разбиений.
            rectResult = CalcIntegByRects(a, b, NRazb);
            //Вычисляем тем же методом, но увеличивая число разбиений до тех пор, пока не достигнем заданной точности.
            i = 0;
            do
            {
                i++;
                rectSearchResult = CalcIntegByRects(a, b, i);
                tempPrecis = Math.Abs(pervoobResult - rectSearchResult);
            } while (tempPrecis > FixPrecis);
            //Нашли, запомним погрешность и количество разбиений.
            rectSearchPrecis = tempPrecis;
            rectSearchRazb = i;

            //Вычисляем определённый интеграл методом трапеций с заданным числом разбиений.
            trapezResult = CalcIntegByTrapez(a, b, NRazb);
            //Вычисляем тем же методом, но увеличивая число разбиений до тех пор,
            //пока не достигнем заданной точности.
            i = 0;
            do
            {
                i++;
                trapezSearchResult = CalcIntegByTrapez(a, b, i);
                tempPrecis = Math.Abs(pervoobResult - trapezSearchResult);
            } while (tempPrecis > FixPrecis);

            //Нашли, запомним погрешность и количество разбиений.
            trapezSearchPrecis = tempPrecis;
            TrapezSearchRazb = i;

            //Выводим результаты. По первообразной
            richTextBox1.AppendText("Значение определённого интеграла по первообразной: ");
            richTextBox1.AppendText(pervoobResult.ToString("F6") + "\n\n");

            //Методом прямоугольников
            richTextBox1.AppendText("Значение определённого интеграла методом средних прямоугольников: ");
            richTextBox1.AppendText(rectResult.ToString("F6") + "\n");

            tempPrecis = Math.Abs(pervoobResult - rectResult);
            richTextBox1.AppendText("Абсолютная погрешность: " + tempPrecis.ToString("F6") + "\n");
            tempPrecis = Math.Abs((tempPrecis / pervoobResult)) * 100;
            richTextBox1.AppendText("Относительная погрешность: " + tempPrecis.ToString("F6") + "%\n");

            richTextBox1.AppendText("Тем же методом, но с заданной точностью: ");
            richTextBox1.AppendText(rectSearchResult.ToString("F6") + "\n");
            richTextBox1.AppendText("Абсолютная погрешность: " + rectSearchPrecis.ToString("F6") + "\n");
            tempPrecis = Math.Abs((rectSearchPrecis / pervoobResult)) * 100;
            richTextBox1.AppendText("Относительная погрешность: " + tempPrecis.ToString("F6") + "%\n");
            richTextBox1.AppendText("Количество разбиений: " + rectSearchRazb.ToString() + "\n\n");

            //Методом трапеций
            richTextBox1.AppendText("Значение определённого интеграла методом трапеций: ");
            richTextBox1.AppendText(trapezResult.ToString("F6") + "\n");
            tempPrecis = Math.Abs(pervoobResult - trapezResult);
            richTextBox1.AppendText("Абсолютная погрешность: " + tempPrecis.ToString("F6") + "\n");
            tempPrecis = Math.Abs((tempPrecis / pervoobResult)) * 100;
            richTextBox1.AppendText("Относительная погрешность: " + tempPrecis.ToString("F6") + "%\n");

            richTextBox1.AppendText("Тем же методом, но с заданной точностью: ");
            richTextBox1.AppendText(trapezSearchResult.ToString("F6") + "\n");
            richTextBox1.AppendText("Абсолютная погрешность: " + trapezSearchPrecis.ToString("F6") + "\n");
            tempPrecis = Math.Abs((trapezSearchPrecis / pervoobResult)) * 100;
            richTextBox1.AppendText("Относительная погрешность: " + tempPrecis.ToString("F6") + "%\n");
            richTextBox1.AppendText("Количество разбиений: " + TrapezSearchRazb.ToString() + "\n\n");
        }

        //Подсчитать значение первообразной.
        private double CalcPervoobr(double x)
        {
            return Math.Log((x / (1 + Math.Sqrt(Math.Pow(x, 2.0) + 1))));
        }

        //Вычисляем определённый интеграл (от a до b) по известной первообразной. Просто используем формулу Ньютона-Лейбница F(b)-F(a)
        private double CalcIntegByPervoobr(double a, double b)
        {
            return CalcPervoobr(b) - CalcPervoobr(a);
        }

        //Функция вычисляет значение исследуемой функции для данного X.
        private double CalcFunc(double X)
        {
            return 1 / (X * Math.Sqrt(Math.Pow(X, 2.0) + 1));
        }

        //Функция вычисляет определённый интеграл методом средних прямоугольников с заданным количеством разбиений.
        private double CalcIntegByRects(double a, double b, int NRazb)
        {
            double result, dx, start;

            //Получаем начальные значения.
            result = 0;
            dx = (b - a) / NRazb;
            start = a + (dx / 2);
            //X посередине первого прямоугольника В цикле проходим по элементам разбиения, накапливая сумму.
            for (int i = 0; i < NRazb; i++)
            {
                result += CalcFunc(start);
                //Переход на следующий прямоугольник.
                start += dx;
            };
            //Умножаем накопленную сумму на ширину прямоугольников
            result = result * dx;
            return result;
        }

        //Функция вычисляет определённый интеграл методом трапеций с заданным количеством разбиений.
        private double CalcIntegByTrapez(double a, double b, int n)
        {
            double result, dx, start;

            //Получаем начальные значения.
            dx = (b - a) / n;
            start = a + dx;
            result = (CalcFunc(a) + CalcFunc(b)) / 2.0;

            //В цикле проходим по элементам разбиения, накапливая сумму.
            for (int i = 0; i < n - 1; i++)
            {
                result += CalcFunc(start);
                start += dx;
            };
            //Умножаем накопленную сумму на ширину прямоугольников
            result = result * dx;
            //И вернём результат.
            return result;
        }

        private void button2_Click(object sender, EventArgs e) => Close();

    }
}
