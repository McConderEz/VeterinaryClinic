using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterenaryClinicApp.Controller;

namespace VeterenaryClinicApp
{
    public partial class EditForm : Form
    {
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Editer.EditVeterinaryClinic(id,regNumberBox.Text, ownershipTypeBox.Text, yearBox.Text,
                districtBox.Text, addressBox.Text, nameBox.Text, phoneBox.Text))
            {
                MessageBox.Show("Запись успешно Изменена!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Запись не была изменена ввиду некорректности входных данных!");
            }
        }
    }
}
