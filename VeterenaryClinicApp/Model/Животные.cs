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
    
    public partial class Животные
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Животные()
        {
            this.Процедуры = new HashSet<Процедуры>();
        }
    
        public int Код_животного { get; set; }
        public string Кличка_Животного { get; set; }
        public int Возраст_Животного { get; set; }
        public string Условия_содержания_животного { get; set; }
        public int Код_владельца { get; set; }
        public int Код_вида_животного { get; set; }
    
        public virtual Виды_животных Виды_животных { get; set; }
        public virtual Владельцы Владельцы { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Процедуры> Процедуры { get; set; }
    }
}
