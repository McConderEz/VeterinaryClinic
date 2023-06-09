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
    
    public partial class Ветеринарные_клиники
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ветеринарные_клиники()
        {
            this.Лицензии = new HashSet<Лицензии>();
            this.Сотрудники = new HashSet<Сотрудники>();
        }
    
        public int Код_ветеринарной_клиники { get; set; }
        public int Номер_регистрационного_пункта { get; set; }
        public int Код_типа_собственности { get; set; }
        public int Год_открытия { get; set; }
        public string Адрес_пункта { get; set; }
        public string Название_пункта { get; set; }
        public int Код_район_города { get; set; }
        public string Телефон { get; set; }
    
        public virtual Районы Районы { get; set; }
        public virtual Тип_собственности Тип_собственности { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Лицензии> Лицензии { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Сотрудники> Сотрудники { get; set; }
    }
}
