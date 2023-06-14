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
using static Bunifu.UI.WinForms.BunifuSnackbar;

namespace VeterenaryClinicApp.View.Procedure
{
    public partial class AddProcedureForm : Form
    {
        Dictionary<string, int> procedureType = new Dictionary<string, int>();
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

        public AddProcedureForm()
        {
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
            if (Adder.AddProcedure(dataHelpBox.Text, procedureType[codeTypeProcedureBox].ToString(), priceBox.Text,
                discountBox.Text, materialsPriceBox.Text, codeEmployeeBox.Text, codeAnimalBox.Text))
            {
                MessageBox.Show("Запись успешно добавлена!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Запись не была добавленна ввиду некорректности входных данных!");
            }
        }

        string codeTypeProcedureBox;
        private void procedureTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            codeTypeProcedureBox = procedureTypeBox.GetItemText(procedureTypeBox.SelectedItem);
        }

        private void AddProcedureForm_Load(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            using (var db = new Veterinary_ClinicEntities())
            {

                var commandTemp = new SqlCommand("SELECT [Код вида процедуры],[Вид процедуры] FROM [Виды процедуры]", myConnection);

                using (var reader = commandTemp.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["Код вида процедуры"];
                        string name = (string)reader["Вид процедуры"];
                        procedureType.Add(name, id);
                    }
                }


            }

            string sql = "SELECT [Вид процедуры] FROM [Виды процедуры]";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);
            procedureTypeBox.DataSource = table;
            procedureTypeBox.DisplayMember = "Вид процедуры";
        }

        private void codeEmployeeBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                employeeLabel.Text = "Сотрудник:";
                using (var db = new Veterinary_ClinicEntities())
                {
                    var temp = db.Сотрудники.Find(int.Parse(codeEmployeeBox.Text));
                    if (temp != null)
                        employeeLabel.Text += " " + temp.Фамилия.Trim(' ') + " " + temp.Имя.Trim(' ').ToString() + " " + temp.Отчество.Trim(' ').ToString();
                    else
                        employeeLabel.Text = "Сотрудник:";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void codeAnimalBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                animalLabel.Text = "Животное:";
                using (var db = new Veterinary_ClinicEntities())
                {
                    var temp = db.Животные.Find(int.Parse(codeAnimalBox.Text));
                    if (temp != null)
                        animalLabel.Text += " " + temp.Кличка_Животного.Trim(' ') + " " + db.Виды_животных.FirstOrDefault(x => x.Код_вида_животного == temp.Код_вида_животного).ToString();
                    else
                        animalLabel.Text = "Животное:";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
