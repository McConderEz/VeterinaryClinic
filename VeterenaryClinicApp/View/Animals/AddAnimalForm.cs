using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using VeterenaryClinicApp.Controller;
using VeterenaryClinicApp.Model;

namespace VeterenaryClinicApp.View.Animals
{
    public partial class AddAnimalForm : Form
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
        public AddAnimalForm()
        {
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
            if (Adder.AddAnimal(nameBox.Text, ageBox.Text, conditionsBox.Text, codeOwnerBox.Text,
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

        private void AddAnimalForm_Load(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            using (var db = new Veterinary_ClinicEntities())
            { 

                var commandTemp = new SqlCommand("SELECT [Код вида животного],[Вид животного] FROM [Виды животных]", myConnection);

                using(var reader  = commandTemp.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["Код вида животного"];
                        string name = (string)reader["Вид животного"];
                        animalType.Add(name, id);
                    }
                }

                
            }

            

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

        private void codeOwnerBox_TextChanged(object sender, EventArgs e)
        {
            ownerLabel.Text = "Владелец:";
            using(var db = new Veterinary_ClinicEntities())
            {
                var temp = db.Владельцы.Find(int.Parse(codeOwnerBox.Text));
                if(temp != null)
                    ownerLabel.Text += " " + temp.Фамилия.Trim(' ') + " " + temp.Имя.Trim(' ') + " " + temp.Отчество.Trim(' ');
                else
                    ownerLabel.Text = "Владелец:";
            }
        }
    }
}
