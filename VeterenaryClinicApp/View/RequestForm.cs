using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterenaryClinicApp.Controller;

namespace VeterenaryClinicApp
{
    public partial class RequestForm : Form
    {
        public RequestForm()
        {
            InitializeComponent();
        }

        private void RequestForm_Load(object sender, EventArgs e)
        {
            posBox.Enabled = false;
            procedureTypeBox.Enabled = false;
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string sql = "SELECT [Должность] FROM [Должности]";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);
            posBox.DataSource = table;
            posBox.DisplayMember = "Должность";

            var table2 = new DataTable();
            sql = "SELECT [Вид процедуры] FROM [Виды процедуры]";
            command = new SqlCommand(sql, myConnection);
            adapter = new SqlDataAdapter(command);
            adapter.Fill(table2);
            procedureTypeBox.DataSource = table2;
            procedureTypeBox.DisplayMember = "Вид процедуры";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        //private void pictureBox2_MouseLeave(object sender, EventArgs e)
        //{
        //    pictureBox2.Image = new Bitmap(@"C:\Users\fikra\source\repos\VeterenaryClinicApp\VeterenaryClinicApp\Resources\511955_arrow_before_beginning_left_previous_icon.png");
        //}

        //private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        //{
        //    pictureBox2.Image = new Bitmap(@"C:\Users\fikra\source\repos\VeterenaryClinicApp\VeterenaryClinicApp\Resources\511955_arrow_before_beginning_left_previous_icon (1).png");
        //}

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
            
        //}

