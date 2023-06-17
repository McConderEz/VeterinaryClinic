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
                || request == "Список клиник с количеством выполненных процедур"
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
                    case "Список клиник с количеством выполненных процедур":
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

        //Запрос 1
        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            var table = new DataTable();
            string sql = @"
    WITH cte AS (
        SELECT
            [Ветеринарные клиники].[Название пункта],
            [Ветеринарные клиники].[Номер регистрационного пункта],
            [Районы].[Район города],
            [Сотрудники].[Код ветеринарной клиники],
            COUNT(*) AS Количество_процедур,
            DENSE_RANK() OVER (PARTITION BY [Районы].[Район города] ORDER BY COUNT(*) DESC, [Ветеринарные клиники].[Название пункта]) AS Ранг_по_району,
            ROW_NUMBER() OVER (ORDER BY COUNT(*) DESC, [Ветеринарные клиники].[Название пункта]) AS Ранг_по_городу
        FROM [dbo].[Процедуры]
        INNER JOIN [dbo].[Сотрудники] ON [Процедуры].[Код сотрудника] = [Сотрудники].[Код сотрудника]
        INNER JOIN [dbo].[Ветеринарные клиники] ON [Сотрудники].[Код ветеринарной клиники] = [Ветеринарные клиники].[Код ветеринарной клинки]
        INNER JOIN [dbo].[Районы] ON [Ветеринарные клиники].[Код район города] = [Районы].[Код района]
        GROUP BY
            [Ветеринарные клиники].[Название пункта],
            [Ветеринарные клиники].[Номер регистрационного пункта],
            [Районы].[Район города],
            [Сотрудники].[Код ветеринарной клиники]
    )
    SELECT
        cte1.[Район города],
        STUFF((SELECT ', ' + [Название пункта]
               FROM cte
               WHERE [Район города] = cte1.[Район города] AND [Ранг_по_району] = 1
               FOR XML PATH('')), 1, 2, '') AS [Лучшие пункты по району],
        STUFF((SELECT TOP 3 ', ' + [Название пункта] + ' (' + CAST([Количество_процедур] AS VARCHAR) + ')'
               FROM cte
               WHERE [Ранг_по_городу] <= 3
               ORDER BY [Ранг_по_городу]
               FOR XML PATH('')), 1, 2, '') AS [Топ 3 лучших пункта по городу],
        cte1.[Код ветеринарной клиники],
        cte1.[Номер регистрационного пункта],
        cte1.[Количество_процедур]
    FROM
        cte AS cte1
    WHERE
        cte1.[Ранг_по_району] = 1
    GROUP BY
        cte1.[Район города], cte1.[Код ветеринарной клиники], cte1.[Номер регистрационного пункта], cte1.[Количество_процедур]";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);

            dataGridView1.DataSource = table;
        }

        //Запрос 2
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            var table = new DataTable();
            #region temp
            //Общий запрос
            //            string sql = @"WITH cte AS (
            //    SELECT 
            //        [Veterinary Clinic].[dbo].[Сотрудники].[Имя], 
            //        [Veterinary Clinic].[dbo].[Сотрудники].[Фамилия], 
            //        [Veterinary Clinic].[dbo].[Сотрудники].[Отчество], 
            //        [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта], 
            //        [Veterinary Clinic].[dbo].[Районы].[Район города], 
            //        COUNT(*) AS [Количество процедур],
            //        DENSE_RANK() OVER (PARTITION BY [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки], [Veterinary Clinic].[dbo].[Районы].[Код района] ORDER BY COUNT(*) DESC) AS [Ранг по пункту],
            //        DENSE_RANK() OVER (PARTITION BY [Veterinary Clinic].[dbo].[Районы].[Код района] ORDER BY COUNT(*) DESC) AS [Ранг по району],
            //        DENSE_RANK() OVER (ORDER BY COUNT(*) DESC) AS [Ранг по городу]
            //    FROM [Veterinary Clinic].[dbo].[Процедуры]
            //    INNER JOIN [Veterinary Clinic].[dbo].[Сотрудники] ON [Процедуры].[Код сотрудника] = [Сотрудники].[Код сотрудника]
            //    INNER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники] ON [Сотрудники].[Код ветеринарной клиники] = [Ветеринарные клиники].[Код ветеринарной клинки]
            //    INNER JOIN [Veterinary Clinic].[dbo].[Районы] ON [Ветеринарные клиники].[Код район города] = [Районы].[Код района]
            //    GROUP BY 
            //        [Veterinary Clinic].[dbo].[Сотрудники].[Имя], 
            //        [Veterinary Clinic].[dbo].[Сотрудники].[Фамилия], 
            //        [Veterinary Clinic].[dbo].[Сотрудники].[Отчество], 
            //        [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта], 
            //        [Veterinary Clinic].[dbo].[Районы].[Район города],
            //        [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки],
            //        [Veterinary Clinic].[dbo].[Районы].[Код района]
            //)
            //SELECT 
            //    [По пункту].[Название пункта], 
            //    [По пункту].[Район города], 
            //    [По пункту].[Максимальное количество процедур],
            //    [По пункту].[Сотрудник с максимальным количеством процедур]
            //FROM 
            //    (
            //    SELECT 
            //        [cte].[Название пункта], 
            //        [cte].[Район города], 
            //        [cte].[Имя] + ' ' + [cte].[Фамилия] + ' ' + [cte].[Отчество] AS [Сотрудник с максимальным количеством процедур], 
            //        [cte].[Количество процедур],
            //        MAX([cte].[Количество процедур]) OVER (PARTITION BY [cte].[Название пункта]) AS [Максимальное количество процедур]
            //    FROM 
            //        [cte]
            //    WHERE 
            //        [cte].[Ранг по пункту] = 1
            //    ) AS [По пункту]
            //    FULL OUTER JOIN
            //    (
            //    SELECT 
            //        [cte].[Название пункта], 
            //        [cte].[Район города], 
            //       MAX([cte].[Количество процедур]) AS [Максимальное количество процедур]
            //    FROM 
            //        [cte]
            //    WHERE 
            //        [cte].[Ранг по району] = 1
            //    GROUP BY 
            //        [cte].[Название пункта], 
            //        [cte].[Район города]
            //    ) AS [По району]
            //    ON [По пункту].[Название пункта] = [По району].[Название пункта] AND [По пункту].[Район города] = [По району].[Район города]
            //    FULL OUTER JOIN
            //    (
            //    SELECT 
            //        [cte].[Имя] + ' ' + [cte].[Фамилия] + ' ' + [cte].[Отчество] AS [Сотрудник с максимальным количеством процедур], 
            //        MAX([cte].[Количество процедур]) AS [Максимальное количество процедур]
            //    FROM 
            //        [cte]
            //    WHERE 
            //        [cte].[Ранг по городу] = 1
            //    GROUP BY 
            //        [cte].[Имя], 
            //        [cte].[Фамилия], 
            //        [cte].[Отчество]
            //    ) AS [По городу]
            //    ON [По пункту].[Сотрудник с максимальным количеством процедур] = [По городу].[Сотрудник с максимальным количеством процедур]";

            //По пунктам
            //            string sql = @"SELECT 
            //    [Ветеринарные клиники].[Номер регистрационного пункта],
            //    [Ветеринарные клиники].[Код ветеринарной клинки],
            //    [Сотрудники].[Код сотрудника],
            //    [Ветеринарные клиники].[Название пункта], 
            //    [Сотрудники].[Имя], 
            //    [Сотрудники].[Фамилия], 
            //    [Сотрудники].[Отчество], 
            //    COUNT(*) AS [Количество процедур]
            //FROM [Процедуры]
            //INNER JOIN [Сотрудники] ON [Процедуры].[Код сотрудника] = [Сотрудники].[Код сотрудника]
            //INNER JOIN [Ветеринарные клиники] ON [Сотрудники].[Код ветеринарной клиники] = [Ветеринарные клиники].[Код ветеринарной клинки]
            //GROUP BY 
            //    [Ветеринарные клиники].[Номер регистрационного пункта],
            //    [Ветеринарные клиники].[Код ветеринарной клинки],
            //    [Ветеринарные клиники].[Название пункта], 
            //    [Сотрудники].[Код сотрудника],
            //    [Сотрудники].[Имя], 
            //    [Сотрудники].[Фамилия], 
            //    [Сотрудники].[Отчество]";
            #endregion

            //По ветеринарным клиникам
            //            string sql = @"WITH CTE AS (
            //   SELECT 
            //      [Ветеринарные клиники].[Код ветеринарной клинки], 
            //      [Сотрудники].[Код сотрудника], 
            //      [Сотрудники].[Фамилия], 
            //      [Сотрудники].[Имя], 
            //      [Сотрудники].[Отчество], 
            //      [Ветеринарные клиники].[Номер регистрационного пункта], 
            //      [Ветеринарные клиники].[Название пункта], 
            //      COUNT(*) AS [Количество процедур], 
            //      ROW_NUMBER() OVER(
            //         PARTITION BY [Ветеринарные клиники].[Код ветеринарной клинки] 
            //         ORDER BY COUNT(*) DESC, [Сотрудники].[Фамилия], [Сотрудники].[Имя], [Сотрудники].[Отчество]
            //      ) AS [Ранг] 
            //   FROM [Процедуры] 
            //   JOIN [Сотрудники] ON [Процедуры].[Код сотрудника] = [Сотрудники].[Код сотрудника] 
            //   JOIN [Ветеринарные клиники] ON [Сотрудники].[Код ветеринарной клиники] = [Ветеринарные клиники].[Код ветеринарной клинки] 
            //   GROUP BY [Ветеринарные клиники].[Код ветеринарной клинки], [Сотрудники].[Код сотрудника], [Сотрудники].[Фамилия], [Сотрудники].[Имя], [Сотрудники].[Отчество], [Ветеринарные клиники].[Номер регистрационного пункта], [Ветеринарные клиники].[Название пункта]
            //)
            //SELECT 
            //   [Ветеринарные клиники].[Код ветеринарной клинки], 
            //   [Сотрудники].[Код сотрудника], 
            //   [Сотрудники].[Фамилия], 
            //   [Сотрудники].[Имя], 
            //   [Сотрудники].[Отчество], 
            //   [Ветеринарные клиники].[Номер регистрационного пункта], 
            //   [Ветеринарные клиники].[Название пункта], 
            //   [Количество процедур] 
            //FROM CTE 
            //JOIN [Ветеринарные клиники] ON [CTE].[Код ветеринарной клинки] = [Ветеринарные клиники].[Код ветеринарной клинки] 
            //JOIN [Сотрудники] ON [CTE].[Код сотрудника] = [Сотрудники].[Код сотрудника] 
            //WHERE [Ранг] = 1;";

            //По районам
            //string sql = "WITH CTE AS ( " +
            //   "SELECT [Районы].[Район города], [Сотрудники].[Код сотрудника], [Сотрудники].[Фамилия], [Сотрудники].[Имя], [Сотрудники].[Отчество], [Ветеринарные клиники].[Номер регистрационного пункта], [Ветеринарные клиники].[Название пункта], " +
            //   "COUNT(*) AS [Количество процедур], " +
            //   "ROW_NUMBER() OVER(PARTITION BY [Районы].[Район города] ORDER BY COUNT(*) DESC, [Сотрудники].[Фамилия], [Сотрудники].[Имя], [Сотрудники].[Отчество]) AS [Ранг] " +
            //   "FROM [Процедуры] " +
            //   "JOIN [Сотрудники] ON [Процедуры].[Код сотрудника] = [Сотрудники].[Код сотрудника] " +
            //   "JOIN [Ветеринарные клиники] ON [Сотрудники].[Код ветеринарной клиники] = [Ветеринарные клиники].[Код ветеринарной клинки] " +
            //   "JOIN [Районы] ON [Ветеринарные клиники].[Код район города] = [Районы].[Код района] " +
            //   "GROUP BY [Районы].[Район города], [Сотрудники].[Код сотрудника], [Сотрудники].[Фамилия], [Сотрудники].[Имя], [Сотрудники].[Отчество], [Ветеринарные клиники].[Номер регистрационного пункта], [Ветеринарные клиники].[Название пункта] " +
            //   ") " +
            //   "SELECT [Район города], [Код сотрудника], [Фамилия], [Имя], [Отчество], [Номер регистрационного пункта], [Название пункта], [Количество процедур] " +
            //   "FROM CTE " +
            //   "WHERE [Ранг] = 1";

            //Вне зависимости от района
            //string sql = "WITH CTE AS ( " +
            //   "SELECT [Районы].[Район города], [Сотрудники].[Код сотрудника], [Сотрудники].[Фамилия], [Сотрудники].[Имя], [Сотрудники].[Отчество], [Ветеринарные клиники].[Номер регистрационного пункта], [Ветеринарные клиники].[Название пункта], " +
            //   "COUNT(*) AS [Количество процедур], " +
            //   "ROW_NUMBER() OVER(PARTITION BY [Районы].[Район города] ORDER BY COUNT(*) DESC, [Сотрудники].[Фамилия], [Сотрудники].[Имя], [Сотрудники].[Отчество]) AS [Ранг] " +
            //   "FROM [Процедуры] " +
            //   "JOIN [Сотрудники] ON [Процедуры].[Код сотрудника] = [Сотрудники].[Код сотрудника] " +
            //   "JOIN [Ветеринарные клиники] ON [Сотрудники].[Код ветеринарной клиники] = [Ветеринарные клиники].[Код ветеринарной клинки] " +
            //   "JOIN [Районы] ON [Ветеринарные клиники].[Код район города] = [Районы].[Код района] " +
            //   "GROUP BY [Районы].[Район города], [Сотрудники].[Код сотрудника], [Сотрудники].[Фамилия], [Сотрудники].[Имя], [Сотрудники].[Отчество], [Ветеринарные клиники].[Номер регистрационного пункта], [Ветеринарные клиники].[Название пункта] " +
            //   ") " +
            //   "SELECT TOP 1 [Район города], [Код сотрудника], [Фамилия], [Имя], [Отчество], [Номер регистрационного пункта], [Название пункта], [Количество процедур] " +
            //   "FROM CTE " +
            //   "ORDER BY [Количество процедур] DESC";


            string sql = @"WITH CTE AS (
