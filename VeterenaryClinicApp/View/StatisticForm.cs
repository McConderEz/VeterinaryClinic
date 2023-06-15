using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using VeterenaryClinicApp.Model;
using Row = DocumentFormat.OpenXml.Spreadsheet.Row;

namespace VeterenaryClinicApp
{
    public partial class StatisticForm : Form
    {
        public StatisticForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.White;
        }

        private void StatisticForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            var table = new DataTable();
            string sql = @"
                WITH cte AS (
                    SELECT
                        [Ветеринарные клиники].[Название пункта],
                        [Районы].[Район города],
                        [Сотрудники].[Код ветеринарной клиники],
                        COUNT(*) AS Количество_процедур,
                        DENSE_RANK() OVER (PARTITION BY [Районы].[Район города] ORDER BY COUNT(*) DESC, [Ветеринарные клиники].[Название пункта]) AS Ранг_по_району,
                        ROW_NUMBER() OVER (ORDER BY COUNT(*) DESC, [Ветеринарные клиники].[Название пункта]) AS Ранг_по_городу
                    FROM [dbo].[Процедуры]
                    INNER JOIN [dbo].[Сотрудники] ON [Процедуры].[Код сотрудника] = [Сотрудники].[Код сотрудника]
                    INNER JOIN [dbo].[Ветеринарные клиники] ON [Сотрудники].[Код ветеринарной клиники] = [Ветеринарные клиники].[Код ветеринарной клинки]
                    INNER JOIN [dbo].[Районы] ON [Ветеринарные клиники].[Код район города] = [Районы].[Код района]
                    GROUP BY
                        [Ветеринарные клиники].[Название пункта],
                        [Районы].[Район города],
                        [Сотрудники].[Код ветеринарной клиники]
                )
                SELECT
                    cte1.[Район города],
                    STUFF((SELECT ', ' + [Название пункта]
                           FROM cte
                           WHERE [Район города] = cte1.[Район города] AND [Ранг_по_району] = 1
                           FOR XML PATH('')), 1, 2, '') AS [Лучшие пункты по району],
                    STUFF((SELECT TOP 3 ', ' + [Название пункта] + ' (' + CAST([Количество_процедур] AS VARCHAR) + ')'
                           FROM cte
                           WHERE [Ранг_по_городу] <= 3
                           ORDER BY [Ранг_по_городу]
                           FOR XML PATH('')), 1, 2, '') AS [Топ 3 лучших пункта по городу],
                    cte1.[Количество_процедур]
                FROM
                    cte AS cte1
                WHERE
                    cte1.[Ранг_по_району] = 1
                GROUP BY
                    cte1.[Район города], cte1.[Количество_процедур]";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);

            var list = table.AsEnumerable().Select(row => new VeterinaryClinicStat
            {
                ClinicName = row.Field<string>("Лучшие пункты по району").Trim(' '),
                ProcedureCount = row.Field<int>("Количество_процедур"),
                District = row.Field<string>("Район города").Trim(' ')
            }).ToList();
            foreach (var item in list)
            {
                chart1.Series[0].Points.AddXY(item.ClinicName, item.ProcedureCount);
            }

            // Добавление серии на график
            //chart1.Series.Add(series);

            // Настройка осей
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;           
            // Отображение графика
            chart1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            var table = new DataTable();
            string sql = @"
                WITH cte AS (
                    SELECT
                        [Ветеринарные клиники].[Название пункта],
                        [Районы].[Район города],
                        [Сотрудники].[Код ветеринарной клиники],
                        COUNT(*) AS Количество_процедур,
                        DENSE_RANK() OVER (PARTITION BY [Районы].[Район города] ORDER BY COUNT(*) DESC, [Ветеринарные клиники].[Название пункта]) AS Ранг_по_району,
                        ROW_NUMBER() OVER (ORDER BY COUNT(*) DESC, [Ветеринарные клиники].[Название пункта]) AS Ранг_по_городу
                    FROM [dbo].[Процедуры]
                    INNER JOIN [dbo].[Сотрудники] ON [Процедуры].[Код сотрудника] = [Сотрудники].[Код сотрудника]
                    INNER JOIN [dbo].[Ветеринарные клиники] ON [Сотрудники].[Код ветеринарной клиники] = [Ветеринарные клиники].[Код ветеринарной клинки]
                    INNER JOIN [dbo].[Районы] ON [Ветеринарные клиники].[Код район города] = [Районы].[Код района]
                    GROUP BY
                        [Ветеринарные клиники].[Название пункта],
                        [Районы].[Район города],
                        [Сотрудники].[Код ветеринарной клиники]
                )
                SELECT
                    cte1.[Район города],
                    STUFF((SELECT ', ' + [Название пункта]
                           FROM cte
                           WHERE [Район города] = cte1.[Район города] AND [Ранг_по_району] = 1
                           FOR XML PATH('')), 1, 2, '') AS [Лучшие пункты по району],
                    STUFF((SELECT TOP 3 ', ' + [Название пункта] + ' (' + CAST([Количество_процедур] AS VARCHAR) + ')'
                           FROM cte
                           WHERE [Ранг_по_городу] <= 3
                           ORDER BY [Ранг_по_городу]
                           FOR XML PATH('')), 1, 2, '') AS [Топ 3 лучших пункта по городу],
                    cte1.[Количество_процедур]
                FROM
                    cte AS cte1
                WHERE
                    cte1.[Ранг_по_району] = 1
                GROUP BY
                    cte1.[Район города], cte1.[Количество_процедур]";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create("output.xlsx", SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

                Sheet sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
                sheets.Append(sheet);

                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                // Заполнение первой строки заголовками
                Row headerRow = new Row();
                foreach (DataColumn column in table.Columns)
                {
                    Cell cell = new Cell() { DataType = CellValues.String, CellValue = new CellValue(column.ColumnName) };
                    headerRow.AppendChild(cell);
                }
                sheetData.AppendChild(headerRow);

                // Заполнение строк данными из таблицы
                foreach (DataRow row in table.Rows)
                {
                    Row dataRow = new Row();
                    foreach (DataColumn column in table.Columns)
                    {
                        Cell cell = new Cell() { DataType = CellValues.String, CellValue = new CellValue(row[column].ToString()) };
                        dataRow.AppendChild(cell);
                    }
                    sheetData.AppendChild(dataRow);
                }

                workbookPart.Workbook.Save();
            }

        }
    }

    class VeterinaryClinicStat
    {
        public string ClinicName { get; set; }
        public int ProcedureCount { get; set; }
        public string District { get; set; }

        public VeterinaryClinicStat()
        {

        }
    }
}
