using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program6
{
    public partial class Form1 : Form
    {

        ListBox listBox1;

        public Form1()
        {
            
            this.Size = new Size(400, 400);

            //PictureBox
            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Bitmap image1 = new Bitmap ("..//..//images//Desert.jpg");
            pictureBox1.ClientSize = new Size(this.Width, 150);
            pictureBox1.Image = (Image)image1;
            this.Controls.Add(pictureBox1);

            //Button
            Button button1 = new System.Windows.Forms.Button();
            button1.Location = new Point(150, 160);
            button1.Size = new Size(100, 30);
            button1.Text = "Нажми меня";
            button1.Click += new System.EventHandler(button1_Click);
            this.Controls.Add(button1);

            // ListBox
            listBox1 = new System.Windows.Forms.ListBox();
            listBox1.Location = new System.Drawing.Point(20, 200);
            listBox1.Size = new Size(100, 100);
            listBox1.Items.Add("Лес");
            listBox1.Items.Add("Степь ");
            listBox1.Items.Add("Озеро");
            listBox1.Items.Add("Море");
            listBox1.Items.Add("Океан");
            listBox1.SelectedIndex = 2;
            this.Controls.Add(listBox1);
        }

        void button1_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(this, "Вы выбрали " + listBox1.SelectedItem,"Уведомление", MessageBoxButtons.OK);
        }
    }
}
