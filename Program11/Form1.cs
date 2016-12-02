using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program11
{
    public partial class Form1 : Form
    {
        PictureBox pictureBox1;
        Label label1;
        Point spotClicked;

        public Form1()
        {
            this.Size = new Size(640, 480);

            pictureBox1 = new PictureBox();
            pictureBox1.Image = (Image)new Bitmap(@"../../images/Desert.bmp");
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.MouseDown += new MouseEventHandler(MouseButtonIsDown);
            pictureBox1.MouseUp += new MouseEventHandler(MouseButtonIsUp);
            pictureBox1.MouseMove += new MouseEventHandler(TheMouseMoved);
            this.Controls.Add(pictureBox1);

            label1 = new Label();
            label1.BackColor = Color.Wheat;
            label1.Dock = DockStyle.Bottom;
            label1.Text =
            "При нажатой левой кнопке мыши можно рисовать прямоугольники. " +
            "Нажатая правая кнопка изменяет яркость прямоугольника " +
            "Нажав SHIFT и перемещая мышь, рисуем желтые кружки.";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(label1);

        }

        public void TheMouseMoved(object sender, MouseEventArgs e)
        {
            // Если на клавиатуре нажата клавиша SHIFT
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                System.Drawing.Graphics g = this.pictureBox1.CreateGraphics();
                System.Drawing.Pen yellowPen = new System.Drawing.Pen(Color.Yellow, 3);
                g.DrawEllipse(yellowPen, e.X, e.Y, 40, 40);
                g.Dispose();
            }
        }

        public void MouseButtonIsDown(object sender, MouseEventArgs e)
        {
            spotClicked.X = e.X;
            spotClicked.Y = e.Y;
        }

        public void MouseButtonIsUp(object sender, MouseEventArgs e)
        {
            
            Rectangle r = new Rectangle();
            
            r.X = spotClicked.X;
            r.Y = spotClicked.Y;
            r.Width = e.X - spotClicked.X;
            r.Height = e.Y - spotClicked.Y;
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = this.pictureBox1.CreateGraphics();
                Pen redPen = new Pen(Color.Red, 2);
                g.DrawRectangle(redPen, r);
            }
            else
            {
                ChangeLightness(r);
            }
        }

        public void ChangeLightness(Rectangle rect)
        {
            int newRed, newGreen, newBlue;
            Color pixel;

            Bitmap picture = new Bitmap(this.pictureBox1.Image);
            if ((rect.Width > 150) || (rect.Height > 150))
            {
                DialogResult result = MessageBox.Show("Выделенная область велика! "
                    + "Изменение яркости может требовать значительного времени!", "Warning", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel) 
                    return;
            }
            for (int x = rect.X; x < rect.X + rect.Width; x++)
            {
                for (int y = rect.Y; y < (rect.Y + rect.Height); y++)
                {
                    pixel = picture.GetPixel(x, y);
                    newRed = (int)Math.Round(pixel.R * 2.0, 0);
                    if (newRed > 255) 
                        newRed = 255;
                    newGreen = (int)Math.Round(pixel.G * 2.0, 0);
                    if (newGreen > 255) 
                        newGreen = 255;
                    newBlue = (int)Math.Round(pixel.B * 2.0, 0);
                    if (newBlue > 255) 
                        newBlue = 255;
                    picture.SetPixel(x, y, Color.FromArgb((byte)newRed, (byte)newGreen, (byte)newBlue));
                }
            }
            this.pictureBox1.Image = picture;
        }

    }
}
