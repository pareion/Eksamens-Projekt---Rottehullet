//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Brætspil
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Brætspil()
        {
            this.Udlån = new HashSet<Udlån>();
        }
    
        public int brætspilid { get; set; }
        public string brætspilnavn { get; set; }
        public string udgiver { get; set; }
        public Nullable<bool> udlånes { get; set; }
        public string kommentar { get; set; }
        public string kategori { get; set; }
        public Nullable<bool> udlånt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Udlån> Udlån { get; set; }
    }
}
