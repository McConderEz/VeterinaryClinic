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

namespace VeterenaryClinicApp.View.AnimalType
{
    public partial class EditAnimalTypeForm : Form
    {
        int id;
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
        public EditAnimalTypeForm(DataGridViewRow dataGridViewRow)
        {
            id = (int)dataGridViewRow.Cells["Код вида животного"].Value;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Editer.EditAnimalType(id,animalTypeBox.Text, animalClass[animalClassText].ToString()))
            {
                MessageBox.Show("Запись успешно изменена!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Запись не была изменена ввиду некорректности входных данных!");
            }
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

        private void EditAnimalTypeForm_Load(object sender, EventArgs e)
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                for (var i = 0; i < db.Классы_животных.Count(); i++)
                {
                    if (db.Классы_животных.FirstOrDefault(x => x.Код_класса_животного == (i + 1)) != null)
                        animalClass.Add(db.Классы_животных.FirstOrDefault(x => x.Код_класса_животного == (i + 1)).Класс_животного, db.Классы_животных.FirstOrDefault(x => x.Код_класса_животного == i + 1).Код_класса_животного);
                }

            }

            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string sql = "SELECT [Класс животного] FROM [Классы животных]";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);
            animalClassBox.DataSource = table;
            animalClassBox.DisplayMember = "Класс животного";
        }

        string animalClassText;
        private void animalClassBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            animalClassText = animalClassBox.GetItemText(animalClassBox.SelectedItem);
        }
    }
}
