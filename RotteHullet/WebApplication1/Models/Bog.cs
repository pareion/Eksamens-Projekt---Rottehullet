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
    
    public partial class Bog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bog()
        {
            this.Udlån = new HashSet<Udlån>();
        }
    
        public int bogid { get; set; }
        public string titel { get; set; }
        public string familie { get; set; }
        public string subkategori { get; set; }
        public string forfatter { get; set; }
        public string genre { get; set; }
        public string forlag { get; set; }
        public string kommentar { get; set; }
        public Nullable<bool> udlånes { get; set; }
        public Nullable<bool> udlånt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Udlån> Udlån { get; set; }
    }
}
