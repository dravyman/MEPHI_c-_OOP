using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program8
{
    public partial class Form1 : Form
    {
        Bitmap image1;
        PictureBox pictureBox1  = new PictureBox();

        public Form1()
        {
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.Text = "Искусство аборигенов";
            this.Size = new Size(302, 240);
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.ClientSize = new Size(300, 196);
            image1 = new Bitmap(@"../../images/Desert.jpg");
            pictureBox1.Image = (Image)image1;
            this.Controls.Add(pictureBox1);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.ClientSize = new Size(this.ClientSize.Width -1 , this.ClientSize.Height -1 );
        }
    }
}
