using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeterenaryClinicApp
{
    public partial class FilterForm : Form
    {
        public FilterForm()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = new Bitmap(@"C:\Users\fikra\source\repos\VeterenaryClinicApp\VeterenaryClinicApp\Resources\3844475_filter_filters_icon.png");
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = new Bitmap(@"C:\Users\fikra\source\repos\VeterenaryClinicApp\VeterenaryClinicApp\Resources\3844475_filter_filters_icon (1).png");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FilterParamForm filterParamForm = new FilterParamForm();
            filterParamForm.ShowDialog();
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = new Bitmap(@"C:\Users\fikra\source\repos\VeterenaryClinicApp\VeterenaryClinicApp\Resources\5875997_action_parameters_params_preferences_setting_icon.png");
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = new Bitmap(@"C:\Users\fikra\source\repos\VeterenaryClinicApp\VeterenaryClinicApp\Resources\5875997_action_parameters_params_preferences_setting_icon (1).png");
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
