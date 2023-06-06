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
using VeterenaryClinicApp.Model;

namespace VeterenaryClinicApp
{
    public partial class MainForm : Form
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                base.WndProc(ref m);
                if ((int)m.Result == 0x1)
                    m.Result = (IntPtr)0x2;
                return;
            }

            base.WndProc(ref m);
        }

        public MainForm()
        {
            InitializeComponent();
            customizeDesign();
            Generator.GenerateDataBase();
        }
      

        private void sideMenuPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void customizeDesign()
        {
            tablesPanel.Visible = false;
            dictionaryPanel.Visible = false;
            requestsPanel.Visible = false;
        }

        private void hideSubMenu()
        {
            if (tablesPanel.Visible)
                tablesPanel.Visible = false;
            if(dictionaryPanel.Visible)
                dictionaryPanel.Visible = false;
            if(requestsPanel.Visible)
                requestsPanel.Visible = false;
        }
        
        private void showSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void tablesButton_Click(object sender, EventArgs e)
        {
            showSubMenu(tablesPanel);
        }

        private void dictionaryButton_Click(object sender, EventArgs e)
        {
            showSubMenu(dictionaryPanel);
        }

        private void requestsButton_Click(object sender, EventArgs e)
        {
            showSubMenu(requestsPanel);
        }

        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if(activeForm != null) 
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ChildFormPanel.Controls.Add(childForm);
            ChildFormPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        /// <summary>
        /// Открывает таблицу с Ветеринарными клиниками
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Номер регистрационного пункта]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Год открытия]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Адрес пункта]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта]," +
                "[Veterinary Clinic].[dbo].[Районы].[Район города]," +
                "[Veterinary Clinic].[dbo].[Тип собственности].[Тип собственности]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Телефон] FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники]" +
            "INNER JOIN [Veterinary Clinic].[dbo].[Тип собственности] ON ([Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код типа собственности]) = [Veterinary Clinic].[dbo].[Тип собственности].[Код типа собственности]" +
            "INNER JOIN [Veterinary Clinic].[dbo].[Районы] ON ([Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код район города]) = [Veterinary Clinic].[dbo].[Районы].[Код района]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            OpenChildForm(new TableForm(dataTable,"Ветеринарные клиники"));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = new Bitmap(@"C:\Users\fikra\Source\Repos\VeterinaryClinic\VeterenaryClinicApp\Resources\3005766_account_door_exit_logout_icon.png");
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = new Bitmap(@"C:\Users\fikra\Source\Repos\VeterinaryClinic\VeterenaryClinicApp\Resources\3005766_account_door_exit_logout_icon (1).png");
        }

        /// <summary>
        /// Открывает таблицы с владельцами животных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ownerButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Владельцы]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            OpenChildForm(new TableForm(dataTable, "Владельцы"));
        }

        /// <summary>
        /// Открывает таблицы с сотрудниками ветеринарных клиник
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void employeesButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT [Veterinary Clinic].[dbo].[Сотрудники].[Код сотрудника]," +
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
                "INNER JOIN [Veterinary Clinic].[dbo].[Должности] ON ([Veterinary Clinic].[dbo].[Сотрудники].[Код должности]) = [Veterinary Clinic].[dbo].[Должности].[Код должности]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            OpenChildForm(new TableForm(dataTable, "Сотрудники"));
        }

        /// <summary>
        /// Открывает таблицы с животными
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void animalsButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT [Veterinary Clinic].[dbo].[Животные].[Код животного]," +
                "[Veterinary Clinic].[dbo].[Животные].[Кличка Животного]," +
                "[Veterinary Clinic].[dbo].[Животные].[Возраст Животного]," +
                "[Veterinary Clinic].[dbo].[Животные].[Условия содержания животного]," +
                "[Veterinary Clinic].[dbo].[Владельцы].[Имя]," +
                "[Veterinary Clinic].[dbo].[Владельцы].[Фамилия]," +
                "[Veterinary Clinic].[dbo].[Владельцы].[Отчество]," +
                "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного] FROM [Veterinary Clinic].[dbo].[Животные]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Владельцы] ON ([Veterinary Clinic].[dbo].[Животные].[Код владельца]) = [Veterinary Clinic].[dbo].[Владельцы].[Код владельца] " +                
                "INNER JOIN [Veterinary Clinic].[dbo].[Виды животных] ON ([Veterinary Clinic].[dbo].[Животные].[Код вида животного]) = [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            OpenChildForm(new TableForm(dataTable, "Животные"));
        }

        /// <summary>
        /// Открывает таблицы с процедурами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void procButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT [Veterinary Clinic].[dbo].[Процедуры].[Код процедуры]," +
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
                "INNER JOIN [Veterinary Clinic].[dbo].[Виды процедуры] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код вида процедуры]) = [Veterinary Clinic].[dbo].[Виды процедуры].[Код вида процедуры] ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            OpenChildForm(new TableForm(dataTable, "Процедуры"));
        }

        /// <summary>
        /// Открывает справочник с должностями
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void positionsButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Должности]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            OpenChildForm(new TableForm(dataTable, "Должности"));
        }

        /// <summary>
        /// Открывает справочник с районами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void disctrictsButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Районы]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            OpenChildForm(new TableForm(dataTable, "Районы"));
        }

        /// <summary>
        /// Открывает справочник с классами животных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void classesButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Классы животных]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            OpenChildForm(new TableForm(dataTable, "Классы животных"));
        }

        /// <summary>
        /// Открывает справочник с видами животных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void typeButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного]," +
                "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного]," +
                "[Veterinary Clinic].[dbo].[Классы животных].[Класс животного] FROM [Veterinary Clinic].[dbo].[Виды животных]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Классы животных] ON ([Veterinary Clinic].[dbo].[Виды животных].[Код класса животного]) = [Veterinary Clinic].[dbo].[Классы животных].[Код класса животного]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            OpenChildForm(new TableForm(dataTable, "Виды животных"));
        }

        /// <summary>
        /// Открывает справочник с типами собственности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ownershipButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Тип собственности]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            OpenChildForm(new TableForm(dataTable, "Тип собственности"));
        }

        /// <summary>
        /// Открывает справочник с лицензиями 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void licencesButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT [Veterinary Clinic].[dbo].[Лицензии].[Код лицензии]," +
                "[Veterinary Clinic].[dbo].[Лицензии].[Лицензия №]," +
                "[Veterinary Clinic].[dbo].[Лицензии].[Срок окончания лицензии]," +
                "[Veterinary Clinic].[dbo].[Лицензии].[Фото лицензии]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта] FROM [Veterinary Clinic].[dbo].[Лицензии]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники] ON ([Veterinary Clinic].[dbo].[Лицензии].[Код ветеринарной клинки]) = [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            OpenChildForm(new TableForm(dataTable, "Лицензии"));
        }

        /// <summary>
        /// Открывает справочник с видами процедур
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void typeProcButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Виды процедуры]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            OpenChildForm(new TableForm(dataTable, "Виды процедуры"));
        }

        /// <summary>
        /// Открывает форму с фильтрацией таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)//фильтрация
        {
            OpenChildForm(new FilterForm());
        }

        /// <summary>
        /// Открывает форму с запросами к таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void requestButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RequestForm());
        }

        /// <summary>
        /// Открывает форму с поиском по таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SearchingForm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showSubMenu(diagramPanel);
        }

        private void button6_Click(object sender, EventArgs e)//диаграмма лучшие клиники
        {
            OpenChildForm(new StatisticForm());
        }

        private void button4_Click(object sender, EventArgs e)//диаграмма лучшие сотрудники
        {
            OpenChildForm(new StatisticForm2());
        }

        private void button5_Click(object sender, EventArgs e)//диаграмма доходы клиник
        {
            OpenChildForm(new StatisticForm3());
        }
    }
}
