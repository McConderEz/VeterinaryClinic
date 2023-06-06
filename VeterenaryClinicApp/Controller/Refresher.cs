using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterenaryClinicApp.Controller
{
    public static class Refresher
    {
        public static DataTable RefreshVeterinaryClinic()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Номер регистрационного пункта]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Год открытия]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Адрес пункта]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта]," +
                "[Veterinary Clinic].[dbo].[Районы].[Район города]," +
                "[Veterinary Clinic].[dbo].[Тип собственности].[Тип собственности]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Телефон] FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники]" +
            "INNER JOIN [Veterinary Clinic].[dbo].[Тип собственности] ON ([Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код типа собственности]) = [Veterinary Clinic].[dbo].[Тип собственности].[Код типа собственности]" +
            "INNER JOIN [Veterinary Clinic].[dbo].[Районы] ON ([Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код район города]) = [Veterinary Clinic].[dbo].[Районы].[Код района]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable RefreshOwner()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Владельцы]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable RefreshProcedure()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT [Veterinary Clinic].[dbo].[Процедуры].[Код процедуры]," +
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
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable RefreshEmployee()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT [Veterinary Clinic].[dbo].[Сотрудники].[Код сотрудника]," +
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
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable RefreshAnimal()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT [Veterinary Clinic].[dbo].[Животные].[Код животного]," +
                "[Veterinary Clinic].[dbo].[Животные].[Кличка Животного]," +
                "[Veterinary Clinic].[dbo].[Животные].[Возраст Животного]," +
                "[Veterinary Clinic].[dbo].[Животные].[Условия содержания животного]," +
                "[Veterinary Clinic].[dbo].[Владельцы].[Имя]," +
                "[Veterinary Clinic].[dbo].[Владельцы].[Фамилия]," +
                "[Veterinary Clinic].[dbo].[Владельцы].[Отчество]," +
                "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного] FROM [Veterinary Clinic].[dbo].[Животные]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Владельцы] ON ([Veterinary Clinic].[dbo].[Животные].[Код владельца]) = [Veterinary Clinic].[dbo].[Владельцы].[Код владельца] " +
                "INNER JOIN [Veterinary Clinic].[dbo].[Виды животных] ON ([Veterinary Clinic].[dbo].[Животные].[Код вида животного]) = [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable RefreshProcedureType()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Виды процедуры]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable RefreshPosition()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Должности]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable RefreshAnimalClass()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Классы животных]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable RefreshAnimalType()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT [Veterinary Clinic].[dbo].[Виды животных].[Код вида животного]," +
                "[Veterinary Clinic].[dbo].[Виды животных].[Вид животного]," +
                "[Veterinary Clinic].[dbo].[Классы животных].[Класс животного] FROM [Veterinary Clinic].[dbo].[Виды животных]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Классы животных] ON ([Veterinary Clinic].[dbo].[Виды животных].[Код класса животного]) = [Veterinary Clinic].[dbo].[Классы животных].[Код класса животного]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable RefreshDistrict()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Районы]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable RefreshOwnership()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Тип собственности]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable RefreshLicense()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT [Veterinary Clinic].[dbo].[Лицензии].[Код лицензии]," +
                "[Veterinary Clinic].[dbo].[Лицензии].[Лицензия №]," +
                "[Veterinary Clinic].[dbo].[Лицензии].[Срок окончания лицензии]," +
                "[Veterinary Clinic].[dbo].[Лицензии].[Фото лицензии]," +
                "[Veterinary Clinic].[dbo].[Ветеринарные клиники].[Название пункта] FROM [Veterinary Clinic].[dbo].[Лицензии]" +
                "INNER JOIN [Veterinary Clinic].[dbo].[Ветеринарные клиники] ON ([Veterinary Clinic].[dbo].[Лицензии].[Код ветеринарной клинки]) = [Veterinary Clinic].[dbo].[Ветеринарные клиники].[Код ветеринарной клинки]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
