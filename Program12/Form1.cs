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

namespace Program12
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            this.Text = "Работа с базой данных. Чтение данных.";

            Label labelCaption = new Label();
            labelCaption.Text = "Планеты солнечной системы!";
            labelCaption.Location = new Point(30, 10);
            labelCaption.Width = 200;
            labelCaption.Parent = this;
            ListBox listPlanets = new ListBox();
            listPlanets.Location = new Point(30, 50);
            listPlanets.Width = 100;
            listPlanets.Parent = this;

            string sql = "SELECT * FROM Skill";
            string connectionString;

            connectionString = "Data Source=DRAV-PC;Initial Catalog=HRR;Integrated Security=true";// + "Integrated Security = SSPI";
            SqlConnection connection1 = new SqlConnection(connectionString);

            connection1.Open();
            SqlCommand command1 = new SqlCommand(sql, connection1);
            SqlDataReader dataReader1 = command1.ExecuteReader();

            while (dataReader1.Read())
            {
                listPlanets.Items.Add(dataReader1["Name"]);
            } 

            dataReader1.Close();
            connection1.Close();
        }
    }
}
