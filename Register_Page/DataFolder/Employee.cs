//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Register_Page.DataFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Order = new HashSet<Order>();
        }
    
        public int IdEmployee { get; set; }
        public string LastNameEmployee { get; set; }
        public string FirstNameEmployee { get; set; }
        public string MiddleNameEmployee { get; set; }
        public string PhoneNumberEmployee { get; set; }
        public string EmailEmployee { get; set; }
        public int IdGender { get; set; }
        public int IdAdress { get; set; }
        public string ExperienceEmployee { get; set; }
        public string SerialPassport { get; set; }
        public string NumberPassport { get; set; }
    
        public virtual Adress Adress { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
