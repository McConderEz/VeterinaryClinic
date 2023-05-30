using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterenaryClinicApp.Model;

namespace VeterenaryClinicApp.Controller
{
    public static class Editer
    {
        /// <summary>
        /// Изменяет данные ветеринарной клиники в бд
        /// </summary>
        /// <returns>Возвращает true - если запись успешно изменена, иначе false</returns>
        public static bool EditVeterinaryClinic(int id,string regNumberBox, string ownershipTypeBox, string yearBox, string districtCodeBox,
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
                    var item = db.Ветеринарные_клиники.Find(id);
                    item.Номер_регистрационного_пункта = regNumber;
                    item.Код_типа_собственности = ownershipTypeCode;
                    item.Год_открытия = year;
                    item.Код_район_города = districtCode;
                    item.Название_пункта = name;
                    item.Адрес_пункта = address;
                    item.Телефон = phone;
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
        /// Изменяет данные владельца в базе данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool EditOwner(int id,string nameBox, string secondNameBox, string surNameBox, string phone, string birthdayBox)
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
                    var item = db.Владельцы.Find(id);
                    item.Имя = nameBox;
                    item.Фамилия = secondNameBox;
                    item.Отчество = surNameBox;
                    item.Дата_рождения_хозяина = birthday;
                    item.Телефон = phone;
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
        /// Изменяет данные процедуры в базе данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool EditProcedure(int id,string dataHelpBox, string codeProcedureTypeBox, string priceBox,
            string discountBox, string materialsPriceBox, string codeEmployeeBox, string codeAnimalBox)
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
                    var item = db.Процедуры.Find(id);
                    item.Дата_оказания_помощи_животному = dataHelp;
                    item.Цена_процедуры = price;
                    item.Скидка_на_эту_процедуру = discount;
                    item.Цена_материала_по_этой_процедуре = materialsPrice;
                    item.Код_вида_процедуры = codeProcedureType;
                    item.Код_животного = codeAnimal;
                    item.Код_сотрудника = codeEmployee;
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
        /// Изменяет данные Сотрудника в базе данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool EditEmployee(int id,string nameBox, string secondNameBox, string surNameBox, string birthdayBox,
            string codePositionBox, string expBox, string salaryBox, string codeVeterinaryClinicBox)
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
                    var item = db.Сотрудники.Find(id);
                    item.Имя = nameBox;
                    item.Фамилия = secondNameBox;
                    item.Отчество = surNameBox;
                    item.Дата_рождения = birthday;
                    item.Код_должности = codePosition;
                    item.Стаж = exp;
                    item.Код_ветеринарной_клиники = codeVeterinaryClinic;
                    item.Оклад = salary;
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
        /// Изменяет данные Животного в базе данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool EditAnimal(int id,string nameBox, string ageBox, string conditionsBox, string codeOwnerBox,
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
                    var item = db.Животные.Find(id);
                    item.Кличка_Животного = nameBox;
                    item.Условия_содержания_животного = conditionsBox;
                    item.Возраст_Животного = age;
                    item.Код_вида_животного = codeTypeAnimal;
                    item.Код_владельца = codeOwner;
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
        /// Изменяет данные вид процедуры в базе данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool EditProcedureType(int id,string procedureTypeBox)
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                if (!string.IsNullOrWhiteSpace(procedureTypeBox) && procedureTypeBox.Length <= 30)
                {
                    var item = db.Виды_процедуры.Find(id);
                    item.Вид_процедуры = procedureTypeBox;
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
        /// Изменяет данные должности в базе данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool EditPosition(int id,string positionBox)
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                if (!string.IsNullOrWhiteSpace(positionBox) && positionBox.Length <= 40)
                {
                    var item = db.Должности.Find(id);
                    item.Должность = positionBox;                   
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
        /// Изменяет класс животного в базе данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool EditAnimalClass(int id,string animalClassBox)
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                if (!string.IsNullOrWhiteSpace(animalClassBox) && animalClassBox.Length <= 15)
                {
                    var item = db.Классы_животных.Find(id);
                    item.Класс_животного = animalClassBox;
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
        /// Изменяет данные вид животного в базе данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool EditAnimalType(int id,string animalTypeBox, string codeAnimalClassBox)
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                int codeAnimalClass;
                if (!string.IsNullOrWhiteSpace(animalTypeBox) && animalTypeBox.Length <= 15 &&
                    (int.TryParse(codeAnimalClassBox, out codeAnimalClass) && codeAnimalClass >= 1 && codeAnimalClass <= db.Классы_животных.Count()))
                {
                    var item = db.Виды_животных.Find(id);
                    item.Вид_животного = animalTypeBox;
                    item.Код_класса_животного = codeAnimalClass;
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
        /// Изменяет данные района в базе данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool EditDistrict(int id,string districtBox)
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                if (!string.IsNullOrWhiteSpace(districtBox) && districtBox.Length <= 40)
                {
                    var item = db.Районы.Find(id);
                    item.Район_города = districtBox;
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
        /// Изменяет данные типа собственности в базе данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool EditOwnership(int id, string ownershipBox)
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                if (!string.IsNullOrWhiteSpace(ownershipBox) && ownershipBox.Length <= 50)
                {
                    var item = db.Тип_собственности.Find(id);
                    item.Тип_собственности1 = ownershipBox;
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
        /// Изменяет лицензию в базе данных
        /// </summary>
        /// <returns>Возвращает true - если запись успешно добавлено, иначе false</returns>
        public static bool EditLicense(int id,string numberBox, string dateToEndBox, string codeVeterinaryClinicBox, byte[] imageData)
        {
            using (var db = new Veterinary_ClinicEntities())
            {
                DateTime dateToEnd;
                int codeVeterinaryClinic;
                if (!string.IsNullOrWhiteSpace(numberBox) && numberBox.Length <= 10 &&
                    DateTime.TryParse(dateToEndBox, out dateToEnd) &&
                    int.TryParse(codeVeterinaryClinicBox, out codeVeterinaryClinic) && codeVeterinaryClinic >= 1 && codeVeterinaryClinic <= db.Ветеринарные_клиники.Count())
                {
                    var item = db.Лицензии.Find(id);
                    item.Лицензия__ = numberBox;
                    item.Срок_окончания_лицензии = dateToEnd;
                    item.Код_ветеринарной_клинки = codeVeterinaryClinic;
                    item.Фото_лицензии = imageData;
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
