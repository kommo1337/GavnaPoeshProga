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
    
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Order = new HashSet<Order>();
        }
    
        public int IdCustomer { get; set; }
        public string LastNameCustomer { get; set; }
        public string FirstNameCustomer { get; set; }
        public string MiddleNameCustomer { get; set; }
        public string PhoneNumberCustomer { get; set; }
        public int IdGender { get; set; }
        public string EmailCustomer { get; set; }
        public Nullable<int> IdOrder { get; set; }
        public System.DateTime Birthday { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
