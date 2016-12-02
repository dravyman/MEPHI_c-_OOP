using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Program13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.Width = 450;
            this.Height = 400;

            this.Text = "Одностороннее связывание: база данных и элемент Grid.";

            Label labelCaption = new Label();
            labelCaption.Text = "Скиллы";
            labelCaption.Location = new Point(60, 10);
            labelCaption.Width = 200;
            labelCaption.Parent = this;

            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.Width = 350;
            dataGridView1.Height = 250;
            dataGridView1.Location = new Point(20, 50);
            dataGridView1.DataMember = "Table";
            dataGridView1.AutoResizeColumns();
            this.Controls.Add(dataGridView1);

            string sql = "SELECT * FROM Skill";
            string connectionString;

            DataSet dataSet1 = new DataSet();

            connectionString = "Data Source=DRAV-PC;Initial Catalog=HRR;User ID=drav-PC\\drav;Integrated Security=True";// + "Integrated Security = SSPI";
            SqlConnection connection1 = new SqlConnection(connectionString);

            connection1.Open();

            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter();

            sqlDataAdapter1.SelectCommand = new SqlCommand(sql, connection1);
            // Данные из адаптера поступают в DataSet
            sqlDataAdapter1.Fill(dataSet1);
            // Связываем данные с элементом DataGridView
            dataGridView1.DataSource = dataSet1;

            connection1.Close();
        }
    }
}
