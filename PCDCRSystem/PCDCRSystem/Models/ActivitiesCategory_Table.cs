//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PCDCRSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActivitiesCategory_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ActivitiesCategory_Table()
        {
            this.ProjectActivities_Table = new HashSet<ProjectActivities_Table>();
        }
    
        public int ID { get; set; }
        public string ActivitiesCategoryName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectActivities_Table> ProjectActivities_Table { get; set; }
    }
}
