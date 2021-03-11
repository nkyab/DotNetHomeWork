using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String s1 = textBox1.Text;
            double d1 = double.Parse(s1);
            String s2 = textBox2.Text;
            double d2 = double.Parse(s2);
            double d3 = d1 + d2;
            textBox3.Text = d3.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String s1 = textBox1.Text;
            double d1 = double.Parse(s1);
            String s2 = textBox2.Text;
            double d2 = double.Parse(s2);
            double d3 = d1 - d2;
            textBox3.Text = d3.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String s1 = textBox1.Text;
            double d1 = double.Parse(s1);
            String s2 = textBox2.Text;
            double d2 = double.Parse(s2);
            double d3 = d1 * d2;
            textBox3.Text = d3.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String s1 = textBox1.Text;
            double d1 = double.Parse(s1);
            String s2 = textBox2.Text;
            double d2 = double.Parse(s2);
            double d3 = d1 / d2;
            textBox3.Text = d3.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            String s3 = textBox3.Text;
            Console.WriteLine($"s3");
        }
    }
}
