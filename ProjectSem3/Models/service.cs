//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectSem3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public service()
        {
            this.favorite_service = new HashSet<favorite_service>();
            this.fees = new HashSet<fee>();
        }
        public service(int id, string name,string des)
        {
            this.service_id = id;
                this.service_name = name;
                this.description = des;
        }
        public int service_id { get; set; }
        [DisplayName("Service Name")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Service Name is not empty???!")]
        public string service_name { get; set; }
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Description is not empty???!")]
        public string description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<favorite_service> favorite_service { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fee> fees { get; set; }
    }
}