        //private void textBox1_Click(object sender, EventArgs e)
        //{
        //    textBox1.Clear();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "1-й запрос: Определить лучший ветеринарный пункт по каждому району и тройку лучших пунктов по городу в целом.\n" +
                "2-й запрос: Определить сотрудника предоставившего максимальное количество услуг по каждому пункту,  по району и по городу в целом.\n" +
                "3-й запрос: Определить доходы каждого пункта в районе, доходы от пунктов по каждому району и по городу в целом за указанный год (в одном районе может находиться несколько пунктов).",
                "FAQ"
                );
            
        }
        string request;
        private void simpleRequestsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            request = simpleRequestsBox.GetItemText(simpleRequestsBox.SelectedItem);

            if (request == "Ветеринарные клиники, где суммарный оклад сотрудников на опред. должности выше указанного" || request == "Учёт сотрудников по должности")
                posBox.Enabled = true;
            else
                posBox.Enabled = false;

            if (request == "Запрос для таблицы Процедуры без использования индекса (по виду процедуры)")
                procedureTypeBox.Enabled = true;
            else
                procedureTypeBox.Enabled = false;

            if (request == "Ветеринарные клиники" || request == "Сотрудники" || request == "Процедуры"
                || request == "Районы, в которых нет вет. клиник" || request == "Сотрудники, не делавшие процедур"
                || request == "Количество проведённых процедур всего и в каждом районе"
                || request == "Количество сотрудников с минимальным окладом в каждой ветеринарной клинике"
                || request == "Ветеринарные клиники, которые находятся в районе Басманный"
                || request == "Ветеринарные клиники, которые находятся вне района Басманный"
                || request == "Запрос для таблицы Процедуры без использования индекса (по виду процедуры)"
                || request == "Использование оператора IN для поиска животных определенных видов"
                || request == "Использование оператора NOT IN для поиска животных, которые не относятся к определенным видам"
                || request == "Использование оператора CASE для вычисления скидки на процедуры"
                || request == "Использование подзапроса для выбора владельцев, у которых есть более одного животного")
                valueBox.Enabled = false;
            else
                valueBox.Enabled = true;
        }

        private void simpleRequestButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table;
                switch (request)
                {
                    case "Учёт сотрудников по должности":
                        table = RequestsExecuter.Request_1(positionBox);
                        dataGridView1.DataSource = table;
                        break;
                    case "Ветеринарные клиники в определённом районе":
                        table = RequestsExecuter.Request_2(valueBox.Text);
                        dataGridView1.DataSource = table;
                        break;
                    case "Процедуры оказанные в опред. дату":
                        table = RequestsExecuter.Request_3(valueBox.Text);
                        dataGridView1.DataSource = table;
                        break;
                    case "Сотрудники, родившиеся в опред. дату":
                        table = RequestsExecuter.Request_4(valueBox.Text);
                        dataGridView1.DataSource = table;
                        break;
                    case "Ветеринарные клиники":
                        table = RequestsExecuter.Request_5();
                        dataGridView1.DataSource = table;
                        break;
                    case "Сотрудники":
                        table = RequestsExecuter.Request_6();
                        dataGridView1.DataSource = table;
                        break;
                    case "Процедуры":
                        table = RequestsExecuter.Request_7();
                        dataGridView1.DataSource = table;
                        break;
                    case "Районы, в которых нет вет. клиник":
                        table = RequestsExecuter.Request_8();
                        dataGridView1.DataSource = table;
                        break;
                    case "Сотрудники, не делавшие процедур":
                        table = RequestsExecuter.Request_9();
                        dataGridView1.DataSource = table;
                        break;
                    case "Сотрудники, не делавшие процедур опред. даты":
                        table = RequestsExecuter.Request_10(valueBox.Text);
                        dataGridView1.DataSource = table;
                        break;
                    case "Количество проведённых процедур всего и в каждом районе":
                        table = RequestsExecuter.Request_11();
                        dataGridView1.DataSource = table;
                        break;
                    case "Количество сотрудников в ветеринарных клиниках с окладом больше указанного":
                        table = RequestsExecuter.Request_12(valueBox.Text);
                        dataGridView1.DataSource = table;
                        break;
                    case "Ветеринарные клиники, где средний оклад сотрудников больше указанного":
                        table = RequestsExecuter.Request_13(valueBox.Text);
                        dataGridView1.DataSource = table;
                        break;
                    case "Ветеринарные клиники, где суммарный оклад сотрудников на опред. должности выше указанного":
                        table = RequestsExecuter.Request_14(valueBox.Text, positionBox);
                        dataGridView1.DataSource = table;
                        break;
                    case "Количество сотрудников с минимальным окладом в каждой ветеринарной клинике":
                        table = RequestsExecuter.Request_15();
                        dataGridView1.DataSource = table;
                        break;
                    case "Ветеринарные клиники, которые находятся в районе Басманный":
                        table = RequestsExecuter.Request_16();
                        dataGridView1.DataSource = table;
                        break;
                    case "Ветеринарные клиники, которые находятся вне района Басманный":
                        table = RequestsExecuter.Request_17();
                        dataGridView1.DataSource = table;
                        break;
                    case "Запрос для таблицы Ветеринарные клиники с использованием условия по значению (по коду ветеринарной клиники)":
                        table = RequestsExecuter.Request_18(valueBox.Text);
                        dataGridView1.DataSource = table;
                        break;
                    case "Запрос для таблицы Животные с использованием условия по маске (по виду животного)":
                        table = RequestsExecuter.Request_19(valueBox.Text);
                        dataGridView1.DataSource = table;
                        break;
                    case "Запрос для таблицы Процедуры с использованием индекса (по коду животного)":
                        table = RequestsExecuter.Request_20(valueBox.Text);
                        dataGridView1.DataSource = table;
                        break;
                    case "Запрос для таблицы Процедуры без использования индекса (по виду процедуры)":
                        table = RequestsExecuter.Request_21(procedureType);
                        dataGridView1.DataSource = table;
                        break;
                    case "Использование оператора IN для поиска животных определенных видов":
                        table = RequestsExecuter.Request_22();
                        dataGridView1.DataSource = table;
                        break;
                    case "Использование оператора NOT IN для поиска животных, которые не относятся к определенным видам":
                        table = RequestsExecuter.Request_23();
                        dataGridView1.DataSource = table;
                        break;
                    case "Использование оператора CASE для вычисления скидки на процедуры":
                        table = RequestsExecuter.Request_24();
                        dataGridView1.DataSource = table;
                        break;
                    case "Использование подзапроса для выбора владельцев, у которых есть более одного животного":
                        table = RequestsExecuter.Request_25();
                        dataGridView1.DataSource = table;
                        break;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}; Возможно вы ввели не верный параметр");
            }
        }
        string positionBox;

        private void posBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            positionBox = posBox.GetItemText(posBox.SelectedItem);
        }

        string procedureType;
        private void procedureTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            procedureType = procedureTypeBox.GetItemText(procedureTypeBox.SelectedItem);
        }


        //private void pictureBox3_MouseLeave(object sender, EventArgs e)
        //{
        //    pictureBox3.Image = new Bitmap(@"C:\Users\fikra\source\repos\VeterenaryClinicApp\VeterenaryClinicApp\Resources\9111264_question_circle_icon.png");
        //}

        //private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        //{
        //    pictureBox3.Image = new Bitmap(@"C:\Users\fikra\source\repos\VeterenaryClinicApp\VeterenaryClinicApp\Resources\9111264_question_circle_icon (1).png");
        //}

    }
}
