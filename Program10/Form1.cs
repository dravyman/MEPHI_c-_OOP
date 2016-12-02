using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.BackColor = Color.White;

            Button button1 = new Button();
            button1.Text = "Будем рисовать!";
            button1.Location = new Point(110, 10);
            button1.Size = new Size(70, 40);
            button1.BackColor = Color.LightGray;
            button1.Click += new System.EventHandler(button1_Click);
            this.Controls.Add(button1);
        }

        void button1_Click(object o, System.EventArgs e)
        {
            DrawSomeShapes();
        }

        void DrawSomeShapes()
        {
            Graphics g = this.CreateGraphics();

            Pen redPen = new Pen(Color.Red, 3);

            g.DrawLine(redPen, 140, 170, 140, 230);
            g.DrawRectangle(redPen, 50, 60, 50, 60);
            g.DrawEllipse(redPen, 150, 100, 100, 60);

            g.Dispose();
        }
    }
}
