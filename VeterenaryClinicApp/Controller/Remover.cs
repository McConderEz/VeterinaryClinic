using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
