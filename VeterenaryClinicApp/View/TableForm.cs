using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
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

        bool flag = false;

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
            try
            {
                flag = false;
                var selectedRows = dataGridView1.SelectedRows;
                List<int> ids = new List<int>();
                switch (nameTable.Text)
                {
                    case "Ветеринарные клиники":
                        for (var i = 0; i < selectedRows.Count; i++)
                        {
                            ids.Add((int)selectedRows[i].Cells["Код ветеринарной клинки"].Value);
                        }
                        (int, int) countRemoveVetClinic = Remover.CountRemoveVeterinaryClinic(ids);

                        DialogResult resultVetClinic = MessageBox.Show($"Будут удалены также записи из следующих таблиц:\nСотрудники - {countRemoveVetClinic.Item1}" +
                            $"\nЛицензии - {countRemoveVetClinic.Item2}\nПродолжить?", "Каскадное удаление", MessageBoxButtons.YesNo);
                        if (resultVetClinic == DialogResult.No)
                        {
                            return;
                        }

                        Remover.RemoveVeterinaryClinic(ids);
                        Refresh();
                        break;
                    case "Владельцы":
                        for (var i = 0; i < selectedRows.Count; i++)
                        {
                            ids.Add((int)selectedRows[i].Cells["Код владельца"].Value);
                        }
                        int countRemoveOwner = Remover.CountRemoveOwner(ids);

                        DialogResult resultOwner = MessageBox.Show($"Будут удалены также записи из следующих таблиц:\nЖивотные - {countRemoveOwner}" +
                            $"\nПродолжить?", "Каскадное удаление", MessageBoxButtons.YesNo);
                        if (resultOwner == DialogResult.No)
                        {
                            return;
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
                        int countRemoveEmployee = Remover.CountRemoveEmployee(ids);

                        DialogResult resultEmployee = MessageBox.Show($"Будут удалены также записи из следующих таблиц:\nПроцедуры - {countRemoveEmployee}" +
                            $"\nПродолжить?", "Каскадное удаление", MessageBoxButtons.YesNo);
                        if (resultEmployee == DialogResult.No)
                        {
                            return;
                        }
                        Remover.RemoveEmployee(ids);
                        Refresh();
                        break;
                    case "Животные":
                        for (var i = 0; i < selectedRows.Count; i++)
                        {
                            ids.Add((int)selectedRows[i].Cells["Код животного"].Value);
                        }
                        int countRemoveAnimal = Remover.CountRemoveAnimal(ids);

                        DialogResult resultAnimal = MessageBox.Show($"Будут удалены также записи из следующих таблиц:\nПроцедуры - {countRemoveAnimal}" +
                            $"\nПродолжить?", "Каскадное удаление", MessageBoxButtons.YesNo);
                        if (resultAnimal == DialogResult.No)
                        {
                            return;
                        }
                        Remover.RemoveAnimal(ids);
                        Refresh();
                        break;
                    case "Виды процедуры":
                        for (var i = 0; i < selectedRows.Count; i++)
                        {
                            ids.Add((int)selectedRows[i].Cells["Код вида процедуры"].Value);
                        }
                        int countRemoveProcedureType = Remover.CountRemoveProcedureType(ids);

                        DialogResult resultProcedureType = MessageBox.Show($"Будут удалены также записи из следующих таблиц:\nПроцедуры - {countRemoveProcedureType}" +
                            $"\nПродолжить?", "Каскадное удаление", MessageBoxButtons.YesNo);
                        if (resultProcedureType == DialogResult.No)
                        {
                            return;
                        }
                        Remover.RemoveProcedureType(ids);
                        Refresh();
                        break;
                    case "Должности":
                        for (var i = 0; i < selectedRows.Count; i++)
                        {
                            ids.Add((int)selectedRows[i].Cells["Код должности"].Value);
                        }
                        (int, int) countRemovePosition = Remover.CountRemovePosition(ids);

                        DialogResult resultPosition = MessageBox.Show($"Будут удалены также записи из следующих таблиц:\nСотрудники - {countRemovePosition.Item1}" +
                            $"\nПроцедуры - {countRemovePosition.Item2}\nПродолжить?", "Каскадное удаление", MessageBoxButtons.YesNo);
                        if (resultPosition == DialogResult.No)
                        {
                            return;
                        }
                        Remover.RemovePosition(ids);
                        Refresh();
                        break;
                    case "Классы животных":
                        for (var i = 0; i < selectedRows.Count; i++)
                        {
                            ids.Add((int)selectedRows[i].Cells["Код класса животного"].Value);
                        }
                        (int, int, int) countRemoveAnimalClass= Remover.CountRemoveAnimalClass(ids);

                        DialogResult resultAnimalClass = MessageBox.Show($"Будут удалены также записи из следующих таблиц:\nВиды животных - {countRemoveAnimalClass.Item1}\n" +
                            $"Животные - {countRemoveAnimalClass.Item2}" +
                            $"\nПроцедуры - {countRemoveAnimalClass.Item3}" +
                            $"\nПродолжить?", "Каскадное удаление", MessageBoxButtons.YesNo);
                        if (resultAnimalClass == DialogResult.No)
                        {
                            return;
                        }
                        Remover.RemoveAnimalClass(ids);
                        Refresh();
                        break;
                    case "Виды животных":
                        for (var i = 0; i < selectedRows.Count; i++)
                        {
                            ids.Add((int)selectedRows[i].Cells["Код вида животного"].Value);
                        }
                        (int, int) countRemoveAnimalType = Remover.CountRemoveAnimalType(ids);

                        DialogResult resultAnimalType = MessageBox.Show($"Будут удалены также записи из следующих таблиц:\nЖивотные - {countRemoveAnimalType.Item1}" +
                            $"\nПроцедуры - {countRemoveAnimalType.Item2}\nПродолжить?", "Каскадное удаление", MessageBoxButtons.YesNo);
                        if (resultAnimalType == DialogResult.No)
                        {
                            return;
                        }
                        Remover.RemoveAnimalType(ids);
                        Refresh();
                        break;
                    case "Районы":
                        for (var i = 0; i < selectedRows.Count; i++)
                        {
                            ids.Add((int)selectedRows[i].Cells["Код района"].Value);
                        }
                        (int, int, int) countRemoveDistrict = Remover.CountRemoveDistrict(ids);

                        DialogResult resultDistrict = MessageBox.Show($"Будут удалены также записи из следующих таблиц:\nВетеринарные клиники - {countRemoveDistrict.Item1}\n" +
                            $"Сотрудники - {countRemoveDistrict.Item2}" +
                            $"\nЛицензии - {countRemoveDistrict.Item3}" +
                            $"\nПродолжить?", "Каскадное удаление", MessageBoxButtons.YesNo);
                        if (resultDistrict == DialogResult.No)
                        {
                            return;
                        }
                        Remover.RemoveDistrict(ids);
                        Refresh();
                        break;
                    case "Типы собственности":
                        for (var i = 0; i < selectedRows.Count; i++)
                        {
                            ids.Add((int)selectedRows[i].Cells["Код типа собственности"].Value);
                        }

                        (int, int, int) countRemoveOwnershipType = Remover.CountRemoveOwnershipType(ids);

                        DialogResult resultOwnershipType = MessageBox.Show($"Будут удалены также записи из следующих таблиц:\nВетеринарные клиники - {countRemoveOwnershipType.Item1}" +
                            $"\nСотрудники - {countRemoveOwnershipType.Item2}\n" +
                            $"Лицензии - {countRemoveOwnershipType.Item3}" +
                            $"\nПродолжить?", "Каскадное удаление", MessageBoxButtons.YesNo);
                        if (resultOwnershipType == DialogResult.No)
                        {
                            return;
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
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}\nВероятно вы не правильно выделили запись для удаление, попробуйте ещё раз.");
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
                case "Лицензии":
                    var selectedLicenseRow = dataGridView1.SelectedRows[0];
                    EditLicenseForm editLicenseForm = new EditLicenseForm(selectedLicenseRow);
                    editLicenseForm.ShowDialog();
                    while (!editLicenseForm.IsDisposed) { }
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
                    dataGridView1.DataSource = dataTablePosition;
                    dataGridView1.Invalidate();
                    counter.Text = "" + (dataGridView1.RowCount);
                    break;
                case "Классы животных":
                    var dataTableAnimalClass = Refresher.RefreshAnimalClass();
                    dataGridView1.DataSource = dataTableAnimalClass;
                    dataGridView1.Invalidate();
                    counter.Text = "" + (dataGridView1.RowCount);
                    break;
                case "Виды животных":
                    var dataTableAnimalType = Refresher.RefreshAnimalType();
                    dataGridView1.DataSource = dataTableAnimalType;
                    dataGridView1.Invalidate();
                    counter.Text = "" + (dataGridView1.RowCount);
                    break;
                case "Районы":
                    var dataTableDistrict = Refresher.RefreshDistrict();
                    dataGridView1.DataSource = dataTableDistrict;
                    dataGridView1.Invalidate();
                    counter.Text = "" + (dataGridView1.RowCount);
                    break;
                case "Типы собственности":
                    var dataTableOwnership = Refresher.RefreshDistrict();
                    dataGridView1.DataSource = dataTableOwnership;
                    dataGridView1.Invalidate();
                    counter.Text = "" + (dataGridView1.RowCount);
                    break;
                case "Лицензии":
                    var dataTableLicense = Refresher.RefreshLicense();
                    dataGridView1.DataSource = dataTableLicense;
                    dataGridView1.Invalidate();
                    counter.Text = "" + (dataGridView1.RowCount);
                    break;
                default:
                    break; 
            }
        }

        
    }
}
