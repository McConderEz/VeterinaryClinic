﻿using System;
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
    public partial class RequestForm : Form
    {
        public RequestForm()
        {
            InitializeComponent();
        }

        private void RequestForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        //private void pictureBox2_MouseLeave(object sender, EventArgs e)
        //{
        //    pictureBox2.Image = new Bitmap(@"C:\Users\fikra\source\repos\VeterenaryClinicApp\VeterenaryClinicApp\Resources\511955_arrow_before_beginning_left_previous_icon.png");
        //}

        //private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        //{
        //    pictureBox2.Image = new Bitmap(@"C:\Users\fikra\source\repos\VeterenaryClinicApp\VeterenaryClinicApp\Resources\511955_arrow_before_beginning_left_previous_icon (1).png");
        //}

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
            
        //}

        //private void textBox1_Click(object sender, EventArgs e)
        //{
        //    textBox1.Clear();
        //}

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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "1-й запрос: Определить лучший ветеринарный пункт по каждому району и тройку лучших пунктов по городу в целом.\n" +
                "2-й запрос: Определить сотрудника предоставившего максимальное количество услуг по каждому пункту,  по району и по городу в целом.\n" +
                "3-й запрос: Определить доходы каждого пункта в районе, доходы от пунктов по каждому району и по городу в целом за указанный год (в одном районе может находиться несколько пунктов).",
                "FAQ"
                );
            
        }

        //private void pictureBox3_MouseLeave(object sender, EventArgs e)
        //{
        //    pictureBox3.Image = new Bitmap(@"C:\Users\fikra\source\repos\VeterenaryClinicApp\VeterenaryClinicApp\Resources\9111264_question_circle_icon.png");
        //}

        //private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        //{
        //    pictureBox3.Image = new Bitmap(@"C:\Users\fikra\source\repos\VeterenaryClinicApp\VeterenaryClinicApp\Resources\9111264_question_circle_icon (1).png");
        //}

    }
}
