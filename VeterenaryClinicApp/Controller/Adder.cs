using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterenaryClinicApp.Model;

namespace VeterenaryClinicApp.Controller
{
    internal static class Adder
    {
        /// <summary>
        /// Добавляет ветеринарную клинику в базу данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool AddVeterinaryClinic(string regNumberBox, string ownershipTypeBox, string yearBox, string districtCodeBox,
            string address, string name, string phone)
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                int regNumber;
                int ownershipTypeCode;
                int year;
                int districtCode;
                if ((int.TryParse(regNumberBox, out regNumber) && (regNumber >= 1000 && regNumber < 10000)) &&
                    (int.TryParse(ownershipTypeBox, out ownershipTypeCode) && (ownershipTypeCode >= 1 && ownershipTypeCode <= db.Тип_собственности.Count())) &&
                    (int.TryParse(yearBox, out year) && (year >= 1761 && year <= DateTime.Now.Year)) &&
                    (int.TryParse(districtCodeBox, out districtCode) && (districtCode >= 1 && districtCode <= db.Районы.Count())) &&
                    (!string.IsNullOrWhiteSpace(address) && (address.Length <= 40)) &&
                    (!string.IsNullOrWhiteSpace(name) && (name.Length <= 15)) &&
                    (!string.IsNullOrWhiteSpace(phone) && phone.Length <= 15))
                {
                    db.Ветеринарные_клиники.Add(new Ветеринарные_клиники
                    {
                        Номер_регистрационного_пункта = regNumber,
                        Код_типа_собственности = ownershipTypeCode,
                        Год_открытия = year,
                        Код_район_города = districtCode,
                        Название_пункта = name,
                        Адрес_пункта = address,
                        Телефон = phone
                    });
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }


        }

        /// <summary>
        /// Добавляет владельца в базу данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool AddOwner(string nameBox, string secondNameBox, string surNameBox, string phone, string birthdayBox)
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                DateTime birthday;               
                if ((DateTime.TryParse(birthdayBox, out birthday) && (birthday.Year <= DateTime.Now.Year)) &&                  
                    (!string.IsNullOrWhiteSpace(nameBox) && (nameBox.Length <= 40)) &&
                    (!string.IsNullOrWhiteSpace(secondNameBox) && (secondNameBox.Length <= 40)) &&
                    (!string.IsNullOrWhiteSpace(surNameBox) && (surNameBox.Length <= 40)) &&
                    (!string.IsNullOrWhiteSpace(phone) && phone.Length <= 10))
                {
                    db.Владельцы.Add(new Владельцы
                    {
                        Имя = nameBox,
                        Фамилия = secondNameBox,
                        Отчество = surNameBox,
                        Дата_рождения_хозяина = birthday,
                        Телефон = phone
                    });
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Добавляет процедуру в базу данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool AddProcedure(string dataHelpBox, string codeProcedureTypeBox, string priceBox,
            string discountBox, string materialsPriceBox, string codeEmployeeBox,string codeAnimalBox)
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                DateTime dataHelp;
                decimal price;
                decimal discount;
                decimal materialsPrice;
                int codeEmployee;
                int codeAnimal;
                int codeProcedureType;
                if ((DateTime.TryParse(dataHelpBox, out dataHelp) && (dataHelp.Year <= DateTime.Now.Year)) &&
                    ((decimal.TryParse(priceBox, out price) && (price >= 1000 && price <= 100000))) &&
                    ((decimal.TryParse(discountBox, out discount) && (discount >= 0 && discount <= 20))) &&
                    ((decimal.TryParse(materialsPriceBox, out materialsPrice) && (materialsPrice >= 0 && materialsPrice <= 1000000))) &&
                    ((int.TryParse(codeProcedureTypeBox, out codeProcedureType) && (codeProcedureType >= 1 && codeProcedureType <= 11))) &&
                    ((int.TryParse(codeEmployeeBox, out codeEmployee) && (codeEmployee >= 1 && codeEmployee <= db.Сотрудники.Count()))) &&
                    ((int.TryParse(codeAnimalBox, out codeAnimal) && (codeAnimal >= 1 && codeAnimal <= db.Животные.Count())))
                    )
                {
                    db.Процедуры.Add(new Процедуры
                    {
                        Дата_оказания_помощи_животному = dataHelp,
                        Цена_процедуры = price,
                        Скидка_на_эту_процедуру = discount,
                        Цена_материала_по_этой_процедуре = materialsPrice,
                        Код_вида_процедуры = codeProcedureType,
                        Код_животного = codeAnimal,
                        Код_сотрудника = codeEmployee
                    });
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }


        }

        /// <summary>
        /// Добавляет Сотрудника в базу данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool AddEmployee(string nameBox, string secondNameBox, string surNameBox, string birthdayBox,
            string codePositionBox,string expBox,string salaryBox, string codeVeterinaryClinicBox)
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                DateTime birthday;
                int salary;
                int exp;
                int codePosition;
                int codeVeterinaryClinic;
                if ((DateTime.TryParse(birthdayBox, out birthday) && (birthday.Year <= DateTime.Now.Year)) &&
                    ((int.TryParse(salaryBox, out salary) && (salary >= 5000 && salary <= 300000))) &&
                    ((int.TryParse(expBox, out exp) && (exp >= 0) && exp <= DateTime.Now.Year - birthday.Year - 18)) &&
                    ((int.TryParse(codePositionBox, out codePosition) && (codePosition >= 1 && codePosition <= db.Должности.Count()))) &&
                    ((int.TryParse(codeVeterinaryClinicBox, out codeVeterinaryClinic) && (codeVeterinaryClinic >= 1 && codeVeterinaryClinic <= db.Ветеринарные_клиники.Count()))) &&
                    (!string.IsNullOrWhiteSpace(nameBox) && (nameBox.Length <= 40)) &&
                    (!string.IsNullOrWhiteSpace(secondNameBox) && (secondNameBox.Length <= 40)) &&
                    (!string.IsNullOrWhiteSpace(surNameBox) && (surNameBox.Length <= 40)))
                {
                    db.Сотрудники.Add(new Сотрудники
                    {
                        Имя = nameBox,
                        Фамилия = secondNameBox,
                        Отчество = surNameBox,
                        Дата_рождения = birthday,
                        Код_должности = codePosition,
                        Стаж = exp,
                        Код_ветеринарной_клиники = codeVeterinaryClinic,
                        Оклад = salary
                    });
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Добавляет Животного в базу данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool AddAnimal(string nameBox, string ageBox, string conditionsBox, string codeOwnerBox,
            string codeTypeAnimalBox)
        {
            using (var db = new Veterinary_ClinicEntities())
            {                
                int codeTypeAnimal;
                int codeOwner;
                int age;
                if (((int.TryParse(codeOwnerBox, out codeOwner) && (codeOwner >= 1) && codeOwner <= db.Владельцы.Count())) &&
                    ((int.TryParse(ageBox, out age) && (age >= 1)) &&
                    ((int.TryParse(codeTypeAnimalBox, out codeTypeAnimal) && (codeTypeAnimal >= 1 && codeTypeAnimal <= db.Виды_животных.Count()))) &&
                    (!string.IsNullOrWhiteSpace(nameBox) && (nameBox.Length <= 30)) &&
                    (!string.IsNullOrWhiteSpace(conditionsBox))))                
                {
                    db.Животные.Add(new Животные
                    {
                        Кличка_Животного = nameBox,
                        Условия_содержания_животного = conditionsBox,
                        Возраст_Животного = age,
                        Код_вида_животного = codeTypeAnimal,
                        Код_владельца = codeOwner
                    });
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Добавляет вид процедуры в базу данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool AddProcedureType(string procedureTypeBox)
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                if (!string.IsNullOrWhiteSpace(procedureTypeBox) && procedureTypeBox.Length <= 30)
                {
                    db.Виды_процедуры.Add(new Виды_процедуры
                    {
                        Вид_процедуры = procedureTypeBox
                    });
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Добавляет должность в базу данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool AddPosition(string positionBox)
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                if (!string.IsNullOrWhiteSpace(positionBox))
                {
                    db.Должности.Add(new Должности
                    {
                        Должность = positionBox
                    });
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Добавляет класс животного в базу данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool AddAnimalClass(string animalClassBox)
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                if (!string.IsNullOrWhiteSpace(animalClassBox) && animalClassBox.Length <= 15)
                {
                    db.Классы_животных.Add(new Классы_животных
                    {
                        Класс_животного = animalClassBox
                    });
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Добавляет вид животного в базу данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool AddAnimalType(string animalTypeBox,string codeAnimalClassBox)
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                int codeAnimalClass;
                if (!string.IsNullOrWhiteSpace(animalTypeBox) && animalTypeBox.Length <= 15 &&
                    (int.TryParse(codeAnimalClassBox, out codeAnimalClass) && codeAnimalClass >= 1 && codeAnimalClass <= db.Классы_животных.Count()))
                {
                    db.Виды_животных.Add(new Виды_животных
                    {
                        Вид_животного = animalTypeBox,
                        Код_класса_животного = codeAnimalClass
                    });
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Добавляет район в базу данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool AddDistrict(string districtBox)
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                if (!string.IsNullOrWhiteSpace(districtBox) && districtBox.Length <= 40)
                {
                    db.Районы.Add(new Районы
                    {
                        Район_города = districtBox
                    });
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Добавляет тип собственности в базу данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool AddOwnership(string ownershipBox)
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                if (!string.IsNullOrWhiteSpace(ownershipBox) && ownershipBox.Length <= 50)
                {
                    db.Тип_собственности.Add(new Тип_собственности
                    {
                        Тип_собственности1 = ownershipBox
                    });
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Добавляет лицензию в базу данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool AddLicense(string numberBox,string dateToEndBox,string codeVeterinaryClinicBox, byte[] imageData)
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                DateTime dateToEnd;
                int codeVeterinaryClinic;
                if (!string.IsNullOrWhiteSpace(numberBox) && numberBox.Length <= 10 &&
                    DateTime.TryParse(dateToEndBox, out dateToEnd) &&
                    int.TryParse(codeVeterinaryClinicBox, out codeVeterinaryClinic) && codeVeterinaryClinic >= 1 && codeVeterinaryClinic <= db.Ветеринарные_клиники.Count())
                {
                    db.Лицензии.Add(new Лицензии
                    {
                        Лицензия__ = numberBox,
                        Срок_окончания_лицензии = dateToEnd,
                        Код_ветеринарной_клинки = codeVeterinaryClinic,
                        Фото_лицензии = imageData
                    });
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

}

