//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain.PitchManagementTool
{
    using System;
    using System.Collections.Generic;
    
    public partial class CUSTOMER_PAYMENT_RECEIPT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMER_PAYMENT_RECEIPT()
        {
            this.CUSTOMER_PAYMENT_RECEIPT_DETAIL_USED_PITCH = new HashSet<CUSTOMER_PAYMENT_RECEIPT_DETAIL_USED_PITCH>();
        }
    
        public int ID_CUSTOMER_PAYMENT_RECEIPT { get; set; }
        public int ID_CUSTOMER { get; set; }
        public string TOTAL_COST { get; set; }
        public System.DateTime CREATE_AT { get; set; }
        public int CREATE_BY_ID_USER { get; set; }
        public Nullable<System.DateTime> UPDATE_AT { get; set; }
        public Nullable<int> UPDATE_BY_ID_USER { get; set; }
        public bool IS_DELETED { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUSTOMER_PAYMENT_RECEIPT_DETAIL_USED_PITCH> CUSTOMER_PAYMENT_RECEIPT_DETAIL_USED_PITCH { get; set; }
        public virtual USER USER { get; set; }
        public virtual USER USER1 { get; set; }
    }
}
