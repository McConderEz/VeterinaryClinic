using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media.Media3D;
using System.Xml;
using VeterenaryClinicApp.Model;

namespace VeterenaryClinicApp.Controller
{
    public static class Remover
    {

        /// <summary>
        /// Удаление записей ветеринарных клиник
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>true - если удаление успешно, иначе false</returns>
        public static bool RemoveVeterinaryClinic(List<int> ids)
        {
            try
            {
                using (var db = new Veterinary_ClinicEntities())
                {
                    for (var i = 0; i < ids.Count; i++)
                    {
                        var recordToDelete = db.Ветеринарные_клиники.Find(ids[i]);
                        db.Ветеринарные_клиники.Remove(recordToDelete);
                    }
                    db.SaveChanges();
                }

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// Удаление записей владельцев
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>true - если удаление успешно, иначе false</returns>
        public static bool RemoveOwner(List<int> ids)
        {
            try
            {
                using (var db = new Veterinary_ClinicEntities())
                {
                    for (var i = 0; i < ids.Count; i++)
                    {
                        var recordToDelete = db.Владельцы.Find(ids[i]);
                        db.Владельцы.Remove(recordToDelete);
                    }
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Удаление записей процедур
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>true - если удаление успешно, иначе false</returns>
        public static bool RemoveProcedure(List<int> ids)
        {
            try
            {
                using (var db = new Veterinary_ClinicEntities())
                {
                    for (var i = 0; i < ids.Count; i++)
                    {
                        var recordToDelete = db.Процедуры.Find(ids[i]);
                        db.Процедуры.Remove(recordToDelete);
                    }
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// Удаление записей сотрудников
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>true - если удаление успешно, иначе false</returns>
        public static bool RemoveEmployee(List<int> ids)
        {
            try
            {
                using (var db = new Veterinary_ClinicEntities())
                {
                    for (var i = 0; i < ids.Count; i++)
                    {
                        var recordToDelete = db.Сотрудники.Find(ids[i]);
                        db.Сотрудники.Remove(recordToDelete);
                    }
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Удаление записей животных
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>true - если удаление успешно, иначе false</returns>
        public static bool RemoveAnimal(List<int> ids)
        {
            try
            {
                using (var db = new Veterinary_ClinicEntities())
                {
                    for (var i = 0; i < ids.Count; i++)
                    {
                        var recordToDelete = db.Животные.Find(ids[i]);
                        db.Животные.Remove(recordToDelete);
                    }
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Удаление записей животных
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>true - если удаление успешно, иначе false</returns>
        public static bool RemoveProcedureType(List<int> ids)
        {
            try
            {
                using (var db = new Veterinary_ClinicEntities())
                {
                    for (var i = 0; i < ids.Count; i++)
                    {
                        var recordToDelete = db.Виды_процедуры.Find(ids[i]);
                        db.Виды_процедуры.Remove(recordToDelete);
                    }
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Удаление записей должности
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>true - если удаление успешно, иначе false</returns>
        public static bool RemovePosition(List<int> ids)
        {
            try
            {
                using (var db = new Veterinary_ClinicEntities())
                {
                    for (var i = 0; i < ids.Count; i++)
                    {
                        var recordToDelete = db.Должности.Find(ids[i]);
                        db.Должности.Remove(recordToDelete);
                    }
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Удаление записей класс животного
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>true - если удаление успешно, иначе false</returns>
        public static bool RemoveAnimalClass(List<int> ids)
        {
            try
            {
                using (var db = new Veterinary_ClinicEntities())
                {
                    for (var i = 0; i < ids.Count; i++)
                    {
                        var recordToDelete = db.Классы_животных.Find(ids[i]);
                        db.Классы_животных.Remove(recordToDelete);
                    }
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Удаление записей виды животного
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>true - если удаление успешно, иначе false</returns>
        public static bool RemoveAnimalType(List<int> ids)
        {
            try
            {
                using (var db = new Veterinary_ClinicEntities())
                {
                    for (var i = 0; i < ids.Count; i++)
                    {
                        var recordToDelete = db.Виды_животных.Find(ids[i]);
                        db.Виды_животных.Remove(recordToDelete);
                    }
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Удаление записей районов
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>true - если удаление успешно, иначе false</returns>
        public static bool RemoveDistrict(List<int> ids)
        {
            try
            {
                using (var db = new Veterinary_ClinicEntities())
                {
                    for (var i = 0; i < ids.Count; i++)
                    {
                        var recordToDelete = db.Районы.Find(ids[i]);
                        db.Районы.Remove(recordToDelete);
                    }
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Удаление записей типа собственности
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>true - если удаление успешно, иначе false</returns>
        public static bool RemoveOwnership(List<int> ids)
        {
            try
            {
                using (var db = new Veterinary_ClinicEntities())
                {
                    for (var i = 0; i < ids.Count; i++)
                    {
                        var recordToDelete = db.Тип_собственности.Find(ids[i]);
                        db.Тип_собственности.Remove(recordToDelete);
                    }
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Удаление записей Лицензии
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>true - если удаление успешно, иначе false</returns>
        public static bool RemoveLicense(List<int> ids)
        {
            try
            {
                using (var db = new Veterinary_ClinicEntities())
                {
                    for (var i = 0; i < ids.Count; i++)
                    {
                        var recordToDelete = db.Лицензии.Find(ids[i]);
                        db.Лицензии.Remove(recordToDelete);
                    }
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static (int,int) CountRemoveVeterinaryClinic(List<int> ids)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT COUNT(*) FROM [Сотрудники] WHERE [Код Ветеринарной клиники] IN (" +
    string.Join(",", ids.Select(x => $"'{x}'")) + ")";
            SqlCommand command = new SqlCommand(query, myConnection);
            int countEmployee = (int)command.ExecuteScalar();
            command = new SqlCommand(query, myConnection);
            query = "SELECT COUNT(*) FROM [Лицензии] WHERE [Код Ветеринарной клинки] IN (" +
    string.Join(",", ids.Select(x => $"'{x}'")) + ")";
            int countLicense = (int)command.ExecuteScalar();
            return (countEmployee,countLicense);
        }

        public static int CountRemoveOwner(List<int> ids)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT COUNT(*) FROM [Животные] WHERE [Код владельца] IN (" +
    string.Join(",", ids.Select(x => $"'{x}'")) + ")";
            SqlCommand command = new SqlCommand(query, myConnection);
            int count = (int)command.ExecuteScalar();           
            return count;
        }

        public static int CountRemoveAnimal(List<int> ids)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT COUNT(*) FROM [Процедуры] WHERE [Код животного] IN (" +
    string.Join(",", ids.Select(x => $"'{x}'")) + ")";
            SqlCommand command = new SqlCommand(query, myConnection);
            int count = (int)command.ExecuteScalar();
            return count;
        }

        public static int CountRemoveEmployee(List<int> ids)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT COUNT(*) FROM [Процедуры] WHERE [Код сотрудника] IN (" +
    string.Join(",", ids.Select(x => $"'{x}'")) + ")";
            SqlCommand command = new SqlCommand(query, myConnection);
            int count = (int)command.ExecuteScalar();
            return count;
        }

        public static (int,int) CountRemoveAnimalType(List<int> ids)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT COUNT(*) FROM [Животные] WHERE [Код вида животного] IN (" +
    string.Join(",", ids.Select(x => $"'{x}'")) + ")";
            SqlCommand command = new SqlCommand(query, myConnection);
            int count = (int)command.ExecuteScalar();
            query =  "SELECT COUNT(*) FROM [Процедуры] WHERE [Код животного] IN (SELECT [Код животного] FROM [Животные] WHERE [Код вида животного] IN(" +
    string.Join(",", ids.Select(x => $"'{x}'")) + "))";
            command = new SqlCommand(query, myConnection);
            int count2 = (int)command.ExecuteScalar();
            return (count,count2);
        }

        public static (int,int,int) CountRemoveOwnershipType(List<int> ids)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT COUNT(*) FROM [Ветеринарные клиники] WHERE [Код типа собственности] IN (" +
    string.Join(",", ids.Select(x => $"'{x}'")) + ")";
            SqlCommand command = new SqlCommand(query, myConnection);
            int count = (int)command.ExecuteScalar();
            query = "SELECT COUNT(*) FROM [Сотрудники] WHERE [Код ветеринарной клиники] IN (SELECT [Код ветеринарной клинки] FROM [Ветеринарные клиники] WHERE [Код типа собственности] IN(" +
    string.Join(",", ids.Select(x => $"'{x}'")) + "))";
            command = new SqlCommand(query, myConnection);
            int count2 = (int)command.ExecuteScalar();
            query = "SELECT COUNT(*) FROM [Лицензии] WHERE [Код ветеринарной клинки] IN (SELECT [Код ветеринарной клинки] FROM [Ветеринарные клиники] WHERE [Код типа собственности] IN(" +
    string.Join(",", ids.Select(x => $"'{x}'")) + "))";
            command = new SqlCommand(query, myConnection);
            int count3 = (int)command.ExecuteScalar();

            return (count,count2,count3);
        }

        public static (int,int,int) CountRemoveDistrict(List<int> ids)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT COUNT(*) FROM [Ветеринарные клиники] WHERE [Код район города] IN (" +
    string.Join(",", ids.Select(x => $"'{x}'")) + ")";
            SqlCommand command = new SqlCommand(query, myConnection);
            int count = (int)command.ExecuteScalar();
            query = "SELECT COUNT(*) FROM [Сотрудники] WHERE [Код ветеринарной клиники] IN (SELECT [Код ветеринарной клинки] FROM [Ветеринарные клиники] WHERE [Код район города] IN(" +
   string.Join(",", ids.Select(x => $"'{x}'")) + "))";
            command = new SqlCommand(query, myConnection);
            int count2 = (int)command.ExecuteScalar();
            query = "SELECT COUNT(*) FROM [Лицензии] WHERE [Код ветеринарной клинки] IN (SELECT [Код ветеринарной клинки] FROM [Ветеринарные клиники] WHERE [Код район города] IN(" +
    string.Join(",", ids.Select(x => $"'{x}'")) + "))";
            command = new SqlCommand(query, myConnection);
            int count3 = (int)command.ExecuteScalar();

            return (count,count2,count3);
        }

        public static int CountRemoveProcedureType(List<int> ids)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT COUNT(*) FROM [Процедуры] WHERE [Код вида процедуры] IN (" +
    string.Join(",", ids.Select(x => $"'{x}'")) + ")";
            SqlCommand command = new SqlCommand(query, myConnection);
            int count = (int)command.ExecuteScalar();
            return count;
        }

        public static (int, int) CountRemovePosition(List<int> ids)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT COUNT(*) FROM [Сотрудники] WHERE [Код должности] IN (" +
    string.Join(",", ids.Select(x => $"'{x}'")) + ")";
            SqlCommand command = new SqlCommand(query, myConnection);
            int count = (int)command.ExecuteScalar();
            query = "SELECT COUNT(*) FROM [Процедуры] WHERE [Код сотрудника] IN (SELECT [Код сотрудника] FROM [Сотрудники] WHERE [Код должности] IN(" +
   string.Join(",", ids.Select(x => $"'{x}'")) + "))";
            command = new SqlCommand(query, myConnection);
            int count2 = (int)command.ExecuteScalar();


            return (count, count2);
        }

        public static (int,int, int) CountRemoveAnimalClass(List<int> ids)
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT COUNT(*) FROM [Виды животных] WHERE [Код класса животного] IN (" +
    string.Join(",", ids.Select(x => $"'{x}'")) + ")";
            SqlCommand command = new SqlCommand(query, myConnection);
            int count = (int)command.ExecuteScalar();
            query = "SELECT COUNT(*) FROM [Животные] WHERE [Код вида животного] IN (SELECT [Код вида животного] FROM [Виды животных] WHERE [Код класса животного] IN(" +
    string.Join(",", ids.Select(x => $"'{x}'")) + "))";
            command = new SqlCommand(query, myConnection);
            int count2 = (int)command.ExecuteScalar();
            query = "SELECT COUNT(*) FROM [Процедуры] WHERE [Код животного] IN (SELECT [Код животного] FROM [Животные] WHERE [Код вида животного] IN (SELECT [Код вида животного] FROM [Виды животных] WHERE [Код класса животного] IN(" +
    string.Join(",", ids.Select(x => $"'{x}'")) + ")))";
            command = new SqlCommand(query, myConnection);
            int count3 = (int)command.ExecuteScalar();
            return (count,count2, count3);
        }

        public static DataTable LoadTables()
        {
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'";
            SqlCommand command = new SqlCommand(sql, myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public static void DeleteNotesByFields(string value,string nameTable,string field,string sign)
        {
            try
            {
                if (value != null)
                {
                    string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
                    SqlConnection myConnection = new SqlConnection(connectionString);
                    myConnection.Open();
                    string sql;
                    int intValue;
                    decimal decValue;
                    DateTime dateValue;

                    if (int.TryParse(value, out intValue))
                    {
                        sql = $"DELETE  FROM [Veterinary Clinic].[dbo].[{nameTable}] " +
                                $"WHERE [Veterinary Clinic].[dbo].[{nameTable}].[{field}] {sign} {intValue}";
                    }
                    else if (decimal.TryParse(value, out decValue))
                    {
                        sql = $"DELETE  FROM [Veterinary Clinic].[dbo].[{nameTable}] " +
                                $"WHERE [Veterinary Clinic].[dbo].[{nameTable}].[{field}] {sign} {decValue}";
                    }
                    else if (DateTime.TryParse(value, out dateValue))
                    {
                        string date = $"{dateValue.Month}-{dateValue.Day}-{dateValue.Year}";
                        sql = $"DELETE  FROM [Veterinary Clinic].[dbo].[{nameTable}] " +
                                 $"WHERE [Veterinary Clinic].[dbo].[{nameTable}].[{field}] {sign} {date}";
                    }
                    else
                    {
                        if (nameTable == "Ветеринарные клиники")
                        {
                            if (field == "Тип собственности")
                            {
                                nameTable = "Тип собственности";
                                sql = "DELETE  FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники] " +
                                $" WHERE [Код типа собственности] IN (SELECT [Код типа собственности] FROM [{nameTable}] WHERE [{field}] = N'{value}')";
                            }
                            else if (field == "Район города")
                            {
                                nameTable = "Районы";
                                sql = "DELETE  FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники] " +
                                $" WHERE [Код район города] IN (SELECT [Код района] FROM [{nameTable}] WHERE [{field}] = N'{value}')";
                            }
                            else
                            {
                                sql = $"DELETE  FROM [Veterinary Clinic].[dbo].[{nameTable}] " +
                                $"WHERE [Veterinary Clinic].[dbo].[{nameTable}].[{field}] = N'{value}'";
                            }

                        }
                        else if (nameTable == "Сотрудники")
                        {
                            if (field == "Должность")
                            {
                                nameTable = "Должности";
                                sql = "DELETE  FROM [Veterinary Clinic].[dbo].[Сотрудники] " +
                                $" WHERE [Код должности] IN (SELECT [Код должности] FROM [{nameTable}] WHERE [{field}] = N'{value}')";
                            }
                            else if (field == "Номер регистрационного пункта" || field == "Название пункта")
                            {
                                nameTable = "Ветеринарные клиники";
                                sql = "DELETE  FROM [Veterinary Clinic].[dbo].[Сотрудники] " +
                                $" WHERE [Код ветеринарной клинки] IN (SELECT [Код ветеринарной клинки] FROM [{nameTable}] WHERE [{field}] = N'{value}')";
                            }
                            else
                            {
                                sql = "DELETE  FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники] " +
                                $"WHERE [Veterinary Clinic].[dbo].[{nameTable}].[{field}] = N'{value}'";
                            }
                        }
                        else if (nameTable == "Животные")
                        {
                            if (field == "Имя" || field == "Фамилия" || field == "Отчество")
                            {
                                nameTable = "Владельцы";
                                sql = $"DELETE  FROM [Veterinary Clinic].[dbo].[Животные] " +
                                $" WHERE [Код владельца] IN (SELECT [Код владельца] FROM [{nameTable}] WHERE [{field}] = N'{value}')";
                            }
                            else if (field == "Вид животного")
                            {
                                nameTable = "Виды животных";
                                sql = $"DELETE  FROM [Veterinary Clinic].[dbo].[Животные] " +
                                $" WHERE [Код вида животного] IN (SELECT [Код вида животного] FROM [{nameTable}] WHERE [{field}] = N'{value}')";
                            }
                            else
                            {
                                sql = "DELETE  FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники] " +
                                $"WHERE [Veterinary Clinic].[dbo].[{nameTable}].[{field}] = N'{value}'";
                            }
                        }
                        else if (nameTable == "Процедуры")
                        {
                            if (field == "Имя" || field == "Фамилия" || field == "Отчество")
                            {
                                nameTable = "Сотрудники";
                                sql = $"DELETE  FROM [Veterinary Clinic].[dbo].[Процедуры] " +
                                $" WHERE [Код сотрудника] IN (SELECT [Код сотрудника] FROM [{nameTable}] WHERE [{field}] = N'{value}')";
                            }
                            else if (field == "Кличка животного")
                            {
                                nameTable = "Животные";
                                sql = $"DELETE  FROM [Veterinary Clinic].[dbo].[Процедуры] " +
                                $" WHERE [Код животного] IN (SELECT [Код животного] FROM [{nameTable}] WHERE [{field}] = N'{value}')";
                            }
                            else if (field == "Вид животного")
                            {
                                nameTable = "Виды животных";
                                sql = $"DELETE  FROM [Veterinary Clinic].[dbo].[Процедуры] " +
                                $" WHERE [Код животного] IN (SELECT [Код животного] FROM [Животные] WHERE [Код животного] IN (SELECT [Код животного] FROM [{nameTable}] WHERE [Код вида животного] = N'{value}'))";
                            }
                            else if (field == "Вид процедуры")
                            {
                                nameTable = "Виды процедуры";
                                sql = $"DELETE  FROM [Veterinary Clinic].[dbo].[Процедуры " +
                                $" WHERE [Код вида процедуры] IN (SELECT [Код вида процедуры] FROM [{nameTable}] WHERE [{field}] = N'{value}')";
                            }
                            else
                            {
                                sql = "DELETE  FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники] " +
                                $"WHERE [Veterinary Clinic].[dbo].[{nameTable}].[{field}] = N'{value}'";
                            }

                        }
                        else if (nameTable == "Виды животных")
                        {
                            if (field == "Класс животного")
                            {
                                nameTable = "Классы животных";
                                sql = $"DELETE  FROM [Veterinary Clinic].[dbo].[Виды животных] " +
                                $" WHERE [Код класса животного] IN (SELECT [Код класса животного] FROM [{nameTable}] WHERE [{field}] = N'{value}')";
                            }
                            else
                            {
                                sql = "DELETE  FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники] " +
                                $"WHERE [Veterinary Clinic].[dbo].[{nameTable}].[{field}] = N'{value}'";
                            }
                            sql = "DELETE FROM [Veterinary Clinic].[dbo].[Виды животных]" +
                $"INNER JOIN [Veterinary Clinic].[dbo].[Классы животных] ON ([Veterinary Clinic].[dbo].[Виды животных].[Код класса животного]) = [Veterinary Clinic].[dbo].[Классы животных].[Код класса животного] WHERE [Veterinary Clinic].[dbo].[{nameTable}].[{field}] = N'{value}'";
                        }
                        else if (nameTable == "Лицензии")
                        {
                            if (field == "Название пункта")
                            {
                                nameTable = "Ветеринарные клиники";
                                sql = $"DELETE  FROM [Veterinary Clinic].[dbo].[Лицензии] " +
                                $" WHERE [Код ветеринарной клинки] IN (SELECT [Код ветеринарной клинки] FROM [{nameTable}] WHERE [{field}] = N'{value}')";
                            }
                            else
                            {
                                sql = "DELETE  FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники] " +
                                $"WHERE [Veterinary Clinic].[dbo].[{nameTable}].[{field}] = N'{value}'";
                            }
                        }
                        else
                        {
                            sql = $"DELETE FROM [Veterinary Clinic].[dbo].[{nameTable}] WHERE [Veterinary Clinic].[dbo].[{nameTable}].[{field}] = N'{value}'";
                        }
                    }
                    SqlCommand command = new SqlCommand(sql, myConnection);
                    command.ExecuteScalar();
                }
            }
            catch(Exception ex)
            {

            }

        }
    }
}
