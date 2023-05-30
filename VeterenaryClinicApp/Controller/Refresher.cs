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
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники]";
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
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Процедуры]";
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
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Сотрудники]";
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
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Животные]";
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
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Виды животных]";
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
            string query = "SELECT * FROM [Veterinary Clinic].[dbo].[Лицензии]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
