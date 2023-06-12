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

namespace VeterenaryClinicApp.View.Procedure
{
    public partial class EditProcedureForm : Form
    {
        int id;
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
        public EditProcedureForm(DataGridViewRow dataGridViewRow)
        {
            id = (int)dataGridViewRow.Cells["Код процедуры"].Value;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (Editer.EditProcedure(id, dataHelpBox.Text, procedureType[codeTypeProcedureBox].ToString(), priceBox.Text,
                discountBox.Text, materialsPriceBox.Text, codeEmployeeBox.Text, codeAnimalBox.Text))
            {
                MessageBox.Show("Запись успешно Изменена!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Запись не была изменена ввиду некорректности входных данных!");
            }
        }

        string codeTypeProcedureBox;
        private void procedureTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            codeTypeProcedureBox = procedureTypeBox.GetItemText(procedureTypeBox.SelectedItem);
        }

        private void EditProcedureForm_Load(object sender, EventArgs e)
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
    }
}
