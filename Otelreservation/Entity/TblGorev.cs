//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Otelreservation.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblGorev
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblGorev()
        {
            this.TblPersonel = new HashSet<TblPersonel>();
        }
    
        public int GorevID { get; set; }
        public string GorevAD { get; set; }
        public Nullable<int> Departman { get; set; }
        public Nullable<int> Durum { get; set; }
    
        public virtual TblDepartman TblDepartman { get; set; }
        public virtual TblDurum TblDurum { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblPersonel> TblPersonel { get; set; }
    }
}
