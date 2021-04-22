using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework7
{
    public partial class Form1 : Form
    {
        int n = 10;
        double leng = 100;
        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        Pen pen = Pens.Blue;
        void drawCayleyTree(int n, double x0, double y0, double leng, double th, Pen pen)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(pen, x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1, pen);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2, pen);
        }
        void drawLine(Pen pen, double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Blue");
            comboBox1.Items.Add("Silver");
            comboBox1.Items.Add("Red");
            comboBox1.Items.Add("Black");
            comboBox1.Items.Add("Gray");
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            double n1;
            double.TryParse(textBox1.Text, out n1);
            n = (int)Math.Abs(n1);
            double.TryParse(textBox2.Text, out leng);
            double.TryParse(textBox3.Text, out per1);
            double.TryParse(textBox4.Text, out per2);
            double.TryParse(textBox5.Text, out th1);
            double.TryParse(textBox6.Text, out th2);
            switch (comboBox1.Text)
            {
                case "Blue": pen = Pens.Blue; break;
                case "Silver": pen = Pens.Silver; break;
                case "Red": pen = Pens.Red; break;
                case "Black": pen = Pens.Black; break;
                case "Gray": pen = Pens.Gray; break;
            }
            drawCayleyTree(n, 300, 600, leng, -Math.PI / 2, pen);
        }
    }
}
