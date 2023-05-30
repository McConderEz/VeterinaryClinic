using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterenaryClinicApp.Controller;

namespace VeterenaryClinicApp.View.Licenses
{
    public partial class AddLicenseForm : Form
    {
        byte[] imageData;
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
        public AddLicenseForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Adder.AddLicense(numberBox.Text, dateToEndBox.Text, codeVeterinaryClinicBox.Text, imageData))
            {
                MessageBox.Show("Запись успешно добавлена!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Запись не была добавленна ввиду некорректности входных данных!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openImage.ShowDialog();
            openImage.Filter = "JPEG files (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG files (*.png)|*.png";
            imageData = File.ReadAllBytes(openImage.FileName);
        }
    }
}
