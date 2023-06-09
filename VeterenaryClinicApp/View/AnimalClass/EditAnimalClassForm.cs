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

namespace VeterenaryClinicApp.View.AnimalClass
{
    public partial class EditAnimalClassForm : Form
    {
        Dictionary<string, int> animalClass = new Dictionary<string, int>();
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
        public EditAnimalClassForm(DataGridViewRow dataGridViewRow)
        {
            id = (int)dataGridViewRow.Cells["Код класса животного"].Value;
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (Editer.EditAnimalClass(id,animalClassBox.Text))
            {
                MessageBox.Show("Запись успешно изменена!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Запись не была изменена ввиду некорректности входных данных!");
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
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

        string animalClassText;
        private void animalClassBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //animalClassText = animalClassBox.GetItemText(animalClassBox.SelectedItem);
        }

        private void EditAnimalClassForm_Load(object sender, EventArgs e)
        {
            //using (var db = new Veterinary_ClinicEntities())
            //{
            //    for (var i = 0; i < db.Классы_животных.Count(); i++)
            //    {
            //        animalClass.Add(db.Классы_животных.FirstOrDefault(x => x.Код_класса_животного == (i + 1)).Класс_животного, i + 1);
            //    }

            //}

            //string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            //SqlConnection myConnection = new SqlConnection(connectionString);
            //myConnection.Open();

            //string sql = "SELECT [Класс животного] FROM [Классы животных]";
            //SqlCommand command = new SqlCommand(sql, myConnection);
            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            //var table = new DataTable();
            //adapter.Fill(table);
            //animalClassBox.DataSource = table;
            //animalClassBox.DisplayMember = "Класс животного";
        }
    }
}
