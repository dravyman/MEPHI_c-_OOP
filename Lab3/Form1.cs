using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        Counter16 count;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count = new Counter16();
            setValuesOnForm();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                count = new Counter16(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
                setValuesOnForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int min = rnd.Next(0, 100);
            int def = rnd.Next(0,10000);
            int val = rnd.Next(min, min + def);
            try
            {
                count = new Counter16(min, min+def, val);
                setValuesOnForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                count.decValue();
                setValuesOnForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                count.incValue();
                setValuesOnForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void setValuesOnForm()
        {
            textBox1.Text = count.Min.ToString();
            textBox2.Text = count.Max.ToString();
            textBox3.Text = count.Value10.ToString();
            textBox4.Text = count.Value16.ToString();
        }

    }
}
