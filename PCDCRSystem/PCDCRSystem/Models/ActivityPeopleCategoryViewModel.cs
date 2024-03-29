﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PCDCRSystem.Models
{
    public class ActivityPeopleCategoryViewModel
    {
        [ScaffoldColumn(false)]
        public int ActivityPeopleCategoryID
        {
            get;
            set;
        }

        [Required]
        [DisplayName("اسم التصنيف:")]
        public string ActivityPeopleCategoryName
        {
            get;
            set;
        }
    }
}