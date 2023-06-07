using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using VeterenaryClinicApp.Model;
using System.Data.SqlClient;

namespace VeterenaryClinicApp
{
    public partial class FilterForm : Form
    {
        public FilterForm(DataTable dt1, DataTable dt2)
        {
            InitializeComponent();
            dgvVetClinic.DataSource = dt1;
            dgvEmployee.DataSource = dt2;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FilterParamForm filterParamForm = new FilterParamForm();
            filterParamForm.ShowDialog();
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvVetClinic.SelectedRows;
            List<int> ids = new List<int>();
            for (var i = 0; i < selectedRows.Count; i++)
            {
                ids.Add((int)selectedRows[i].Cells["Код ветеринарной клинки"].Value);
            }

            using(var db = new Veterinary_ClinicEntities())
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
               "INNER JOIN [Veterinary Clinic].[dbo].[Должности] ON ([Veterinary Clinic].[dbo].[Сотрудники].[Код должности]) = [Veterinary Clinic].[dbo].[Должности].[Код должности]" +
               $"WHERE [Veterinary Clinic].[dbo].[Сотрудники].[Код ветеринарной клиники] IN (" + string.Join(",", ids.Select(x => $"'{x}'")) + ")";
                
                SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
                var dataTableEmployee = new DataTable();
                adapter.Fill(dataTableEmployee);



                dgvEmployee.DataSource = dataTableEmployee;
                dgvEmployee.Invalidate();
            }

        }
    }
}
