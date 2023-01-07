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
    
    public partial class COMMODITy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COMMODITy()
        {
            this.CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES = new HashSet<CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES>();
            this.EXPORT_COMMODITIES_RECEIPT_DETAIL = new HashSet<EXPORT_COMMODITIES_RECEIPT_DETAIL>();
            this.IMPORT_COMMODITIES_RECEIPT_DETAIL = new HashSet<IMPORT_COMMODITIES_RECEIPT_DETAIL>();
        }
    
        public int ID_COMMODITIES { get; set; }
        public int QUANTITY_ON_HAND { get; set; }
        public string PURCHASE_PRICE { get; set; }
        public string SELL_PRICE { get; set; }
        public Nullable<bool> IS_DELETED { get; set; }
        public string NAME_COMMODITIES { get; set; }
        public string UNIT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES> CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXPORT_COMMODITIES_RECEIPT_DETAIL> EXPORT_COMMODITIES_RECEIPT_DETAIL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IMPORT_COMMODITIES_RECEIPT_DETAIL> IMPORT_COMMODITIES_RECEIPT_DETAIL { get; set; }
    }
}
