﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace VeterenaryClinicApp.Controller
{
    internal class RequestsExecuter
    {
        /// <summary>
        /// Учёт сотрудников по должности
        /// </summary>
        /// <returns></returns>
        public static DataTable Request_1(string valueBox)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            var table = new DataTable();
           
            string sql = "SELECT [Veterinary Clinic].[dbo].[Сотрудники].[Код сотрудника]," +
"[Veterinary Clinic].[dbo].[Сотрудники].[Имя]," +
"[Veterinary Clinic].[dbo].[Сотрудники].[Фамилия]," +
"[Veterinary Clinic].[dbo].[Сотрудники].[Отчество]," +
"[Veterinary Clinic].[dbo].[Сотрудники].[Дата рождения]," +
"[Veterinary Clinic].[dbo].[Должности].[Должность]," +
"[Veterinary Clinic].[dbo].[Сотрудники].[Стаж]," +
"[Veterinary Clinic].[dbo].[Сотрудники].[Оклад]," +
"[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Номер регистрационного пункта]," +
"[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта] FROM [Veterinary Clinic].[dbo].[Сотрудники]" +
"INNER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники] ON ([Veterinary Clinic].[dbo].[Сотрудники].[Код ветеринарной клиники]) = [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]" +
$"INNER JOIN [Veterinary Clinic].[dbo].[Должности] ON ([Veterinary Clinic].[dbo].[Сотрудники].[Код должности]) = [Veterinary Clinic].[dbo].[Должности].[Код должности]  WHERE [Veterinary Clinic].[dbo].[Должности].[Должность] = N'{valueBox}'";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Ветеринарные клиники в определённом районе
        /// </summary>
        /// <returns></returns>
        public static DataTable Request_2(string valueBox)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            var table = new DataTable();

            string sql = "SELECT [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Номер регистрационного пункта]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Год открытия]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Адрес пункта]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта]," +
                "[Veterinary Clinic].[dbo].[Районы].[Район города]," +
                "[Veterinary Clinic].[dbo].[Тип собственности].[Тип собственности]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Телефон] FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники]" +
            "INNER JOIN [Veterinary Clinic].[dbo].[Тип собственности] ON ([Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код типа собственности]) = [Veterinary Clinic].[dbo].[Тип собственности].[Код типа собственности]" +
            $"INNER JOIN [Veterinary Clinic].[dbo].[Районы] ON ([Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код район города]) = [Veterinary Clinic].[dbo].[Районы].[Код района] WHERE [Veterinary Clinic].[dbo].[Районы].[Район города] = N'{valueBox}'";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Процедуры оказанные в опред. дату
        /// </summary>
        /// <returns></returns>
        public static DataTable Request_3(string valueBox)
        {
            DateTime dateValue;
            if (DateTime.TryParse(valueBox, out dateValue))
            {
                string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                var table = new DataTable();
                string date = $"{dateValue.Month}-{dateValue.Day}-{dateValue.Year}";
                string sql = "SELECT [Veterinary Clinic].[dbo].[Процедуры].[Код процедуры]," +
                    "[Veterinary Clinic].[dbo].[Процедуры].[Дата оказания помощи животному]," +
                    "[Veterinary Clinic].[dbo].[Процедуры].[Цена процедуры]," +
                    "[Veterinary Clinic].[dbo].[Процедуры].[Скидка на эту процедуру]," +
                    "[Veterinary Clinic].[dbo].[Процедуры].[Цена материала по этой процедуре]," +
                    "[Veterinary Clinic].[dbo].[Сотрудники].[Фамилия]," +
                    "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного]," +
                    "[Veterinary Clinic].[dbo].[Виды процедуры].[Вид процедуры] FROM [Veterinary Clinic].[dbo].[Процедуры]" +
                    "INNER JOIN [Veterinary Clinic].[dbo].[Сотрудники] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код сотрудника]) = [Veterinary Clinic].[dbo].[Сотрудники].[Код сотрудника]" +
                    "INNER JOIN [Veterinary Clinic].[dbo].[Животные] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код животного]) = [Veterinary Clinic].[dbo].[Животные].[Код животного] " +
                    "INNER JOIN [Veterinary Clinic].[dbo].[Виды животных] ON ([Veterinary Clinic].[dbo].[Животные].[Код вида животного]) = [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного] " +
                    $"INNER JOIN [Veterinary Clinic].[dbo].[Виды процедуры] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код вида процедуры]) = [Veterinary Clinic].[dbo].[Виды процедуры].[Код вида процедуры] WHERE [Дата оказания помощи животному] = '{date}'";
                SqlCommand command = new SqlCommand(sql, myConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);

                return table;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Сотрудники, родившиеся в опред. дату
        /// </summary>
        /// <returns></returns>
        public static DataTable Request_4(string valueBox)
        {
            DateTime dateValue;
            if (DateTime.TryParse(valueBox, out dateValue))
            {
                string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                var table = new DataTable();
                string date = $"{dateValue.Month}-{dateValue.Day}-{dateValue.Year}";
                string sql = "SELECT [Veterinary Clinic].[dbo].[Сотрудники].[Код сотрудника]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Имя]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Фамилия]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Отчество]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Дата рождения]," +
                "[Veterinary Clinic].[dbo].[Должности].[Должность]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Стаж]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Оклад]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта] FROM [Veterinary Clinic].[dbo].[Сотрудники]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники] ON ([Veterinary Clinic].[dbo].[Сотрудники].[Код ветеринарной клиники]) = [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]" +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Должности] ON ([Veterinary Clinic].[dbo].[Сотрудники].[Код должности]) = [Veterinary Clinic].[dbo].[Должности].[Код должности] WHERE [Дата рождения] = '{date}'";
                SqlCommand command = new SqlCommand(sql, myConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);

                return table;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Ветеринарыне клиники
        /// </summary>
        /// <returns></returns>
        public static DataTable Request_5()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            var table = new DataTable();

            string sql = "SELECT [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Номер регистрационного пункта]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Год открытия]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Адрес пункта]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта]," +
                "[Veterinary Clinic].[dbo].[Районы].[Район города]," +
                "[Veterinary Clinic].[dbo].[Тип собственности].[Тип собственности]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Телефон] FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники]" +
            "INNER JOIN [Veterinary Clinic].[dbo].[Тип собственности] ON ([Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код типа собственности]) = [Veterinary Clinic].[dbo].[Тип собственности].[Код типа собственности]" +
            "INNER JOIN [Veterinary Clinic].[dbo].[Районы] ON ([Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код район города]) = [Veterinary Clinic].[dbo].[Районы].[Код района]";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Сотрудники
        /// </summary>
        /// <returns></returns>
        public static DataTable Request_6()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            var table = new DataTable();

            string sql = "SELECT [Veterinary Clinic].[dbo].[Сотрудники].[Код сотрудника]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Имя]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Фамилия]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Отчество]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Дата рождения]," +
                "[Veterinary Clinic].[dbo].[Должности].[Должность]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Стаж]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Оклад]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Номер регистрационного пункта]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта] FROM [Veterinary Clinic].[dbo].[Сотрудники]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники] ON ([Veterinary Clinic].[dbo].[Сотрудники].[Код ветеринарной клиники]) = [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Должности] ON ([Veterinary Clinic].[dbo].[Сотрудники].[Код должности]) = [Veterinary Clinic].[dbo].[Должности].[Код должности]";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Процедуры
        /// </summary>
        /// <returns></returns>
        public static DataTable Request_7()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            var table = new DataTable();

            string sql = "SELECT [Veterinary Clinic].[dbo].[Процедуры].[Код процедуры]," +
                "[Veterinary Clinic].[dbo].[Процедуры].[Дата оказания помощи животному]," +
                "[Veterinary Clinic].[dbo].[Процедуры].[Цена процедуры]," +
                "[Veterinary Clinic].[dbo].[Процедуры].[Скидка на эту процедуру]," +
                "[Veterinary Clinic].[dbo].[Процедуры].[Цена материала по этой процедуре]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Имя]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Фамилия]," +
                "[Veterinary Clinic].[dbo].[Сотрудники].[Отчество]," +
                "[Veterinary Clinic].[dbo].[Животные].[Кличка животного]," +
                "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного]," +
                "[Veterinary Clinic].[dbo].[Виды процедуры].[Вид процедуры] FROM [Veterinary Clinic].[dbo].[Процедуры]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Сотрудники] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код сотрудника]) = [Veterinary Clinic].[dbo].[Сотрудники].[Код сотрудника]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Животные] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код животного]) = [Veterinary Clinic].[dbo].[Животные].[Код животного] " +
                "INNER JOIN [Veterinary Clinic].[dbo].[Виды животных] ON ([Veterinary Clinic].[dbo].[Животные].[Код вида животного]) = [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного] " +
                "INNER JOIN [Veterinary Clinic].[dbo].[Виды процедуры] ON ([Veterinary Clinic].[dbo].[Процедуры].[Код вида процедуры]) = [Veterinary Clinic].[dbo].[Виды процедуры].[Код вида процедуры] ";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Районы, в которых нет вет. клиник
        /// </summary>
        /// <returns></returns>
        public static DataTable Request_8()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            var table = new DataTable();

            string sql = @"
         SELECT [Район города] 
         FROM [Veterinary Clinic].[dbo].[Районы]     
         LEFT OUTER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники]             
           ON [Veterinary Clinic].[dbo].[Районы].[Код района] = [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код район города]
         WHERE [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки] IS NULL";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Сотрудники, не делавшие процедур
        /// </summary>
        /// <returns></returns>
        public static DataTable Request_9()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            var table = new DataTable();
            string sql = "SELECT [Сотрудники].[Код сотрудника], [Сотрудники].[Имя], [Сотрудники].[Фамилия], [Сотрудники].[Отчество],[Должности].[Должность],[Ветеринарные клиники].[Название пункта]" +
                "FROM [Процедуры]" +
                "RIGHT JOIN [Сотрудники]" +
                "ON [Сотрудники].[Код сотрудника] = [Процедуры].[Код сотрудника]" +
                "INNER JOIN [Должности]" +
                "ON [Сотрудники].[Код должности] = [Должности].[Код должности]" +
                "INNER JOIN [Ветеринарные клиники]" +
                "ON [Сотрудники].[Код ветеринарной клиники] = [Ветеринарные клиники].[Код ветеринарной клинки]" +
                "WHERE [Процедуры].[Код процедуры] IS NULL";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Сотрудники, не делавшие процедур опред. даты
        /// </summary>
        /// <returns></returns>
        public static DataTable Request_10(string valueBox)
        {
            
            DateTime dateValue;
            if (DateTime.TryParse(valueBox, out dateValue))
            {
                string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                var table = new DataTable();
                string date = $"{dateValue.Month}-{dateValue.Day}-{dateValue.Year}";
                string sql = $@"
   SELECT [Сотрудники].[Код сотрудника], [Сотрудники].[Имя], [Сотрудники].[Фамилия], [Сотрудники].[Отчество],[Должности].[Должность],[Ветеринарные клиники].[Название пункта],
[Сотрудники].[Стаж],[Сотрудники].[Оклад],[Ветеринарные клиники].[Номер регистрационного пункта],[Сотрудники].[Дата рождения]
   FROM [Veterinary Clinic].[dbo].[Сотрудники] AS Сотрудники
    INNER JOIN [Должности]
      ON [Сотрудники].[Код должности] = [Должности].[Код должности]
      INNER JOIN [Ветеринарные клиники]
      ON [Сотрудники].[Код ветеринарной клиники] = [Ветеринарные клиники].[Код ветеринарной клинки]
   LEFT JOIN [Veterinary Clinic].[dbo].[Процедуры] AS Процедуры 
      ON Сотрудники.[Код сотрудника] = Процедуры.[Код сотрудника]
      AND Процедуры.[Дата оказания помощи животному] = '{date}'  
   WHERE Процедуры.[Код процедуры] IS NULL ";
                SqlCommand command = new SqlCommand(sql, myConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);

                return table;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Количество проведённых процедур всего и в каждом районе
        /// </summary>
        /// <returns></returns>
        public static DataTable Request_11()
        {

            
                string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                var table = new DataTable();
                
                string sql = @"
SELECT
    [Veterinary Clinic].[dbo].[Районы].[Район города],
    COUNT([Veterinary Clinic].[dbo].[Процедуры].[Код процедуры]) AS [Количество процедур]
FROM [Veterinary Clinic].[dbo].[Процедуры]
INNER JOIN [Veterinary Clinic].[dbo].[Сотрудники]
    ON [Veterinary Clinic].[dbo].[Процедуры].[Код сотрудника] = [Veterinary Clinic].[dbo].[Сотрудники].[Код сотрудника]
INNER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники]
    ON [Veterinary Clinic].[dbo].[Сотрудники].[Код ветеринарной клиники] = [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]
INNER JOIN [Veterinary Clinic].[dbo].[Районы]
    ON [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код район города] = [Veterinary Clinic].[dbo].[Районы].[Код района]
GROUP BY [Veterinary Clinic].[dbo].[Районы].[Район города]
UNION ALL
SELECT N'Общее количество процедур', COUNT([Veterinary Clinic].[dbo].[Процедуры].[Код процедуры])
FROM [Veterinary Clinic].[dbo].[Процедуры]";
            SqlCommand command = new SqlCommand(sql, myConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                table = new DataTable();            
                adapter.Fill(table);

                return table;
            
            
        }

        /// <summary>
        /// Количество сотрудников в ветеринарных клиниках с окладом больше указанного
        /// </summary>
        /// <returns></returns>
        public static DataTable Request_12(string valueBox)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            var table = new DataTable();
            string sql = $@"SELECT [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта],
                        COUNT(*) AS 'Количество сотрудников'
                 FROM [Veterinary Clinic].[dbo].[Сотрудники]
                 INNER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники]
                     ON [Veterinary Clinic].[dbo].[Сотрудники].[Код ветеринарной клиники] = [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]
                 WHERE [Veterinary Clinic].[dbo].[Сотрудники].[Оклад] > {valueBox}
                 GROUP BY [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта]";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Ветеринарные клиники, где средний оклад сотрудников больше указанного
        /// </summary>
        /// <returns></returns>
        public static DataTable Request_13(string valueBox)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            var table = new DataTable();
            string sql = $@"SELECT [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта],
                        AVG([Veterinary Clinic].[dbo].[Сотрудники].[Оклад]) AS 'Средний оклад'
                 FROM [Veterinary Clinic].[dbo].[Сотрудники]
                 INNER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники]
                     ON [Veterinary Clinic].[dbo].[Сотрудники].[Код ветеринарной клиники] = [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]
                 GROUP BY [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта]
                 HAVING AVG([Veterinary Clinic].[dbo].[Сотрудники].[Оклад]) > {valueBox}";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Ветеринарные клиники, где суммарный оклад сотрудников на опред. должности выше указанного
        /// </summary>
        /// <returns></returns>
        public static DataTable Request_14(string valueBox,string positionBox)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            var table = new DataTable();
            string sql = $@"
                SELECT [Ветеринарные клиники].[Название пункта], 
                       SUM([Сотрудники].[Оклад]) as 'Суммарный оклад'
                FROM [Ветеринарные клиники]
                INNER JOIN [Сотрудники]  
                    ON [Сотрудники].[Код ветеринарной клиники] = 
                       [Ветеринарные клиники].[Код ветеринарной клинки]
                INNER JOIN [Должности]
                    ON [Сотрудники].[Код должности] = 
                       [Должности].[Код должности]     
                WHERE [Должности].[Должность] = N'{positionBox}' 
                GROUP BY [Ветеринарные клиники].[Название пункта] 
                HAVING SUM([Сотрудники].[Оклад]) > {valueBox}";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Количество сотрудников с минимальным окладом в каждой ветеринарной клинике
        /// </summary>
        /// <returns></returns>
        public static DataTable Request_15()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            var table = new DataTable();
            string sql = "SELECT [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта], COUNT(*) AS 'Количество сотрудников с мин. окладом' " +
                       "FROM [Veterinary Clinic].[dbo].[Сотрудники] " +
                       "INNER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники] ON ([Veterinary Clinic].[dbo].[Сотрудники].[Код ветеринарной клиники]) = [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки] " +
                       "WHERE [Veterinary Clinic].[dbo].[Сотрудники].[Оклад] = 5000 " +
                       "GROUP BY [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта]";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Ветеринарные клиники, которые находятся в районе Басманный
        /// </summary>
        /// <returns></returns>
        public static DataTable Request_16()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            var table = new DataTable();
            string sql = "SELECT [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки],[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта], " +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Адрес пункта],[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Номер регистрационного пункта]," +
                "[Veterinary Clinic].[dbo].[Районы].[Район города] " +
                       "FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники] " +
                       "JOIN [Veterinary Clinic].[dbo].[Районы] " +
                       "ON [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код район города] = [Veterinary Clinic].[dbo].[Районы].[Код района] " +
                       "WHERE [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код район города] = ( " +
                           "SELECT [Veterinary Clinic].[dbo].[Районы].[Код района] " +
                           "FROM [Veterinary Clinic].[dbo].[Районы] " +
                           "WHERE [Veterinary Clinic].[dbo].[Районы].[Район города] = N'Басманный' " +
                       ")";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Ветеринарные клиники, которые находятся вне района Басманный
        /// </summary>
        /// <returns></returns>
        public static DataTable Request_17()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            var table = new DataTable();
            string sql = "SELECT [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки],[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта], " +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Адрес пункта],[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Номер регистрационного пункта]," +
                "[Veterinary Clinic].[dbo].[Районы].[Район города]" +
                       "FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники] " +
                       "JOIN [Veterinary Clinic].[dbo].[Районы] " +
                       "ON [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код район города] = [Veterinary Clinic].[dbo].[Районы].[Код района] " +
                       "WHERE [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код район города] <> ( " +
                           "SELECT [Veterinary Clinic].[dbo].[Районы].[Код района] " +
                           "FROM [Veterinary Clinic].[dbo].[Районы] " +
                           "WHERE [Veterinary Clinic].[dbo].[Районы].[Район города] = N'Басманный' " +
                       ")";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Запрос для таблицы Ветеринарные клиники с использованием условия по значению (по коду ветеринарной клиники)
        /// </summary>
        /// <returns></returns>
        public static DataTable Request_18(string valueBox)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            var table = new DataTable();
            string sql = "SELECT [Код ветеринарной клинки], [Номер регистрационного пункта], [Год открытия], [Адрес пункта], [Название пункта], [Район города], [Тип собственности], [Телефон] " +
               "FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники] " +
               "INNER JOIN [Veterinary Clinic].[dbo].[Тип собственности] ON ([Ветеринарные клиники].[Код типа собственности]) = [Тип собственности].[Код типа собственности] " +
               "INNER JOIN [Veterinary Clinic].[dbo].[Районы] ON ([Ветеринарные клиники].[Код район города]) = [Районы].[Код района] " +
               $"WHERE [Код ветеринарной клинки] = {valueBox}";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Запрос для таблицы Процедуры с использованием индекса (по коду животного)
        /// </summary>
        /// <returns></returns>
        public static DataTable Request_20(string valueBox)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            //string createIndexQuery = "CREATE INDEX IX_Ветеринарные_клиники_Номер_регистрационного_пункта " +
            //              "ON dbo.[Ветеринарные клиники] ([Номер регистрационного пункта])";
            //SqlCommand createIndexCommand = new SqlCommand(createIndexQuery, myConnection);
            //createIndexCommand.ExecuteNonQuery();
            var table = new DataTable();
            string sql = "SELECT [Код ветеринарной клинки], [Номер регистрационного пункта], [Год открытия], [Адрес пункта], [Название пункта], [Район города], [Тип собственности], [Телефон] " +
                     "FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники] WITH (INDEX([IX_Ветеринарные_клиники_Номер_регистрационного_пункта])) " +
                     "INNER JOIN [Veterinary Clinic].[dbo].[Тип собственности] ON ([Ветеринарные клиники].[Код типа собственности]) = [Тип собственности].[Код типа собственности] " +
                     "INNER JOIN [Veterinary Clinic].[dbo].[Районы] ON ([Ветеринарные клиники].[Код район города]) = [Районы].[Код района] " +
                     $"WHERE [Номер регистрационного пункта] = {valueBox}";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Запрос для таблицы Процедуры без использования индекса (по виду процедуры)
        /// </summary>
        /// <returns></returns>
        public static DataTable Request_21(string procedureTypeBox)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            var table = new DataTable();
            string sql = "SELECT [Код процедуры], [Дата оказания помощи животному], [Цена процедуры], [Скидка на эту процедуру], [Цена материала по этой процедуре],[Имя], [Фамилия], [Отчество], [Кличка животного], [Вид животного], [Вид процедуры] " +
               "FROM [Veterinary Clinic].[dbo].[Процедуры] " +
               "INNER JOIN [Veterinary Clinic].[dbo].[Сотрудники] ON ([Процедуры].[Код сотрудника]) = [Сотрудники].[Код сотрудника] " +
               "INNER JOIN [Veterinary Clinic].[dbo].[Животные] ON ([Процедуры].[Код животного]) = [Животные].[Код животного] " +
               "INNER JOIN [Veterinary Clinic].[dbo].[Виды животных] ON ([Животные].[Код вида животного]) = [Виды животных].[Код вида животного] " +
               "INNER JOIN [Veterinary Clinic].[dbo].[Виды процедуры] ON ([Процедуры].[Код вида процедуры]) = [Виды процедуры].[Код вида процедуры] " +
               $"WHERE [Вид процедуры] = N'{procedureTypeBox}'";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);

            return table;
        }
    }
}