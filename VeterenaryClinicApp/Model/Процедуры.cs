//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VeterenaryClinicApp.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Процедуры
    {
        public int Код_процедуры { get; set; }
        public System.DateTime Дата_оказания_помощи_животному { get; set; }
        public int Код_вида_процедуры { get; set; }
        public decimal Цена_процедуры { get; set; }
        public decimal Скидка_на_эту_процедуру { get; set; }
        public decimal Цена_материала_по_этой_процедуре { get; set; }
        public int Код_сотрудника { get; set; }
        public int Код_животного { get; set; }
    
        public virtual Виды_процедуры Виды_процедуры { get; set; }
        public virtual Животные Животные { get; set; }
        public virtual Сотрудники Сотрудники { get; set; }
    }
}
