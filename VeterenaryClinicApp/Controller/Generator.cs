using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterenaryClinicApp.Model;

namespace VeterenaryClinicApp.Controller
{
    internal class Generator
    {
        
        public static List<string> disctricts = new List<string> { "Арбат", "Тверской", "Замоскворечье", "Якиманка", "Басманный", "Красносельский", "Пресненский", "Мещанский", "Таганский", "Западное Дегунино" };
        public static List<string> ownership = new List<string> { "Частная собственность", "Государственная собственность", "Частно-государственная" };
        public static List<string> conditions = new List<string> { "Еда/Вода", "Гигиена", "Пространство", "Медицинский уход" };
        public static List<string> typeProcedure = new List<string> { "Общий осмотр", "Вакцинация", "Обработка ран и травм",
            "Хирургические вмешательства","Контрольный осмотр","Диагностические тесты","Зубная гигиена","Уход за кожей","Лечение паразитов","Кормление и диета"};
        public static List<string> classes = new List<string> { "Млекопитающие", "Птицы", "Рыбы", "Пресмыкающиеся", "Амфибии", "Насекомые", "Паукообразные" };
        #region Виды_Животных
        #region Млекопитающие
        public static List<string> dogs = new List<string> { "Нем.овчарка", "Йорк.терьер", "Лабрадор", "Франц.бульдог", "Шпиц" };
        public static List<string> cats = new List<string> { "Персидская", "Сиамская", "Британская", "Сфинкс", "Бенгальская" };
        #endregion
        public static List<string> birds = new List<string> { "Курица", "Утка", "Гусь", "Индюк", "Перепел", "Фазан", "Голубь", "Перепелка", "Страус", "Павлин" };
        public static List<string> fish = new List<string> { "Гуппи", "Меченосец", "Скалярия", "Неон", "Карп", "Окунь", "Сом", "Тетра", "Моллинезия", "Расбора" };
        public static List<string> reptiles = new List<string> { "Игуана", "Хамелеон", "гекконида", "Бар.гекконида", "агама", "змея", "Питон", "Бурый полоз", "Гадюка", "Гремучая змея" };
        public static List<string> amphibians = new List<string> { "Древ.жаба", "квакша", "Крас.жаба", "Афр. жаба", "Ог.саламандра", "Чер.саламандра", "Хв.саламандра" };
        public static List<string> insects = new List<string> { "Кузнечик", "Цикада", "Хрущ", "Хамел.муха", "Палочник", "Муравьед", "Колор.жук", "Пчела-матка", "Хищный жук", "Жук-некрофаг" };
        public static List<string> spiders = new List<string> { "Тарантул", "Птицеед", "Терр.паук", "Черная вдова", "колесница", "Скакунчик", "Паук-птицелов", "Мекс.тарантул", "Крабовый паук", "паук-птицелов" };
        #endregion  
        public static List<string> positions = new List<string> { "Ветеринарный врач", "Зоотехник", "Помощник ветеринара", "Ветеринарный хирург", "Ветеринарный терапевт", "Ветеринарный патологоанатом", "Ветеринарный миколог", "Ветеринарный бактериолог", "Ветеринарный фармаколог", "Ветеринарный эпидемиолог" };
        public static List<string> nicknames = new List<string>
        {
             "Барсик", "Рыжик", "Мурка", "Шарик", "Тузик", "Бобик", "Жучка", "Рекс", "Ласка", "Белка",
             "Дори", "Немо", "Бабочка", "Гуппи", "Данио", "Ботия", "Скалярия", "Тетра", "Карп", "Осетр",
             "Драко", "Рекс", "Каа", "Кощей", "Кими", "Гекон", "Змеюка", "Джек", "Игуана", "Хамелеон",
             "Жабка", "Квакша", "Молли", "Саламандра", "Лягушка", "Хвостик", "Кермит", "Терки", "Крошка", "Тритон",
             "Жучка", "Усач", "Кузнечик", "Муха", "Жук", "Пчелка", "Бабочка", "Комарик", "Муравей", "Клопик",
             "Тарантул", "Черный вдовец", "Крабик", "Хорек", "Красный коленчатый", "Гермиона", "Гарри", "Рон", "Питонис", "Марволо"
        };
        public static List<string> name = new List<string> { "Александр", "Дмитрий", "Иван", "Михаил", "Никита", "Павел", "Сергей", "Артём", "Владимир", "Егор" };
        public static List<string> secondname = new List<string> { "Иванов", "Петров", "Сидоров", "Смирнов", "Кузнецов", "Васильев", "Михайлов", "Новиков", "Федоров", "Морозов" };
        public static List<string> surname = new List<string> { "Александрович", "Дмитриевич", "Иванович", "Михайлович", "Николаевич", "Петрович", "Сергеевич", "Андреевич", "Владимирович", "Юрьевич" };
        public static List<string> addresses = new List<string> { "Профсоюзная улица", "Ленинский проспект", "Невский проспект", "Тверская улица", "Красная площадь", "Арбатская улица", "Пушкинская улица", "Кутузовский проспект", "Садовое кольцо", "Каменноостровский проспект", "Большая Садовая улица", "Никольская улица", "Малая Бронная улица", "Казанский переулок", "Хохловский переулок", "Лесная улица", "Шоссе Энтузиастов", "Улица Сергея Эйзенштейна", "Автозаводская улица", "Пресненская набережная" };
        public static List<string> clinicName = new List<string> { "Лапа", "Ангел", "Забота", "Хвостики", "Ветеринарка", "Доктор Питер", "Без боли", "Кусь", "Айболит", "Лапочка" };
        /// <summary>
        /// Создаем записи в справочнике Районов
        /// </summary>
        public static void CreateDistricts()
        {
            using(var db = new Veterinary_ClinicEntities())
            {
                for(var i = 0;i < disctricts.Count; i++)
                {
                    db.Районы.Add(new Районы
                    {
                        Район_города = disctricts[i]
                    });                    
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Создаем записи в справочнике Классов Животных
        /// </summary>
        public static void CreateAnimalClasses()
        {
            using(var db = new Veterinary_ClinicEntities())
            {
                for(var i = 0;i < classes.Count; i++)
                {
                    db.Классы_животных.Add(new Классы_животных
                    {
                        Класс_животного = classes[i]
                    });
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Создаём справочник с видами животных
        /// </summary>
        public static void CreateAnimalTypes()
        {
            using(var db = new Veterinary_ClinicEntities())
            {
                for(var i = 0;i < dogs.Count; i++)
                {
                    db.Виды_животных.Add(new Виды_животных
                    {
                        Вид_животного = dogs[i],
                        Код_класса_животного = 2                        
                    });
                }

                for (var i = 0; i < cats.Count; i++)
                {
                    db.Виды_животных.Add(new Виды_животных
                    {
                        Вид_животного = cats[i],
                        Код_класса_животного = 2
                    });
                }

                for (var i = 0; i < birds.Count; i++)
                {
                    db.Виды_животных.Add(new Виды_животных
                    {
                        Вид_животного = birds[i],
                        Код_класса_животного = 3
                    });
                }

                for (var i = 0; i < fish.Count; i++)
                {
                    db.Виды_животных.Add(new Виды_животных
                    {
                        Вид_животного = fish[i],
                        Код_класса_животного = 4
                    });
                }

                for (var i = 0; i < reptiles.Count; i++)
                {
                    db.Виды_животных.Add(new Виды_животных
                    {
                        Вид_животного = reptiles[i],
                        Код_класса_животного = 5
                    });
                }

                for (var i = 0; i < amphibians.Count; i++)
                {
                    db.Виды_животных.Add(new Виды_животных
                    {
                        Вид_животного = amphibians[i],
                        Код_класса_животного = 6
                    });
                }

                for (var i = 0; i < insects.Count; i++)
                {
                    db.Виды_животных.Add(new Виды_животных
                    {
                        Вид_животного = insects[i],
                        Код_класса_животного = 7
                    });
                }

                for (var i = 0; i < spiders.Count; i++)
                {
                    db.Виды_животных.Add(new Виды_животных
                    {
                        Вид_животного = spiders[i],
                        Код_класса_животного = 8,                        
                    });
                }

                db.SaveChanges();
            }
        }
        /// <summary>
        /// Создаём справочник с условиями содержания животных
        /// </summary>
        //public static void CreateConditions()
        //{
        //    using(var db = new Veterinary_ClinicEntities())
        //    {
        //        for(var i = 0;i < conditions.Count; i++)
        //        {
        //            db.Условия_содержания_животного.Add(new Условия_содержания_животного
        //            {
        //                Условия_содержания_животного1 = conditions[i],
        //            });
        //        }
        //        db.SaveChanges();
        //    }
        //}
        /// <summary>
        /// Создаём справочник с типами собственности
        /// </summary>
        public static void CreateOwnerships()
        {
            using(var db = new Veterinary_ClinicEntities())
            {
                for (var i = 0; i < ownership.Count; i++)
                {
                    db.Тип_собственности.Add(new Тип_собственности
                    {
                        Тип_собственности1 = ownership[i]
                    });
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Создаём справочник с видами процедур
        /// </summary>
        public static void CreateProceduresType()
        {
            using(var db = new Veterinary_ClinicEntities())
            {
                for(var i = 0;i < typeProcedure.Count; i++)
                {
                    db.Виды_процедуры.Add(new Виды_процедуры
                    {
                        Вид_процедуры = typeProcedure[i]
                    });
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Создаём справочники с должностями
        /// </summary>
        public static void CreatePositions()
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                for (var i = 0; i < positions.Count; i++)
                {
                    db.Должности.Add(new Должности
                    {
                        Должность = positions[i]
                    });
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Создание справочников с лицензиями
        /// </summary>
        public static void CreateLicenses()
        {           
            Random rnd = new Random();
            DateTime issueDate = DateTime.Now;
            using(var db = new Veterinary_ClinicEntities())
            {
                for (var i = 0; i < 10; i++) {
                    string regionCode = rnd.Next(10, 100).ToString();
                    string departmentCode = rnd.Next(10, 100).ToString();
                    int uniqueNumber = rnd.Next(1000, 10000);
                    int durationInYears = rnd.Next(1, 6);
                    db.Лицензии.Add(new Лицензии
                    {
                        Лицензия__ = $"{regionCode}-{departmentCode}-{uniqueNumber}",
                        Срок_окончания_лицензии = issueDate.AddYears(durationInYears),     
                        Код_ветеринарной_клинки = rnd.Next(2,db.Ветеринарные_клиники.Count())
                    });
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Создание таблицы ветеринарных клиник
        /// </summary>
        public static void GenerateVeterinaryClinic()
        {
            Random rnd = new Random();
                                
            using (var db = new Veterinary_ClinicEntities())
            {
                for(var i = 0;i < 100; i++)
                {                    
                    int uniqueNumber = rnd.Next(1000, 10000);
                    db.Ветеринарные_клиники.Add(new Ветеринарные_клиники
                    {
                        Год_открытия = rnd.Next(1761, 2023),
                        Номер_регистрационного_пункта = uniqueNumber,
                        Адрес_пункта = addresses[rnd.Next(0, addresses.Count)],
                        Название_пункта = clinicName[rnd.Next(0, clinicName.Count)],
                        Телефон = $"7-{rnd.Next(900, 1000)}-{rnd.Next(1, 1000)}-{rnd.Next(10, 100)}-{rnd.Next(10, 100)}",
                        Код_район_города = rnd.Next(2,db.Районы.Count()),
                        Код_типа_собственности = rnd.Next(2,db.Тип_собственности.Count())
                    });
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Создаёт таблицу с владельцами животных
        /// </summary>
        public static void GenerateOwner()
        {
            Random rnd = new Random();
            using(var db = new Veterinary_ClinicEntities())
            {
                for(var i = 0;i < 11000; i++)
                {
                    DateTime start = new DateTime(1950, 1, 1);
                    TimeSpan range = DateTime.Today - start;
                    int days = rnd.Next(range.Days);
                    DateTime birthdate = start.AddDays(days);
                    db.Владельцы.Add(new Владельцы
                    {
                        Имя = name[rnd.Next(0,name.Count())],
                        Фамилия = secondname[rnd.Next(0,secondname.Count())],
                        Отчество = surname[rnd.Next(0, surname.Count())],
                        Телефон = $"{rnd.Next(900, 1000)}{rnd.Next(1, 1000)}{rnd.Next(10, 100)}{rnd.Next(10, 100)}",
                        Дата_рождения_хозяина = birthdate
                    });
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Создаём таблицы с сотрудниками
        /// </summary>
        public static void GenerateEmployees()
        {
            Random rnd = new Random();
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT [Код ветеринарной клинки] FROM [Veterinary Clinic].[dbo].[Ветеринарные клиники]";
            SqlCommand command = new SqlCommand(query, myConnection);
            List<int> idList = new List<int>();
            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    idList.Add(id);
                }
            }
            using (var db = new Veterinary_ClinicEntities())
            {
                for (var i = 0; i < 150; i++)
                {
                    DateTime start = new DateTime(1950, 1, 1);
                    TimeSpan range = DateTime.Now.AddYears(-18) - start;
                    int days = rnd.Next(range.Days);
                    DateTime birthdate = start.AddDays(days);
                   

                    db.Сотрудники.Add(new Сотрудники
                    {
                        Имя = name[rnd.Next(0, name.Count())],
                        Фамилия = secondname[rnd.Next(0, secondname.Count())],
                        Отчество = surname[rnd.Next(0, surname.Count())],
                        Дата_рождения = birthdate,
                        Стаж = rnd.Next(0, (DateTime.Now.Year - birthdate.Year)-18),
                        Оклад = 5000,
                        Код_должности = rnd.Next(2,db.Должности.Count()),                       
                        Код_ветеринарной_клиники = idList[rnd.Next(1,idList.Count)]
                        
                    });
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Создаём таблицу с процедурами
        /// </summary>
        public static void GenerateProcedure()
        {
            Random rnd = new Random();            
            string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Veterinary Clinic;Integrated Security=True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            string query = "SELECT [Код сотрудника] FROM [Veterinary Clinic].[dbo].[Сотрудники]";
            SqlCommand command = new SqlCommand(query, myConnection);
            List<int> idList = new List<int>();
            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    idList.Add(id);
                }
            }
            query = "SELECT [Код животного] FROM [Veterinary Clinic].[dbo].[Животные]";
            List<int> idList2 = new List<int>();
            command = new SqlCommand(query, myConnection);
            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    idList2.Add(id);
                }
            }
            using (var db = new Veterinary_ClinicEntities())
            {
                for(var i = 0;i < 1000; i++)
                {
                    DateTime start = new DateTime(2000, 1, 1);
                    TimeSpan range = DateTime.Now - start;
                    int days = rnd.Next(range.Days);
                    DateTime date = start.AddDays(days);
                    db.Процедуры.Add(new Процедуры
                    {
                        Код_вида_процедуры = rnd.Next(2, typeProcedure.Count),
                        Дата_оказания_помощи_животному = date,
                        Цена_процедуры = rnd.Next(1000, 100000),
                        Скидка_на_эту_процедуру = rnd.Next(0, 20),
                        Цена_материала_по_этой_процедуре = rnd.Next(0,100000),
                        Код_сотрудника = idList[rnd.Next(1,idList.Count)],
                        Код_животного = idList2[rnd.Next(1, idList2.Count)]
                    });
                    
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Создаёт таблицу с животными
        /// </summary>
        public static void GenerateAnimals()
        {
            Random rnd = new Random();
            using(var db = new Veterinary_ClinicEntities())
            {
                for(var i = 0;i < 2000; i++)
                {
                    db.Животные.Add(new Животные
                    {
                        Кличка_Животного = nicknames[rnd.Next(0,nicknames.Count)],
                        Возраст_Животного = rnd.Next(1,15),
                        Условия_содержания_животного = conditions[rnd.Next(0,conditions.Count)],
                        Код_владельца = rnd.Next(2,db.Владельцы.Count()),
                        Код_вида_животного = rnd.Next(2,db.Виды_животных.Count())
                    });
                }
                db.SaveChanges();
            }
        }

        public static void GenerateDataBase()
        {
            //CreateAnimalClasses();
            //CreateAnimalTypes();
            //CreateDistricts();   
            //CreateOwnerships();
            //CreateProceduresType();
            //GenerateOwner();
            //CreatePositions();
            //GenerateVeterinaryClinic();
            //GenerateAnimals();
            //GenerateEmployees();
            //GenerateProcedure();
            //CreateLicenses();
        }
    }
}
