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

namespace VeterenaryClinicApp
{

    public partial class EditForm : Form
    {
        Dictionary<string, int> ownershipType = new Dictionary<string, int>();
        Dictionary<string, int> district = new Dictionary<string, int>();
        int id;
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

        public EditForm(DataGridViewRow dataGridViewRow)
        {
            id = (int)dataGridViewRow.Cells["Код ветеринарной клинки"].Value;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            using (var db = new Veterinary_ClinicEntities())
            {

                var commandTemp = new SqlCommand("SELECT [Код типа собственности],[Тип собственности] FROM [Тип собственности]", myConnection);

                using (var reader = commandTemp.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["Код типа собственности"];
                        string name = (string)reader["Тип собственности"];
                        ownershipType.Add(name, id);
                    }
                }


            }

            using (var db = new Veterinary_ClinicEntities())
            {

                var commandTemp = new SqlCommand("SELECT [Код района],[Район города] FROM [Районы]", myConnection);

                using (var reader = commandTemp.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["Код района"];
                        string name = (string)reader["Район города"];
                        district.Add(name, id);
                    }
                }


            }



            string sql = "SELECT [Район города] FROM [Районы]";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);
            distinctBox.DataSource = table;
            distinctBox.DisplayMember = "Район города";
            sql = "SELECT * FROM [Тип собственности]";
            command = new SqlCommand(sql, myConnection);
            var table2 = new DataTable();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(table2);
            ownershipTypeBox.DataSource = table2;
            ownershipTypeBox.DisplayMember = "Тип собственности";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Editer.EditVeterinaryClinic(id,regNumberBox.Text, ownershipType[ownershipTypeText].ToString(), yearBox.Text,
                district[districtBox].ToString(), addressBox.Text, nameBox.Text, phoneBox.Text))
            {
                MessageBox.Show("Запись успешно Изменена!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Запись не была изменена ввиду некорректности входных данных!");
            }
        }
        string ownershipTypeText;
        string districtBox;
        private void ownershipTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ownershipTypeText = ownershipTypeBox.GetItemText(ownershipTypeBox.SelectedItem);
        }

        private void distinctBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            districtBox = distinctBox.GetItemText(distinctBox.SelectedItem);
        }
    }
}
