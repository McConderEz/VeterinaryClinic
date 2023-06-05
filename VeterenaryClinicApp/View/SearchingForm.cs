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
using VeterenaryClinicApp.Model;

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
            string sql;
            List<string> columnName = new List<string>();
            if (tableName != "System.Data.DataRowView" && !string.IsNullOrWhiteSpace(tableName))
            {
                string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (label5.Text == "Ветеринарные клиники")
                    {
                        sql = "SELECT [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]," +
            "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Номер регистрационного пункта]," +
            "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Год открытия]," +
            "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Адрес пункта]," +
            "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта]," +
            "[Veterinary Clinic].[dbo].[Районы].[Район города]," +
            "[Veterinary Clinic].[dbo].[Тип собственности].[Тип собственности]," +
            "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Телефон] FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники]" +
        "INNER JOIN [Veterinary Clinic].[dbo].[Тип собственности] ON ([Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код типа собственности]) = [Veterinary Clinic].[dbo].[Тип собственности].[Код типа собственности]" +
        $"INNER JOIN [Veterinary Clinic].[dbo].[Районы] ON ([Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код район города]) = [Veterinary Clinic].[dbo].[Районы].[Код района]";
                    }
                    else if (label5.Text == "Сотрудники")
                    {
                        sql = "SELECT [Veterinary Clinic].[dbo].[Сотрудники].[Код сотрудника]," +
            "[Veterinary Clinic].[dbo].[Сотрудники].[Имя]," +
            "[Veterinary Clinic].[dbo].[Сотрудники].[Фамилия]," +
            "[Veterinary Clinic].[dbo].[Сотрудники].[Отчество]," +
            "[Veterinary Clinic].[dbo].[Сотрудники].[Дата рождения]," +
            "[Veterinary Clinic].[dbo].[Должности].[Должность]," +
            "[Veterinary Clinic].[dbo].[Сотрудники].[Стаж]," +
            "[Veterinary Clinic].[dbo].[Сотрудники].[Оклад]," +
            "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Номер регистрационного пункта]," +
            "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта] FROM [Veterinary Clinic].[dbo].[Сотрудники]" +
            "INNER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники] ON ([Veterinary Clinic].[dbo].[Сотрудники].[Код ветеринарной клиники]) = [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]" +
            $"INNER JOIN [Veterinary Clinic].[dbo].[Должности] ON ([Veterinary Clinic].[dbo].[Сотрудники].[Код должности]) = [Veterinary Clinic].[dbo].[Должности].[Код должности]";
                    }
                    else if (label5.Text == "Животные")
                    {
                        sql = "SELECT [Veterinary Clinic].[dbo].[Животные].[Код животного]," +
            "[Veterinary Clinic].[dbo].[Животные].[Кличка Животного]," +
            "[Veterinary Clinic].[dbo].[Животные].[Возраст Животного]," +
            "[Veterinary Clinic].[dbo].[Животные].[Условия содержания животного]," +
            "[Veterinary Clinic].[dbo].[Владельцы].[Имя]," +
            "[Veterinary Clinic].[dbo].[Владельцы].[Фамилия]," +
            "[Veterinary Clinic].[dbo].[Владельцы].[Отчество]," +
            "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного] FROM [Veterinary Clinic].[dbo].[Животные]" +
            "INNER JOIN [Veterinary Clinic].[dbo].[Владельцы] ON ([Veterinary Clinic].[dbo].[Животные].[Код владельца]) = [Veterinary Clinic].[dbo].[Владельцы].[Код владельца] " +
            $"INNER JOIN [Veterinary Clinic].[dbo].[Виды животных] ON ([Veterinary Clinic].[dbo].[Животные].[Код вида животного]) = [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного]";
                    }
                    else if (label5.Text == "Процедуры")
                    {
                        sql = "SELECT [Veterinary Clinic].[dbo].[Процедуры].[Код процедуры]," +
            "[Veterinary Clinic].[dbo].[Процедуры].[Дата оказания помощи животному]," +
            "[Veterinary Clinic].[dbo].[Процедуры].[Цена процедуры]," +
            "[Veterinary Clinic].[dbo].[Процедуры].[Скидка на эту процедуру]," +
            "[Veterinary Clinic].[dbo].[Процедуры].[Цена материала по этой процедуре]," +
            "[Veterinary Clinic].[dbo].[Сотрудники].[Имя]," +
            "[Veterinary Clinic].[dbo].[Сотрудники].[Фамилия]," +
            "[Veterinary Clinic].[dbo].[Сотрудники].[Отчество]," +
            "[Veterinary Clinic].[dbo].[Животные].[Кличка животного]," +
            "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного]," +
            "[Veterinary Clinic].[dbo].[Виды процедуры].[Вид процедуры] FROM [Veterinary Clinic].[dbo].[Процедуры]" +
            "INNER JOIN [Veterinary Clinic].[dbo].[Сотрудники] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код сотрудника]) = [Veterinary Clinic].[dbo].[Сотрудники].[Код сотрудника]" +
            "INNER JOIN [Veterinary Clinic].[dbo].[Животные] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код животного]) = [Veterinary Clinic].[dbo].[Животные].[Код животного] " +
            "INNER JOIN [Veterinary Clinic].[dbo].[Виды животных] ON ([Veterinary Clinic].[dbo].[Животные].[Код вида животного]) = [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного] " +
            $"INNER JOIN [Veterinary Clinic].[dbo].[Виды процедуры] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код вида процедуры]) = [Veterinary Clinic].[dbo].[Виды процедуры].[Код вида процедуры]";
                    }
                    else if (label5.Text == "Виды животных")
                    {
                        sql = "SELECT [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного]," +
            "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного]," +
            "[Veterinary Clinic].[dbo].[Классы животных].[Класс животного] FROM [Veterinary Clinic].[dbo].[Виды животных]" +
            $"INNER JOIN [Veterinary Clinic].[dbo].[Классы животных] ON ([Veterinary Clinic].[dbo].[Виды животных].[Код класса животного]) = [Veterinary Clinic].[dbo].[Классы животных].[Код класса животного]";
                    }
                    else if (label5.Text == "Лицензии")
                    {
                        sql = "SELECT [Veterinary Clinic].[dbo].[Лицензии].[Код лицензии]," +
            "[Veterinary Clinic].[dbo].[Лицензии].[Лицензия №]," +
            "[Veterinary Clinic].[dbo].[Лицензии].[Срок окончания лицензии]," +
            "[Veterinary Clinic].[dbo].[Лицензии].[Фото лицензии]," +
            "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта] FROM [Veterinary Clinic].[dbo].[Лицензии]" +
            $"INNER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники] ON ([Veterinary Clinic].[dbo].[Лицензии].[Код ветеринарной клинки]) = [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]";
                    }
                    else
                    {
                        sql = $"SELECT * FROM [{label5.Text}]";
                    }

                    var command = new SqlCommand(sql, connection);
                    using (var reader = command.ExecuteReader())
                    {
                        var schemaTable = reader.GetSchemaTable();
                        foreach (DataRow row in schemaTable.Rows)
                        {
                            columnName.Add(row["ColumnName"].ToString());
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
                        if (comboBox2.Text == "Ветеринарные клиники")
                        {
                            sql = "SELECT [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Номер регистрационного пункта]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Год открытия]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Адрес пункта]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта]," +
                "[Veterinary Clinic].[dbo].[Районы].[Район города]," +
                "[Veterinary Clinic].[dbo].[Тип собственности].[Тип собственности]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Телефон] FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники]" +
            "INNER JOIN [Veterinary Clinic].[dbo].[Тип собственности] ON ([Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код типа собственности]) = [Veterinary Clinic].[dbo].[Тип собственности].[Код типа собственности]" +
            $"INNER JOIN [Veterinary Clinic].[dbo].[Районы] ON ([Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код район города]) = [Veterinary Clinic].[dbo].[Районы].[Код района] WHERE [{label6.Text}] {label9.Text} {intValue}";
                        }
                        else if(comboBox2.Text == "Сотрудники")
                        {
                            sql = "SELECT [Veterinary Clinic].[dbo].[Сотрудники].[Код сотрудника]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Имя]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Фамилия]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Отчество]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Дата рождения]," +
                "[Veterinary Clinic].[dbo].[Должности].[Должность]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Стаж]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Оклад]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Номер регистрационного пункта]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта] FROM [Veterinary Clinic].[dbo].[Сотрудники]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники] ON ([Veterinary Clinic].[dbo].[Сотрудники].[Код ветеринарной клиники]) = [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]" +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Должности] ON ([Veterinary Clinic].[dbo].[Сотрудники].[Код должности]) = [Veterinary Clinic].[dbo].[Должности].[Код должности]  WHERE [{label6.Text}] {label9.Text} {intValue}";
                        }
                        else if(comboBox2.Text == "Животные")
                        {
                            sql = "SELECT [Veterinary Clinic].[dbo].[Животные].[Код животного]," +
                "[Veterinary Clinic].[dbo].[Животные].[Кличка Животного]," +
                "[Veterinary Clinic].[dbo].[Животные].[Возраст Животного]," +
                "[Veterinary Clinic].[dbo].[Животные].[Условия содержания животного]," +
                "[Veterinary Clinic].[dbo].[Владельцы].[Имя]," +
                "[Veterinary Clinic].[dbo].[Владельцы].[Фамилия]," +
                "[Veterinary Clinic].[dbo].[Владельцы].[Отчество]," +
                "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного] FROM [Veterinary Clinic].[dbo].[Животные]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Владельцы] ON ([Veterinary Clinic].[dbo].[Животные].[Код владельца]) = [Veterinary Clinic].[dbo].[Владельцы].[Код владельца] " +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Виды животных] ON ([Veterinary Clinic].[dbo].[Животные].[Код вида животного]) = [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного] WHERE [{label6.Text}] {label9.Text} {intValue}";
                        }
                        else if(comboBox2.Text == "Процедуры")
                        {
                            sql = "SELECT [Veterinary Clinic].[dbo].[Процедуры].[Код процедуры]," +
                "[Veterinary Clinic].[dbo].[Процедуры].[Дата оказания помощи животному]," +
                "[Veterinary Clinic].[dbo].[Процедуры].[Цена процедуры]," +
                "[Veterinary Clinic].[dbo].[Процедуры].[Скидка на эту процедуру]," +
                "[Veterinary Clinic].[dbo].[Процедуры].[Цена материала по этой процедуре]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Имя]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Фамилия]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Отчество]," +
                "[Veterinary Clinic].[dbo].[Животные].[Кличка животного]," +
                "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного]," +
                "[Veterinary Clinic].[dbo].[Виды процедуры].[Вид процедуры] FROM [Veterinary Clinic].[dbo].[Процедуры]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Сотрудники] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код сотрудника]) = [Veterinary Clinic].[dbo].[Сотрудники].[Код сотрудника]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Животные] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код животного]) = [Veterinary Clinic].[dbo].[Животные].[Код животного] " +
                "INNER JOIN [Veterinary Clinic].[dbo].[Виды животных] ON ([Veterinary Clinic].[dbo].[Животные].[Код вида животного]) = [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного] " +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Виды процедуры] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код вида процедуры]) = [Veterinary Clinic].[dbo].[Виды процедуры].[Код вида процедуры] WHERE [{label6.Text}] {label9.Text} {intValue}";
                        }
                        else if(comboBox2.Text == "Виды животных")
                        {
                            sql = "SELECT [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного]," +
                "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного]," +
                "[Veterinary Clinic].[dbo].[Классы животных].[Класс животного] FROM [Veterinary Clinic].[dbo].[Виды животных]" +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Классы животных] ON ([Veterinary Clinic].[dbo].[Виды животных].[Код класса животного]) = [Veterinary Clinic].[dbo].[Классы животных].[Код класса животного] WHERE [{label6.Text}] {label9.Text} {intValue}";
                        }
                        else if(comboBox2.Text == "Лицензии")
                        {
                            sql = "SELECT [Veterinary Clinic].[dbo].[Лицензии].[Код лицензии]," +
                "[Veterinary Clinic].[dbo].[Лицензии].[Лицензия №]," +
                "[Veterinary Clinic].[dbo].[Лицензии].[Срок окончания лицензии]," +
                "[Veterinary Clinic].[dbo].[Лицензии].[Фото лицензии]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта] FROM [Veterinary Clinic].[dbo].[Лицензии]" +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники] ON ([Veterinary Clinic].[dbo].[Лицензии].[Код ветеринарной клинки]) = [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки] WHERE [{label6.Text}] {label9.Text} {intValue}";
                        }
                        else 
                        {
                            sql = $"SELECT * FROM [Veterinary Clinic].[dbo].[{label5.Text}] WHERE [{label6.Text}] {label9.Text} {intValue}";
                        }
                    }
                    else if(decimal.TryParse(valueBox.Text, out decValue))
                    {
                        if (comboBox2.Text == "Ветеринарные клиники")
                        {
                            sql = "SELECT [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Номер регистрационного пункта]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Год открытия]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Адрес пункта]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта]," +
                "[Veterinary Clinic].[dbo].[Районы].[Район города]," +
                "[Veterinary Clinic].[dbo].[Тип собственности].[Тип собственности]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Телефон] FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники]" +
            "INNER JOIN [Veterinary Clinic].[dbo].[Тип собственности] ON ([Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код типа собственности]) = [Veterinary Clinic].[dbo].[Тип собственности].[Код типа собственности]" +
            $"INNER JOIN [Veterinary Clinic].[dbo].[Районы] ON ([Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код район города]) = [Veterinary Clinic].[dbo].[Районы].[Код района] WHERE [{label6.Text}] {label9.Text} {decValue}";
                        }
                        else if (comboBox2.Text == "Сотрудники")
                        {
                            sql = "SELECT [Veterinary Clinic].[dbo].[Сотрудники].[Код сотрудника]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Имя]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Фамилия]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Отчество]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Дата рождения]," +
                "[Veterinary Clinic].[dbo].[Должности].[Должность]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Стаж]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Оклад]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта] FROM [Veterinary Clinic].[dbo].[Сотрудники]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники] ON ([Veterinary Clinic].[dbo].[Сотрудники].[Код ветеринарной клиники]) = [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]" +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Должности] ON ([Veterinary Clinic].[dbo].[Сотрудники].[Код должности]) = [Veterinary Clinic].[dbo].[Должности].[Код должности]  WHERE [{label6.Text}] {label9.Text} {decValue}";
                        }
                        else if (comboBox2.Text == "Животные")
                        {
                            sql = "SELECT [Veterinary Clinic].[dbo].[Животные].[Код животного]," +
                "[Veterinary Clinic].[dbo].[Животные].[Кличка Животного]," +
                "[Veterinary Clinic].[dbo].[Животные].[Возраст Животного]," +
                "[Veterinary Clinic].[dbo].[Животные].[Условия содержания животного]," +
                "[Veterinary Clinic].[dbo].[Владельцы].[Фамилия]," +
                "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного] FROM [Veterinary Clinic].[dbo].[Животные]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Владельцы] ON ([Veterinary Clinic].[dbo].[Животные].[Код владельца]) = [Veterinary Clinic].[dbo].[Владельцы].[Код владельца] " +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Виды животных] ON ([Veterinary Clinic].[dbo].[Животные].[Код вида животного]) = [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного] WHERE [{label6.Text}] {label9.Text} {decValue}";
                        }
                        else if (comboBox2.Text == "Процедуры")
                        {
                            sql = "SELECT [Veterinary Clinic].[dbo].[Процедуры].[Код процедуры]," +
                "[Veterinary Clinic].[dbo].[Процедуры].[Дата оказания помощи животному]," +
                "[Veterinary Clinic].[dbo].[Процедуры].[Цена процедуры]," +
                "[Veterinary Clinic].[dbo].[Процедуры].[Скидка на эту процедуру]," +
                "[Veterinary Clinic].[dbo].[Процедуры].[Цена материала по этой процедуре]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Фамилия]," +
                "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного]," +
                "[Veterinary Clinic].[dbo].[Виды процедуры].[Вид процедуры] FROM [Veterinary Clinic].[dbo].[Процедуры]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Сотрудники] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код сотрудника]) = [Veterinary Clinic].[dbo].[Сотрудники].[Код сотрудника]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Животные] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код животного]) = [Veterinary Clinic].[dbo].[Животные].[Код животного] " +
                "INNER JOIN [Veterinary Clinic].[dbo].[Виды животных] ON ([Veterinary Clinic].[dbo].[Животные].[Код вида животного]) = [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного] " +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Виды процедуры] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код вида процедуры]) = [Veterinary Clinic].[dbo].[Виды процедуры].[Код вида процедуры] WHERE [{label6.Text}] {label9.Text} {decValue}";
                        }
                        else if (comboBox2.Text == "Виды животных")
                        {
                            sql = "SELECT [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного]," +
                "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного]," +
                "[Veterinary Clinic].[dbo].[Классы животных].[Класс животного] FROM [Veterinary Clinic].[dbo].[Виды животных]" +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Классы животных] ON ([Veterinary Clinic].[dbo].[Виды животных].[Код класса животного]) = [Veterinary Clinic].[dbo].[Классы животных].[Код класса животного] WHERE [{label6.Text}] {label9.Text} {decValue}";
                        }
                        else if (comboBox2.Text == "Лицензии")
                        {
                            sql = "SELECT [Veterinary Clinic].[dbo].[Лицензии].[Код лицензии]," +
                "[Veterinary Clinic].[dbo].[Лицензии].[Лицензия №]," +
                "[Veterinary Clinic].[dbo].[Лицензии].[Срок окончания лицензии]," +
                "[Veterinary Clinic].[dbo].[Лицензии].[Фото лицензии]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта] FROM [Veterinary Clinic].[dbo].[Лицензии]" +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники] ON ([Veterinary Clinic].[dbo].[Лицензии].[Код ветеринарной клинки]) = [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки] WHERE [{label6.Text}] {label9.Text} {decValue}";
                        }
                        else
                        {
                            sql = $"SELECT * FROM [Veterinary Clinic].[dbo].[{label5.Text}] WHERE [{label6.Text}] {label9.Text} {decValue}";
                        }
                    }
                    else if(DateTime.TryParse(valueBox.Text, out dateValue))
                    {
                        string date = $"{dateValue.Month}-{dateValue.Day}-{dateValue.Year}";
                        if (comboBox2.Text == "Ветеринарные клиники")
                        {
                            sql = "SELECT [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Номер регистрационного пункта]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Год открытия]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Адрес пункта]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта]," +
                "[Veterinary Clinic].[dbo].[Районы].[Район города]," +
                "[Veterinary Clinic].[dbo].[Тип собственности].[Тип собственности]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Телефон] FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники]" +
            "INNER JOIN [Veterinary Clinic].[dbo].[Тип собственности] ON ([Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код типа собственности]) = [Veterinary Clinic].[dbo].[Тип собственности].[Код типа собственности]" +
            $"INNER JOIN [Veterinary Clinic].[dbo].[Районы] ON ([Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код район города]) = [Veterinary Clinic].[dbo].[Районы].[Код района] WHERE [{label6.Text}] {label9.Text} {date}";
                        }
                        else if (comboBox2.Text == "Сотрудники")
                        {
                            sql = "SELECT [Veterinary Clinic].[dbo].[Сотрудники].[Код сотрудника]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Имя]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Фамилия]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Отчество]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Дата рождения]," +
                "[Veterinary Clinic].[dbo].[Должности].[Должность]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Стаж]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Оклад]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта] FROM [Veterinary Clinic].[dbo].[Сотрудники]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники] ON ([Veterinary Clinic].[dbo].[Сотрудники].[Код ветеринарной клиники]) = [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]" +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Должности] ON ([Veterinary Clinic].[dbo].[Сотрудники].[Код должности]) = [Veterinary Clinic].[dbo].[Должности].[Код должности]  WHERE [{label6.Text}] {label9.Text} {date}";
                        }
                        else if (comboBox2.Text == "Животные")
                        {
                            sql = "SELECT [Veterinary Clinic].[dbo].[Животные].[Код животного]," +
                "[Veterinary Clinic].[dbo].[Животные].[Кличка Животного]," +
                "[Veterinary Clinic].[dbo].[Животные].[Возраст Животного]," +
                "[Veterinary Clinic].[dbo].[Животные].[Условия содержания животного]," +
                "[Veterinary Clinic].[dbo].[Владельцы].[Фамилия]," +
                "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного] FROM [Veterinary Clinic].[dbo].[Животные]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Владельцы] ON ([Veterinary Clinic].[dbo].[Животные].[Код владельца]) = [Veterinary Clinic].[dbo].[Владельцы].[Код владельца] " +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Виды животных] ON ([Veterinary Clinic].[dbo].[Животные].[Код вида животного]) = [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного] WHERE [{label6.Text}] {label9.Text} {date}";
                        }
                        else if (comboBox2.Text == "Процедуры")
                        {
                            sql = "SELECT [Veterinary Clinic].[dbo].[Процедуры].[Код процедуры]," +
                "[Veterinary Clinic].[dbo].[Процедуры].[Дата оказания помощи животному]," +
                "[Veterinary Clinic].[dbo].[Процедуры].[Цена процедуры]," +
                "[Veterinary Clinic].[dbo].[Процедуры].[Скидка на эту процедуру]," +
                "[Veterinary Clinic].[dbo].[Процедуры].[Цена материала по этой процедуре]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Фамилия]," +
                "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного]," +
                "[Veterinary Clinic].[dbo].[Виды процедуры].[Вид процедуры] FROM [Veterinary Clinic].[dbo].[Процедуры]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Сотрудники] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код сотрудника]) = [Veterinary Clinic].[dbo].[Сотрудники].[Код сотрудника]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Животные] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код животного]) = [Veterinary Clinic].[dbo].[Животные].[Код животного] " +
                "INNER JOIN [Veterinary Clinic].[dbo].[Виды животных] ON ([Veterinary Clinic].[dbo].[Животные].[Код вида животного]) = [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного] " +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Виды процедуры] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код вида процедуры]) = [Veterinary Clinic].[dbo].[Виды процедуры].[Код вида процедуры] WHERE [{label6.Text}] {label9.Text} {date}";
                        }
                        else if (comboBox2.Text == "Виды животных")
                        {
                            sql = "SELECT [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного]," +
                "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного]," +
                "[Veterinary Clinic].[dbo].[Классы животных].[Класс животного] FROM [Veterinary Clinic].[dbo].[Виды животных]" +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Классы животных] ON ([Veterinary Clinic].[dbo].[Виды животных].[Код класса животного]) = [Veterinary Clinic].[dbo].[Классы животных].[Код класса животного] WHERE [{label6.Text}] {label9.Text} {date}";
                        }
                        else if (comboBox2.Text == "Лицензии")
                        {
                            sql = "SELECT [Veterinary Clinic].[dbo].[Лицензии].[Код лицензии]," +
                "[Veterinary Clinic].[dbo].[Лицензии].[Лицензия №]," +
                "[Veterinary Clinic].[dbo].[Лицензии].[Срок окончания лицензии]," +
                "[Veterinary Clinic].[dbo].[Лицензии].[Фото лицензии]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта] FROM [Veterinary Clinic].[dbo].[Лицензии]" +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники] ON ([Veterinary Clinic].[dbo].[Лицензии].[Код ветеринарной клинки]) = [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки] WHERE [{label6.Text}] {label9.Text} {date}";
                        }
                        else
                        {
                            sql = $"SELECT * FROM [Veterinary Clinic].[dbo].[{label5.Text}] WHERE CONVERT(date,[{label6.Text}]) {label9.Text} '{date}'";
                        }
                    }
                    else
                    {
                        if (comboBox2.Text == "Ветеринарные клиники")
                        {
                            if (label6.Text == "Тип собственности")
                                label5.Text = "Тип собственности";
                            else if (label6.Text == "Район города")
                                label5.Text = "Районы";
                            sql = "SELECT [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Номер регистрационного пункта]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Год открытия]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Адрес пункта]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта]," +
                "[Veterinary Clinic].[dbo].[Районы].[Район города]," +
                "[Veterinary Clinic].[dbo].[Тип собственности].[Тип собственности]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Телефон] FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники]" +
            "INNER JOIN [Veterinary Clinic].[dbo].[Тип собственности] ON ([Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код типа собственности]) = [Veterinary Clinic].[dbo].[Тип собственности].[Код типа собственности]" +
            $"INNER JOIN [Veterinary Clinic].[dbo].[Районы] ON ([Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код район города]) = [Veterinary Clinic].[dbo].[Районы].[Код района] WHERE [Veterinary Clinic].[dbo].[{label5.Text}].[{label6.Text}] = N'{valueBox.Text}'";
                        }
                        else if (comboBox2.Text == "Сотрудники")
                        {
                            if (label6.Text == "Должность")
                                label5.Text = "Должности";
                            else if (label6.Text == "Номер регистрационного пункта" || label6.Text == "Название пункта")
                                label5.Text = "Ветеринарные клиники";
                            sql = "SELECT [Veterinary Clinic].[dbo].[Сотрудники].[Код сотрудника]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Имя]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Фамилия]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Отчество]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Дата рождения]," +
                "[Veterinary Clinic].[dbo].[Должности].[Должность]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Стаж]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Оклад]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Номер регистрационного пункта]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта] FROM [Veterinary Clinic].[dbo].[Сотрудники]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники] ON ([Veterinary Clinic].[dbo].[Сотрудники].[Код ветеринарной клиники]) = [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]" +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Должности] ON ([Veterinary Clinic].[dbo].[Сотрудники].[Код должности]) = [Veterinary Clinic].[dbo].[Должности].[Код должности]  WHERE [Veterinary Clinic].[dbo].[{label5.Text}].[{label6.Text}] = N'{valueBox.Text}'";
                        }
                        else if (comboBox2.Text == "Животные")
                        {
                            if (label6.Text == "Имя" || label6.Text == "Фамилия" || label6.Text == "Отчество")
                                label5.Text = "Владельцы";
                            else if (label6.Text == "Вид животного")
                                label5.Text = "Виды животных";
                            sql = "SELECT [Veterinary Clinic].[dbo].[Животные].[Код животного]," +
                "[Veterinary Clinic].[dbo].[Животные].[Кличка Животного]," +
                "[Veterinary Clinic].[dbo].[Животные].[Возраст Животного]," +
                "[Veterinary Clinic].[dbo].[Животные].[Условия содержания животного]," +
                "[Veterinary Clinic].[dbo].[Владельцы].[Имя]," +
                "[Veterinary Clinic].[dbo].[Владельцы].[Фамилия]," +
                "[Veterinary Clinic].[dbo].[Владельцы].[Отчество]," +
                "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного] FROM [Veterinary Clinic].[dbo].[Животные]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Владельцы] ON ([Veterinary Clinic].[dbo].[Животные].[Код владельца]) = [Veterinary Clinic].[dbo].[Владельцы].[Код владельца] " +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Виды животных] ON ([Veterinary Clinic].[dbo].[Животные].[Код вида животного]) = [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного] WHERE [Veterinary Clinic].[dbo].[{label5.Text}].[{label6.Text}] = N'{valueBox.Text}'";
                        }
                        else if (comboBox2.Text == "Процедуры")
                        {
                            if (label6.Text == "Имя" || label6.Text == "Фамилия" || label6.Text == "Отчество")
                                label5.Text = "Сотрудники";
                            else if (label6.Text == "Кличка животного")
                                label5.Text = "Животные";
                            else if (label6.Text == "Вид животного")
                                label5.Text = "Виды животных";
                            else if (label6.Text == "Вид процедуры")
                                label5.Text = "Виды процедуры";
                            sql = "SELECT [Veterinary Clinic].[dbo].[Процедуры].[Код процедуры]," +
                "[Veterinary Clinic].[dbo].[Процедуры].[Дата оказания помощи животному]," +
                "[Veterinary Clinic].[dbo].[Процедуры].[Цена процедуры]," +
                "[Veterinary Clinic].[dbo].[Процедуры].[Скидка на эту процедуру]," +
                "[Veterinary Clinic].[dbo].[Процедуры].[Цена материала по этой процедуре]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Имя]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Фамилия]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Отчество]," +
                "[Veterinary Clinic].[dbo].[Животные].[Кличка животного]," +
                "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного]," +
                "[Veterinary Clinic].[dbo].[Виды процедуры].[Вид процедуры] FROM [Veterinary Clinic].[dbo].[Процедуры]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Сотрудники] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код сотрудника]) = [Veterinary Clinic].[dbo].[Сотрудники].[Код сотрудника]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Животные] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код животного]) = [Veterinary Clinic].[dbo].[Животные].[Код животного] " +
                "INNER JOIN [Veterinary Clinic].[dbo].[Виды животных] ON ([Veterinary Clinic].[dbo].[Животные].[Код вида животного]) = [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного] " +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Виды процедуры] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код вида процедуры]) = [Veterinary Clinic].[dbo].[Виды процедуры].[Код вида процедуры] WHERE [Veterinary Clinic].[dbo].[{label5.Text}].[{label6.Text}] = N'{valueBox.Text}'";
                        }
                        else if (comboBox2.Text == "Виды животных")
                        {
                            if (label6.Text == "Класс животного")
                                label5.Text = "Классы животных";
                                
                            sql = "SELECT [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного]," +
                "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного]," +
                "[Veterinary Clinic].[dbo].[Классы животных].[Класс животного] FROM [Veterinary Clinic].[dbo].[Виды животных]" +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Классы животных] ON ([Veterinary Clinic].[dbo].[Виды животных].[Код класса животного]) = [Veterinary Clinic].[dbo].[Классы животных].[Код класса животного] WHERE [Veterinary Clinic].[dbo].[{label5.Text}].[{label6.Text}] = N'{valueBox.Text}'";
                        }
                        else if (comboBox2.Text == "Лицензии")
                        {
                            if (label6.Text == "Название пункта")
                                label5.Text = "Ветеринарные клиники";
                            sql = "SELECT [Veterinary Clinic].[dbo].[Лицензии].[Код лицензии]," +
                "[Veterinary Clinic].[dbo].[Лицензии].[Лицензия №]," +
                "[Veterinary Clinic].[dbo].[Лицензии].[Срок окончания лицензии]," +
                "[Veterinary Clinic].[dbo].[Лицензии].[Фото лицензии]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта] FROM [Veterinary Clinic].[dbo].[Лицензии]" +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники] ON ([Veterinary Clinic].[dbo].[Лицензии].[Код ветеринарной клинки]) = [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки] WHERE [Veterinary Clinic].[dbo].[{label5.Text}].[{label6.Text}] = N'{valueBox.Text}'";
                        }
                        else
                        {
                            sql = $"SELECT * FROM [Veterinary Clinic].[dbo].[{label5.Text}] WHERE [Veterinary Clinic].[dbo].[{label5.Text}].[{label6.Text}] = N'{valueBox.Text}'";
                        }
                    }
                    SqlCommand command = new SqlCommand(sql, myConnection);
                    Console.WriteLine(command);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    var searchBox = new DataTable();
                    adapter.Fill(searchBox);
                    dataGridView1.DataSource = searchBox;
                }
            }
            catch (Exception ex)
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
