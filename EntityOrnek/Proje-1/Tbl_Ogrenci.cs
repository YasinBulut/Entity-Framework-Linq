//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proje_1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Ogrenci
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Ogrenci()
        {
            this.Tbl_Not = new HashSet<Tbl_Not>();
        }
    
        public int ID { get; set; }
        public string AD { get; set; }
        public string SOYAD { get; set; }
        public string FOTOGRAF { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Not> Tbl_Not { get; set; }
    }
}