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
using VeterenaryClinicApp.View.AnimalClass;
using VeterenaryClinicApp.View.Animals;
using VeterenaryClinicApp.View.AnimalType;
using VeterenaryClinicApp.View.Conditions;
using VeterenaryClinicApp.View.District;
using VeterenaryClinicApp.View.Employees;
using VeterenaryClinicApp.View.Licenses;
using VeterenaryClinicApp.View.Owners;
using VeterenaryClinicApp.View.OwnershipTypes;
using VeterenaryClinicApp.View.Procedure;
using VeterenaryClinicApp.View.ProceduresType;

namespace VeterenaryClinicApp
{
    public partial class TableForm : Form
    {        
        public TableForm(DataTable data,string name)
        {
            InitializeComponent();
            dataGridView1.DataSource = data;
            nameTable.Text = name;           
            counter.Text = "" + (dataGridView1.RowCount);
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

        /// <summary>
        /// Добавление записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            switch (nameTable.Text)
            {
                case "Ветеринарные клиники":
                    AddOwnerForm addForm = new AddOwnerForm();
                    addForm.ShowDialog();
                    while (!addForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Владельцы":
                    var addOwnerForm = new AddOwnerAnimalForm();
                    addOwnerForm.ShowDialog();
                    while (!addOwnerForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Процедуры":
                    var addProcedureForm = new AddProcedureForm();
                    addProcedureForm.ShowDialog();
                    while (!addProcedureForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Сотрудники":
                    var addEmployeeForm = new AddEmployeeForm();
                    addEmployeeForm.ShowDialog();
                    while (!addEmployeeForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Животные":
                    var addAnimalForm = new AddAnimalForm();
                    addAnimalForm.ShowDialog();
                    while (!addAnimalForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Виды процедуры":
                    var addProcedureTypeForm = new AddProcedureTypeForm();
                    addProcedureTypeForm.ShowDialog();
                    while (!addProcedureTypeForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Должности":
                    var addPositionForm = new AddPositionForm();
                    addPositionForm.ShowDialog();
                    while (!addPositionForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Классы животных":
                    var addAnimalClassForm = new AddAnimalClassForm();
                    addAnimalClassForm.ShowDialog();
                    while (!addAnimalClassForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Вида животных":
                    var addAnimalTypeForm = new AddAnimalTypeForm();
                    addAnimalTypeForm.ShowDialog();
                    while (!addAnimalTypeForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Районы":
                    var addDistrictForm = new AddDistrictForm();
                    addDistrictForm.ShowDialog();
                    while (!addDistrictForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Типы собственности":
                    var addOwnershipForm = new AddOwnershipTypeForm();
                    addOwnershipForm.ShowDialog();
                    while (!addOwnershipForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Лицензии":
                    var addLicenseForm = new AddLicenseForm();
                    addLicenseForm.ShowDialog();
                    while (!addLicenseForm.IsDisposed) { }
                    Refresh();
                    break;
            }
            
        }

        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var selectedRows = dataGridView1.SelectedRows;
            List<int> ids = new List<int>();
            switch (nameTable.Text)
            {
                case "Ветеринарные клиники":
                    for (var i = 0; i < selectedRows.Count; i++)
                    {
                        ids.Add((int)selectedRows[i].Cells["Код ветеринарной клинки"].Value);
                    }
                    Remover.RemoveVeterinaryClinic(ids);
                    Refresh();                                        
                    break;
                case "Владельцы":
                    for (var i = 0; i < selectedRows.Count; i++)
                    {
                        ids.Add((int)selectedRows[i].Cells["Код владельца"].Value);
                    }
                    Remover.RemoveOwner(ids);
                    Refresh();
                    break;
                case "Процедуры":
                    for (var i = 0; i < selectedRows.Count; i++)
                    {
                        ids.Add((int)selectedRows[i].Cells["Код процедуры"].Value);
                    }
                    Remover.RemoveProcedure(ids);
                    Refresh();
                    break;
                case "Сотрудники":
                    for (var i = 0; i < selectedRows.Count; i++)
                    {
                        ids.Add((int)selectedRows[i].Cells["Код сотрудника"].Value);
                    }
                    Remover.RemoveEmployee(ids);
                    Refresh();
                    break;
                case "Животные":
                    for (var i = 0; i < selectedRows.Count; i++)
                    {
                        ids.Add((int)selectedRows[i].Cells["Код животного"].Value);
                    }
                    Remover.RemoveAnimal(ids);
                    Refresh();
                    break;
                case "Виды процедуры":
                    for (var i = 0; i < selectedRows.Count; i++)
                    {
                        ids.Add((int)selectedRows[i].Cells["Код вида процедуры"].Value);
                    }
                    Remover.RemoveProcedureType(ids);
                    Refresh();
                    break;
                case "Должности":
                    for (var i = 0; i < selectedRows.Count; i++)
                    {
                        ids.Add((int)selectedRows[i].Cells["Код должности"].Value);
                    }
                    Remover.RemovePosition(ids);
                    Refresh();
                    break;
                case "Классы животных":
                    for (var i = 0; i < selectedRows.Count; i++)
                    {
                        ids.Add((int)selectedRows[i].Cells["Код класса животного"].Value);
                    }
                    Remover.RemoveAnimalClass(ids);
                    Refresh();
                    break;
                case "Виды животных":
                    for (var i = 0; i < selectedRows.Count; i++)
                    {
                        ids.Add((int)selectedRows[i].Cells["Код вида животного"].Value);
                    }
                    Remover.RemoveAnimalType(ids);
                    Refresh();
                    break;
                case "Районы":
                    for (var i = 0; i < selectedRows.Count; i++)
                    {
                        ids.Add((int)selectedRows[i].Cells["Код района"].Value);
                    }
                    Remover.RemoveDistrict(ids);
                    Refresh();
                    break;
                case "Типы собственности":
                    for (var i = 0; i < selectedRows.Count; i++)
                    {
                        ids.Add((int)selectedRows[i].Cells["Код типа собственности"].Value);
                    }
                    Remover.RemoveOwnership(ids);
                    Refresh();
                    break;
                case "Лицензии":
                    for (var i = 0; i < selectedRows.Count; i++)
                    {
                        ids.Add((int)selectedRows[i].Cells["Код лицензии"].Value);
                    }
                    Remover.RemoveLicense(ids);
                    Refresh();
                    break;
                default:
                    break;
            }           
        }
        /// <summary>
        /// Изменение записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {           
            switch (nameTable.Text)
            {
                case "Ветеринарные клиники":
                    var selectedRow = dataGridView1.SelectedRows[0];
                    EditForm editForm = new EditForm(selectedRow);
                    editForm.ShowDialog();
                    while (!editForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Владельцы":
                    var selectedOwnerRow = dataGridView1.SelectedRows[0];
                    EditOwnerForm editOwnerForm = new EditOwnerForm(selectedOwnerRow);
                    editOwnerForm.ShowDialog();
                    while (!editOwnerForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Процедуры":
                    var selectedProcedureRow = dataGridView1.SelectedRows[0];
                    EditProcedureForm editProcedureForm = new EditProcedureForm(selectedProcedureRow);
                    editProcedureForm.ShowDialog();
                    while (!editProcedureForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Сотрудники":
                    var selectedEmployeeRow = dataGridView1.SelectedRows[0];
                    EditEmployeeForm editEmployeeForm = new EditEmployeeForm(selectedEmployeeRow);
                    editEmployeeForm.ShowDialog();
                    while (!editEmployeeForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Животные":
                    var selectedAnimalRow = dataGridView1.SelectedRows[0];
                    EditAnimalForm editAnimalForm = new EditAnimalForm(selectedAnimalRow);
                    editAnimalForm.ShowDialog();
                    while (!editAnimalForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Виды процедуры":
                    var selectedProcedureTypeRow = dataGridView1.SelectedRows[0];
                    EditProcedureTypeForm editProcedureTypeForm = new EditProcedureTypeForm(selectedProcedureTypeRow);
                    editProcedureTypeForm.ShowDialog();
                    while (!editProcedureTypeForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Должности":
                    var selectedPositionRow = dataGridView1.SelectedRows[0];
                    EditPositionForm editConditionForm = new EditPositionForm(selectedPositionRow);
                    editConditionForm.ShowDialog();
                    while (!editConditionForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Классы животных":
                    var selectedAnimalClassRow = dataGridView1.SelectedRows[0];
                    EditAnimalClassForm editAnimalClassForm = new EditAnimalClassForm(selectedAnimalClassRow);
                    editAnimalClassForm.ShowDialog();
                    while (!editAnimalClassForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Виды животных":
                    var selectedAnimalTypeRow = dataGridView1.SelectedRows[0];
                    EditAnimalTypeForm editAnimalTypeForm = new EditAnimalTypeForm(selectedAnimalTypeRow);
                    editAnimalTypeForm.ShowDialog();
                    while (!editAnimalTypeForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Районы":
                    var selectedDistrictRow = dataGridView1.SelectedRows[0];
                    EditDistrictForm editDistrictForm = new EditDistrictForm(selectedDistrictRow);
                    editDistrictForm.ShowDialog();
                    while (!editDistrictForm.IsDisposed) { }
                    Refresh();
                    break;
                case "Типы собственности":
                    var selectedOwnershipRow = dataGridView1.SelectedRows[0];
                    EditOwnershipTypeForm editOwnershipForm = new EditOwnershipTypeForm(selectedOwnershipRow);
                    editOwnershipForm.ShowDialog();
                    while (!editOwnershipForm.IsDisposed) { }
                    Refresh();
                    break;
                default:
                    break;
            }           
        }

        private void TableForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Метод обновления компонента DataGridView
        /// </summary>
        /// <returns></returns>
        private void Refresh()
        {
            switch (nameTable.Text)
            {
                case "Ветеринарные клиники":
                    var dataTable = Refresher.RefreshVeterinaryClinic();
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Invalidate();
                    counter.Text = "" + (dataGridView1.RowCount);
                    break;
                case "Владельцы":
                    var dataTableOwner = Refresher.RefreshOwner();
                    dataGridView1.DataSource = dataTableOwner;
                    dataGridView1.Invalidate();
                    counter.Text = "" + (dataGridView1.RowCount);
                    break;
                case "Процедуры":
                    var dataTableProcedure = Refresher.RefreshProcedure();
                    dataGridView1.DataSource = dataTableProcedure;
                    dataGridView1.Invalidate();
                    counter.Text = "" + (dataGridView1.RowCount);
                    break;
                case "Сотрудники":
                    var dataTableEmployee = Refresher.RefreshEmployee();
                    dataGridView1.DataSource = dataTableEmployee;
                    dataGridView1.Invalidate();
                    counter.Text = "" + (dataGridView1.RowCount);
                    break;
                case "Животные":
                    var dataTableAnimal = Refresher.RefreshAnimal();
                    dataGridView1.DataSource = dataTableAnimal;
                    dataGridView1.Invalidate();
                    counter.Text = "" + (dataGridView1.RowCount);
                    break;
                case "Виды процедуры":
                    var dataTableProcedureType = Refresher.RefreshProcedureType();
                    dataGridView1.DataSource = dataTableProcedureType;
                    dataGridView1.Invalidate();
                    counter.Text = "" + (dataGridView1.RowCount);
                    break;
                case "Должности":
                    var dataTablePosition = Refresher.RefreshPosition();
                    dataGridView1.Invalidate();
                    counter.Text = "" + (dataGridView1.RowCount);
                    break;
                case "Классы животных":
                    var dataTableAnimalClass = Refresher.RefreshAnimalClass();
                    dataGridView1.Invalidate();
                    counter.Text = "" + (dataGridView1.RowCount);
                    break;
                case "Виды животных":
                    var dataTableAnimalType = Refresher.RefreshAnimalType();
                    dataGridView1.Invalidate();
                    counter.Text = "" + (dataGridView1.RowCount);
                    break;
                case "Районы":
                    var dataTableDistrict = Refresher.RefreshDistrict();
                    dataGridView1.Invalidate();
                    counter.Text = "" + (dataGridView1.RowCount);
                    break;
                case "Типы собственности":
                    var dataTableOwnership = Refresher.RefreshDistrict();
                    dataGridView1.Invalidate();
                    counter.Text = "" + (dataGridView1.RowCount);
                    break;
                case "Лицензии":
                    var dataTableLicense = Refresher.RefreshLicense();
                    dataGridView1.Invalidate();
                    counter.Text = "" + (dataGridView1.RowCount);
                    break;
                default:
                    break; 
            }
        }

        
    }
}
