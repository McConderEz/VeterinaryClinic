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
            //Generator.GenerateDataBase();
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
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники]";
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
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Сотрудники]";
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
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Животные]";
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
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Процедуры]";
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
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Виды животных]";
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
            OpenChildForm(new TableForm(dataTable, "Типы собственности"));
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
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Лицензии]";
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
            OpenChildForm(new TableForm(dataTable, "Виды процедур"));
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
