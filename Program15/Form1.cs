using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace Program15
{
    public partial class Form1 : Form
    {

        ComboBox comboBox1;
        Button button1;
        ListBox listBox1;
        RichTextBox richTextBox1;
        XmlDocument xmlDoc;

        public Form1()
        {
            this.Text = "Работа с XML-документом";
            this.Size = new Size(400, 400);
            // Создаем объект XmlDocument, используя xml-файл
            xmlDoc = new XmlDocument();
            xmlDoc.Load("../../images/books.xml");
            // Создаем объект TextBox для вывода данных
            richTextBox1 = new RichTextBox();
            richTextBox1.Dock = DockStyle.Top;
            richTextBox1.AcceptsTab = true;
            richTextBox1.Height = 180;
            richTextBox1.ReadOnly = true;
            richTextBox1.BackColor = Color.Silver;

            richTextBox1.Text = xmlDoc.OuterXml;
            this.Controls.Add(richTextBox1);

            comboBox1 = new ComboBox();
            comboBox1.Location = new Point(0, 200);
            comboBox1.Width = 300;
            comboBox1.Items.Add("/Books");
            comboBox1.Items.Add("/Books/book");
            comboBox1.Items.Add("/Books/book[@year=\"2005\"]");
            comboBox1.Items.Add("/Books/book/author");
            comboBox1.Items.Add("/Books/book[@year=\"2005\"]/author");
            comboBox1.SelectedIndex = 0;
            this.Controls.Add(comboBox1);
            // Создаем командную кнопку для поиска и отображения
            // соответствующих элементов Xml-документа
            button1 = new Button();
            button1.Text = "Получить данные";
            button1.Location = new Point(100, 230);
            button1.Width = 120;
            button1.Click += new EventHandler(Button1_Click);
            this.Controls.Add(button1);

            listBox1 = new ListBox();
            listBox1.Dock = DockStyle.Bottom;
            listBox1.Location = new Point(10, 10);
            this.Controls.Add(listBox1);
        }

                // Обработчик события, срабатывающий при нажатии кнопки
        void Button1_Click(object sender, EventArgs e)
        {
            XmlNodeList xmlNodes;
            XmlNode xmlElement;
            string elementValue;
            try
            {
                xmlNodes = xmlDoc.SelectNodes(comboBox1.Text);  
                listBox1.Items.Clear();
                for (int i = 0; i < xmlNodes.Count; i++)
                {
                    xmlElement = xmlNodes[i];
                    if (xmlElement.HasChildNodes)
                    {
                        elementValue = xmlElement.FirstChild.Value.Trim();
                        listBox1.Items.Add(elementValue);
                    }
                }
            }
            catch (XPathException ex)
            {
                const string errorMessage = "Ошибка в задании выражения XPath!" +
                "\r\n" + "Соответствующие данные в документе не найдены!" +
                "\r\n" + "Попробуйте задать другое выражение!";
                MessageBox.Show(errorMessage +"\r\n" + ex.Message);
            }
        }
    }
}
