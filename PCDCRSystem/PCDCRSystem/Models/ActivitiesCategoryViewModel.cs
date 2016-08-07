using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PCDCRSystem.Models
{
    public class ActivitiesCategoryViewModel
    {
        [ScaffoldColumn(false)]
        public int ActivitiesCategoryID
        {
            get;
            set;
        }

        [Required]
        [DisplayName("اسم التصنيف:")]
        public string ActivitiesCategoryName
        {
            get;
            set;
        }
    }
}