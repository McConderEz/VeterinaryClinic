﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using VeterenaryClinicApp.Controller;
using System.Data.SqlClient;
using VeterenaryClinicApp.Model;

namespace VeterenaryClinicApp.View.Animals
{
    public partial class EditAnimalForm : Form
    {
        Dictionary<string, int> animalType = new Dictionary<string, int>();
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
        public EditAnimalForm(DataGridViewRow dataGridViewRow)
        {
            id = (int)dataGridViewRow.Cells["Код животного"].Value;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (Editer.EditAnimal(id, nameBox.Text, ageBox.Text, conditionsBox.Text, codeOwnerBox.Text,
             animalType[codeTypeAnimalBox].ToString()))
            {
                MessageBox.Show("Запись успешно добавлена!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Запись не была добавленна ввиду некорректности входных данных!");
            }
        }

        private void EditAnimalForm_Load(object sender, EventArgs e)
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                for (var i = 0; i < db.Виды_животных.Count(); i++)
                {
                    animalType.Add(db.Виды_животных.FirstOrDefault(x => x.Код_вида_животного == (i + 1)).Вид_животного, i + 1);
                }

            }

            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string sql = "SELECT [Вид животного] FROM [Виды животных]";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);
            animalTypeBox.DataSource = table;
            animalTypeBox.DisplayMember = "Вид животного";
        }

        string codeTypeAnimalBox;
        private void animalTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            codeTypeAnimalBox = animalTypeBox.GetItemText(animalTypeBox.SelectedItem);

        }
    }
}
