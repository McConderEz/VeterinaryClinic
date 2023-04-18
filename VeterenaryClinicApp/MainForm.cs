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
    public partial class MainForm : Form
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

        public MainForm()
        {
            InitializeComponent();
            customizeDesign();
        }
      

        private void sideMenuPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void customizeDesign()
        {
            tablesPanel.Visible = false;
            dictionaryPanel.Visible = false;
            requestsPanel.Visible = false;
        }

        private void hideSubMenu()
        {
            if (tablesPanel.Visible)
                tablesPanel.Visible = false;
            if(dictionaryPanel.Visible)
                dictionaryPanel.Visible = false;
            if(requestsPanel.Visible)
                requestsPanel.Visible = false;
        }
        
        private void showSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void tablesButton_Click(object sender, EventArgs e)
        {
            showSubMenu(tablesPanel);
        }

        private void dictionaryButton_Click(object sender, EventArgs e)
        {
            showSubMenu(dictionaryPanel);
        }

        private void requestsButton_Click(object sender, EventArgs e)
        {
            showSubMenu(requestsPanel);
        }

        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if(activeForm != null) 
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ChildFormPanel.Controls.Add(childForm);
            ChildFormPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TableForm());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = new Bitmap(@"C:\Users\fikra\source\repos\VeterenaryClinicApp\VeterenaryClinicApp\Resources\3005766_account_door_exit_logout_icon.png");
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = new Bitmap(@"C:\Users\fikra\source\repos\VeterenaryClinicApp\VeterenaryClinicApp\Resources\3005766_account_door_exit_logout_icon (1).png");
        }

        private void ownerButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TableForm());
        }

        private void employeesButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TableForm());
        }

        private void animalsButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TableForm());
        }

        private void procButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TableForm());
        }

        private void positionsButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TableForm());
        }

        private void disctrictsButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TableForm());
        }

        private void classesButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TableForm());
        }

        private void typeButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TableForm());
        }

        private void ownershipButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TableForm());
        }

        private void licencesButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TableForm());
        }

        private void typeProcButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TableForm());
        }

        private void button1_Click(object sender, EventArgs e)//фильтрация
        {
            OpenChildForm(new FilterForm());
        }

        private void requestButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RequestForm());
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SearchingForm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showSubMenu(diagramPanel);
        }

        private void button6_Click(object sender, EventArgs e)//диаграммы
        {
            OpenChildForm(new StatisticForm());
        }
    }
}
