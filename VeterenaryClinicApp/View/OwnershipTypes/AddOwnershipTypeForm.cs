﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterenaryClinicApp.Controller;

namespace VeterenaryClinicApp.View.OwnershipTypes
{
    public partial class AddOwnershipTypeForm : Form
    {

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

        public AddOwnershipTypeForm()
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
            if (Adder.AddOwnership(ownershipBox.Text))
            {
                MessageBox.Show("Запись успешно добавлена!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Запись не была добавленна ввиду некорректности входных данных!");
            }
        }

        private void AddOwnershipTypeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