SELECT 
[Ветеринарные клиники].[Код ветеринарной клинки],
[Сотрудники].[Код сотрудника],
[Сотрудники].[Фамилия],
[Сотрудники].[Имя],
[Сотрудники].[Отчество],
[Ветеринарные клиники].[Номер регистрационного пункта], 
[Ветеринарные клиники].[Название пункта],
[Районы].[Район города],
COUNT(*) AS [Количество процедур],
ROW_NUMBER() OVER(
PARTITION BY [Ветеринарные клиники].[Код ветеринарной клинки]
ORDER BY COUNT(*) DESC, [Сотрудники].[Фамилия], [Сотрудники].[Имя], [Сотрудники].[Отчество]
) AS [Ранг по клинике],
ROW_NUMBER() OVER(
PARTITION BY [Районы].[Район города] 
ORDER BY COUNT(*) DESC, [Сотрудники].[Фамилия], [Сотрудники].[Имя], [Сотрудники].[Отчество]
) AS [Ранг по району]
FROM [Процедуры]
JOIN [Сотрудники] ON [Процедуры].[Код сотрудника] = [Сотрудники].[Код сотрудника] 
JOIN [Ветеринарные клиники] ON [Сотрудники].[Код ветеринарной клиники] = [Ветеринарные клиники].[Код ветеринарной клинки]
JOIN [Районы] ON [Ветеринарные клиники].[Код район города] = [Районы].[Код района]
GROUP BY [Ветеринарные клиники].[Код ветеринарной клинки], [Сотрудники].[Код сотрудника], [Сотрудники].[Фамилия], [Сотрудники].[Имя], 
[Сотрудники].[Отчество], [Ветеринарные клиники].[Номер регистрационного пункта], [Ветеринарные клиники].[Название пункта], [Районы].[Район города] 
)
SELECT 
[Ранг по клинике],
[Ранг по району],
[Район города],
[Код сотрудника],
[Фамилия],
[Имя],
[Отчество],
[Номер регистрационного пункта],
[Название пункта],
[Количество процедур]
FROM CTE
WHERE 
[Ранг по клинике] = 1 OR 
[Ранг по району] = 1 OR 
[Ранг по клинике] IS NULL
ORDER BY [Количество процедур] DESC;";

            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);

            dataGridView1.DataSource = table;
        }

        //Запрос 3
        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            var table = new DataTable();
            #region stuff
            //            string sql = @"WITH CTE AS (
            //SELECT
            //[Ветеринарные клиники].[Код ветеринарной клинки],
            //[Ветеринарные клиники].[Номер регистрационного пункта],
            //[Ветеринарные клиники].[Название пункта],
            //[Районы].[Район города],
            //SUM([Процедуры].[Цена процедуры]) AS [Доходы]
            //FROM [Процедуры]
            //JOIN [Сотрудники] ON [Процедуры].[Код сотрудника] = [Сотрудники].[Код сотрудника]
            //JOIN [Ветеринарные клиники] ON [Сотрудники].[Код ветеринарной клиники] = [Ветеринарные клиники].[Код ветеринарной клинки]
            //JOIN [Районы] ON [Ветеринарные клиники].[Код район города] = [Районы].[Код района]
            //WHERE YEAR([Процедуры].[Дата оказания помощи животному]) = '2013'
            //GROUP BY [Ветеринарные клиники].[Код ветеринарной клинки], [Ветеринарные клиники].[Номер регистрационного пункта], [Ветеринарные клиники].[Название пункта], [Районы].[Район города]
            //)
            //SELECT
            //[Район города],
            //[Номер регистрационного пункта],
            //[Название пункта],
            //[Доходы]
            //FROM CTE
            //ORDER BY [Доходы] DESC;

            //WITH CTE AS (
            //SELECT
            //[Районы].[Район города],
            //SUM([Процедуры].[Цена процедуры]) AS [Доходы]
            //FROM [Процедуры]
            //JOIN [Сотрудники] ON [Процедуры].[Код сотрудника] = [Сотрудники].[Код сотрудника]
            //JOIN [Ветеринарные клиники] ON [Сотрудники].[Код ветеринарной клиники] = [Ветеринарные клиники].[Код ветеринарной клинки]
            //JOIN [Районы] ON [Ветеринарные клиники].[Код район города] = [Районы].[Код района]
            //WHERE YEAR([Процедуры].[Дата оказания помощи животному]) = '2013'
            //GROUP BY [Районы].[Район города]
            //)
            //SELECT
            //[Район города],
            //[Доходы]
            //FROM CTE
            //ORDER BY [Доходы] DESC;

            //WITH CTE AS (
            //SELECT
            //SUM([Процедуры].[Цена процедуры]) AS [Доходы]
            //FROM [Процедуры]
            //WHERE YEAR([Процедуры].[Дата оказания помощи животному]) = '2013'
            //)
            //SELECT
            //[Доходы]
            //FROM CTE;";
            #endregion

            if (int.TryParse(yearBox.Text, out int year))
            {
                string sql = $@"WITH CTE_Clinics AS (
    SELECT
        [Ветеринарные клиники].[Код ветеринарной клинки],
        [Ветеринарные клиники].[Номер регистрационного пункта],
        [Ветеринарные клиники].[Название пункта],
        [Районы].[Район города],
        SUM([Процедуры].[Цена процедуры]) AS [Доходы],
        DENSE_RANK() OVER (ORDER BY SUM([Процедуры].[Цена процедуры]) DESC) AS [Ранг клиники]
    FROM [Процедуры]
    JOIN [Сотрудники] ON [Процедуры].[Код сотрудника] = [Сотрудники].[Код сотрудника]
    JOIN [Ветеринарные клиники] ON [Сотрудники].[Код ветеринарной клиники] = [Ветеринарные клиники].[Код ветеринарной клинки]
    JOIN [Районы] ON [Ветеринарные клиники].[Код район города] = [Районы].[Код района]
    WHERE YEAR([Процедуры].[Дата оказания помощи животному]) = '{yearBox.Text}'
    GROUP BY [Ветеринарные клиники].[Код ветеринарной клинки], [Ветеринарные клиники].[Номер регистрационного пункта], [Ветеринарные клиники].[Название пункта], [Районы].[Район города]
), CTE_Districts AS (
    SELECT
        [Районы].[Район города],
        SUM([Процедуры].[Цена процедуры]) AS [Доходы],
        DENSE_RANK() OVER (ORDER BY SUM([Процедуры].[Цена процедуры]) DESC) AS [Ранг района]
    FROM [Процедуры]
    JOIN [Сотрудники] ON [Процедуры].[Код сотрудника] = [Сотрудники].[Код сотрудника]
    JOIN [Ветеринарные клиники] ON [Сотрудники].[Код ветеринарной клиники] = [Ветеринарные клиники].[Код ветеринарной клинки]
    JOIN [Районы] ON [Ветеринарные клиники].[Код район города] = [Районы].[Код района]
    WHERE YEAR([Процедуры].[Дата оказания помощи животному]) = '{yearBox.Text}'
    GROUP BY [Районы].[Район города]
), CTE_Total AS (
    SELECT
        SUM([Процедуры].[Цена процедуры]) AS [Доходы]
    FROM [Процедуры]
    WHERE YEAR([Процедуры].[Дата оказания помощи животному]) = '{yearBox.Text}'
)
SELECT
    [Ранг клиники] AS [Ранг клиники],
    [Номер регистрационного пункта] AS [Номер пункта],
    [Название пункта] AS [Название],
    [Район города] AS [Район],
    [Доходы] AS [Доходы]
FROM CTE_Clinics
UNION ALL
SELECT
    [Ранг района] AS [Ранг клиники],
    NULL AS [Номер пункта],
    NULL AS [Название],
    [Район города] AS [Район],
    [Доходы] AS [Доходы]
FROM CTE_Districts
UNION ALL
SELECT
    NULL AS [Ранг клиники],
    NULL AS [Номер пункта],
    NULL AS [Название],
    NULL AS [Район],
    [Доходы] AS [Доходы]
FROM CTE_Total
ORDER BY [Доходы] DESC, [Ранг клиники] ASC;";
                SqlCommand command = new SqlCommand(sql, myConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }
            else
            {
                MessageBox.Show("Неверный ввод аргумента!Должен быть год!");
            }
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
