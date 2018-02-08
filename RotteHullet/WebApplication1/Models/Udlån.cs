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
    
    public partial class Udlån
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Udlån()
        {
            this.Bog = new HashSet<Bog>();
            this.Brætspil = new HashSet<Brætspil>();
            this.Lokale = new HashSet<Lokale>();
            this.Udstyr = new HashSet<Udstyr>();
        }
    
        public int udlånid { get; set; }
        public Nullable<System.DateTime> udlåningsdato { get; set; }
        public Nullable<System.DateTime> afleveringsdato { get; set; }
        public Nullable<System.DateTime> reeleafleveringsdato { get; set; }
        public Nullable<int> medlemid { get; set; }
    
        public virtual Medlem Medlem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bog> Bog { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Brætspil> Brætspil { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lokale> Lokale { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Udstyr> Udstyr { get; set; }
    }
}
