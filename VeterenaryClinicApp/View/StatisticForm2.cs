﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace VeterenaryClinicApp
{
    public partial class StatisticForm2 : Form
    {
        public StatisticForm2()
        {
            InitializeComponent();
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
                chart2.Series[0].Points.AddXY(item.ClinicName, item.ProcedureCount);
            }

            // Добавление серии на график
            //chart1.Series.Add(series);

            // Настройка осей
            chart2.ChartAreas[0].AxisX.Interval = 1;
            chart2.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            // Отображение графика
            chart2.Show();
        }
    }
}
