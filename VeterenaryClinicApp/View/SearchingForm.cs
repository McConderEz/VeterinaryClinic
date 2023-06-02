using Bunifu.UI.WinForms.Helpers.Transitions;
using Microsoft.Build.Framework.XamlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;

namespace VeterenaryClinicApp
{
    public partial class SearchingForm : Form
    {
        DataTable table;
        public SearchingForm()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        //private void pictureBox2_MouseLeave(object sender, EventArgs e)
        //{
        //    pictureBox2.Image = new Bitmap(@"C:\Users\fikra\source\repos\VeterenaryClinicApp\VeterenaryClinicApp\Resources\211817_search_strong_icon.png");
        //}

        //private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        //{
        //    pictureBox2.Image = new Bitmap(@"C:\Users\fikra\source\repos\VeterenaryClinicApp\VeterenaryClinicApp\Resources\211817_search_strong_icon (1).png");
        //}

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                    "Вы можете выбрать поле и ввести id для поиска.\n" +
                    "Вы можете ввести свой запрос для поиска.\n",                  
                    "FAQ"
                    );
        }

        //private void pictureBox3_MouseLeave(object sender, EventArgs e)
        //{
        //    pictureBox3.Image = new Bitmap(@"C:\Users\fikra\source\repos\VeterenaryClinicApp\VeterenaryClinicApp\Resources\9111264_question_circle_icon.png");
        //}

        //private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        //{
        //    pictureBox3.Image = new Bitmap(@"C:\Users\fikra\source\repos\VeterenaryClinicApp\VeterenaryClinicApp\Resources\9111264_question_circle_icon (1).png");
        //}

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        //private void textBox1_Click(object sender, EventArgs e)
        //{
        //    textBox1.Clear();
        //}

        private void SearchingForm_Load(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            //string sql = "SELECT table_name FROM information_schema.tables WHERE table_type = 'BASE TABLE' AND table_catalog = 'Veterinary Clinic'";
            //SqlCommand command = new SqlCommand(sql, myConnection);
            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            //DataTable table = new DataTable();
            //adapter.Fill(table);
            //comboBox2.DataSource = table;
            //comboBox2.DisplayMember = "table_name";
            //comboBox2.ValueMember = "table_name";

            string sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            comboBox2.DataSource = table;
            comboBox2.DisplayMember = "table_name";

        }





        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tableName = comboBox2.GetItemText(comboBox2.SelectedItem);
            label5.Text = tableName;
            List<string> columnName = new List<string>();
            if (tableName != "System.Data.DataRowView" && !string.IsNullOrWhiteSpace(tableName))
            {
                string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var command = new SqlCommand($"SELECT * FROM [{tableName}]", connection);
                    using (var reader = command.ExecuteReader())
                    {
                        var schemaTable = reader.GetSchemaTable();
                        foreach (DataRow row in schemaTable.Rows)
                        {
                            columnName.Add(row["ColumnName"].ToString());
                            //Console.WriteLine(columnName);
                        }
                    }

                    comboBox1.DataSource = columnName;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                if (valueBox != null)
                {
                    string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
                    SqlConnection myConnection = new SqlConnection(connectionString);
                    myConnection.Open();
                    string sql;
                    int intValue;
                    decimal decValue;
                    DateTime dateValue;

                    if(int.TryParse(valueBox.Text, out intValue))
                    {
                        sql = $"SELECT * FROM [Veterinary Clinic].[dbo].[{label5.Text}] WHERE [{label6.Text}] {label9.Text} {intValue}";
                    }
                    else if(decimal.TryParse(valueBox.Text, out decValue))
                    {
                        sql = $"SELECT * FROM [Veterinary Clinic].[dbo].[{label5.Text}] WHERE [{label6.Text}] {label9.Text} {decValue}";
                    }
                    else if(DateTime.TryParse(valueBox.Text, out dateValue))
                    {
                        string date = $"{dateValue.Month}-{dateValue.Day}-{dateValue.Year}";
                        sql = $"SELECT * FROM [Veterinary Clinic].[dbo].[{label5.Text}] WHERE CONVERT(date,[{label6.Text}]) {label9.Text} '{date}'";
                    }
                    else
                    {
                        sql = $"SELECT * FROM [Veterinary Clinic].[dbo].[{label5.Text}] WHERE LEFT(CONVERT(VARCHAR(20),[{label6.Text}]),20) = '%{valueBox.Text}%'";
                    }                    
                    SqlCommand command = new SqlCommand(sql, myConnection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    var searchBox = new DataTable();
                    adapter.Fill(searchBox);
                    dataGridView1.DataSource = searchBox;
                }
             }catch(Exception ex)
                {
                MessageBox.Show("Вы ввели недопустимые данные!Попробуйте иначе.");
                }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tableName = comboBox1.GetItemText(comboBox1.SelectedItem);
            label6.Text = tableName;
        }

        private void operatorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tableName = operatorBox.GetItemText(operatorBox.SelectedItem);
            label9.Text = tableName;
        }
    }
}
