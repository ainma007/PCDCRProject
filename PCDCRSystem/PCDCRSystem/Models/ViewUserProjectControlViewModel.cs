using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PCDCRSystem.Models
{
    public class ViewUserProjectControlViewModel
    {


        [ScaffoldColumn(false)]
        public int ID
        {
            get;
            set;
        }
     
        public int? MYUserID
        {
            get;
            set;
        }
    
        public int? UserProjectID 
        {
            get;
            set;
        }

        
        [DisplayName("اسم المشروع:")]
        public string UserProjectName
        {
            get;
            set;
        }

        [DisplayName("تاريخ البدء:")]
        [DataType(DataType.Date)]
        public DateTime ProjecStartDate
        {
            get;
            set;
        }


        [DisplayName("تاريخ الانتهاء:")]
        [DataType(DataType.Date)]
        public DateTime ProjecEndDate
        {
            get;
            set;
        }
        [DisplayName("الحالة:")]
        public bool ProjecStatus
        {
            get;
            set;
        }

        [Required]
        [DisplayName("اسم البرنامج:")]
        public string ProjectProgram
        {
            get;
            set;
        }

    }
}