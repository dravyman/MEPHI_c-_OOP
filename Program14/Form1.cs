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

namespace Program14
{
    public partial class Form1 : Form
    {
        SqlDataAdapter dataAdapter;
        DataGridView dataGridView;

        public Form1()
        {
            InitializeComponent();
            this.Width = 450;
            this.Height = 400;

            this.Text = "Двустороннее связывание: база данных и элемент Grid.";

            Label labelCaption = new Label();
            labelCaption.Text = "Скилы!";
            labelCaption.Location = new Point(60, 10);
            labelCaption.Width = 200;
            labelCaption.Parent = this;

            // Добавляем элемент DataGridView на форму
            dataGridView = new DataGridView();
            dataGridView.Width = 350;
            dataGridView.Height = 250;
            dataGridView.Location = new Point(20, 50);
            dataGridView.AutoResizeColumns();
            this.Controls.Add(dataGridView);

            // Добавляем командную кнопку
            Button buttonSave = new Button();
            buttonSave.Location = new Point(100, 320);
            buttonSave.Width = 220;
            buttonSave.Text = "Сохранить изменения в базе данных!";
            buttonSave.Click +=
            new System.EventHandler(ButtonSave_Click);
            buttonSave.Parent = this;

            // Формируем запрос к базе данных –
            //запрашиваем информацию о планетах
            string sql = "SELECT * FROM Skill";
            string connectionString;

            DataTable dataTable = new DataTable();
            connectionString = "Data Source=DRAV-PC;Initial Catalog=HRR;User ID=drav-PC\\drav;Integrated Security=True";// + "Integrated Security = SSPI";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(sql, connection);

            dataAdapter = new SqlDataAdapter(sqlCommand);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(dataTable); 
            dataGridView.DataSource = dataTable;
            connection.Close();
        }

        void ButtonSave_Click(object sender, System.EventArgs args)
        {
            try
            {
                dataAdapter.Update((DataTable)dataGridView.DataSource);
                MessageBox.Show("Изменения в базе данных выполнены!", "Уведомление о результатах", MessageBoxButtons.OK);
            }
            catch(Exception)
            {
                MessageBox.Show("Изменения в базе данных выполнить не удалось!", "Уведомление о результатах", MessageBoxButtons.OK);
            }
        }
    }
}
