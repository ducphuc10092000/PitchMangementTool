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
    
    public partial class IMPORT_COMMODITIES_RECEIPT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IMPORT_COMMODITIES_RECEIPT()
        {
            this.IMPORT_COMMODITIES_RECEIPT_DETAIL = new HashSet<IMPORT_COMMODITIES_RECEIPT_DETAIL>();
        }
    
        public int ID_IMPORT_COMMODITIES_RECEIPT { get; set; }
        public string TOTAL_COST { get; set; }
        public int ID_COMMODITIES_PROVIDER { get; set; }
        public System.DateTime CREATE_AT { get; set; }
        public Nullable<System.DateTime> UPDATE_AT { get; set; }
        public int CREATE_BY_ID_USER { get; set; }
        public Nullable<int> UPDATE_BY_ID_USER { get; set; }
        public bool IS_DELETED { get; set; }
    
        public virtual COMMODITIES_PROVIDER COMMODITIES_PROVIDER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IMPORT_COMMODITIES_RECEIPT_DETAIL> IMPORT_COMMODITIES_RECEIPT_DETAIL { get; set; }
        public virtual USER USER { get; set; }
        public virtual USER USER1 { get; set; }
    }
}