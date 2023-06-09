﻿using System;
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

namespace VeterenaryClinicApp.View.Employees
{
    public partial class EditEmployeeForm : Form
    {
        Dictionary<string, int> position = new Dictionary<string, int>();
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
        int id;
        public EditEmployeeForm(DataGridViewRow dataGridViewRow)
        {
            id = (int)dataGridViewRow.Cells["Код сотрудника"].Value;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Editer.EditEmployee(id,nameBox.Text, secondNameBox.Text, surNameBox.Text, birthdayBox.Text,
           position[codePositionBox].ToString(), expBox.Text, salaryBox.Text, codeVeterinaryClinicBox.Text))
            {
                MessageBox.Show("Запись успешно добавлена!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Запись не была добавленна ввиду некорректности входных данных!");
            }
        }

        string codePositionBox;
        private void positionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            codePositionBox = positionBox.GetItemText(positionBox.SelectedItem);
        }

        private void EditEmployeeForm_Load(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            using (var db = new Veterinary_ClinicEntities())
            {

                var commandTemp = new SqlCommand("SELECT [Код должности],[Должность] FROM [Должности]", myConnection);

                using (var reader = commandTemp.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["Код должности"];
                        string name = (string)reader["Должность"];
                        position.Add(name, id);
                    }
                }


            }

            string sql = "SELECT [Должность] FROM [Должности]";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);
            positionBox.DataSource = table;
            positionBox.DisplayMember = "Должность";
        }

        private void codeVeterinaryClinicBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                vetClinicLabel.Text = "Ветеринарная клиника:";
                using (var db = new Veterinary_ClinicEntities())
                {
                    var temp = db.Ветеринарные_клиники.Find(int.Parse(codeVeterinaryClinicBox.Text));
                    if (temp != null)
                        vetClinicLabel.Text += " " + temp.Название_пункта.Trim(' ') + " " + temp.Номер_регистрационного_пункта.ToString();
                    else
                        vetClinicLabel.Text = "Ветеринарная клиника:";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
