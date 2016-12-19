using System;
using System.Windows.Forms;
using System.Drawing;
class SimpleShapeMaker : Form
{
    int count = 0;
// Метод-конструктор нашего класса
public SimpleShapeMaker()
{
// Меняем цвет фона формы на белый
this.BackColor = Color.White;
// Добавляем на форму кнопку и привязываем ее к обработчику событий
Button button1 = new Button();
button1.Text = "Будем рисовать!";
button1.Location = new Point(110, 10);
button1.Size = new Size(70, 40);
button1.BackColor = Color.LightGray;
button1.Click += new System.EventHandler(button1_Click);
    this.Controls.Add(button1);


}
// Обработчик события, срабатывающий при нажатии кнопки
void button1_Click(object o, System.EventArgs e)
{
// Вызов метода
DrawSomeShapes();
}
// Метод для отрисовки на поверхности формы нескольких фигур
void DrawSomeShapes()
{
// Подготовка области рисования на форме
Graphics g = this.CreateGraphics();
// Подготавливаем перо, рисующее красную линию толщиной 3 пикселя
Pen redPen = new Pen(Color.Red, 3);
// С помощью пера рисуем прямую линию, прямоугольник и эллипс
g.DrawLine(redPen, 140, 170, 140, 230);
g.DrawRectangle(redPen, 50, 60, 50, 60);
g.DrawEllipse(redPen, 150, 100, 100, 60);
// Очистка
g.Dispose();
Button button2 = new Button();
button2.Text = "Удалить объект";
button2.Location = new Point(180, 210);
button2.Size = new Size(70, 40);
button2.BackColor = Color.LightGray;
button2.Click += new System.EventHandler(button2_Click);
this.Controls.Add(button2);
}
void button2_Click(object o, System.EventArgs e)
{
    // Вызов метода
    DelSomeShapes();
}
// Метод для отрисовки на поверхности формы нескольких фигур
void DelSomeShapes()
{
    // Подготовка области рисования на форме
    Graphics g = this.CreateGraphics();
    Pen whitePen = new Pen(Color.White, 3);
    if (count ==0) 
    {
    g.DrawLine(whitePen, 140, 170, 140, 230);
    }
    else if (count == 1)
    {
        g.DrawRectangle(whitePen, 50, 60, 50, 60);
    }
    else
    {
        g.DrawEllipse(whitePen, 150, 100, 100, 60);
    }
    count++;

}
static void Main()
{
// Создаем и запускаем форму
Application.Run(new SimpleShapeMaker());
}
}