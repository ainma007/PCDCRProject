using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PCDCRSystem.Models
{
    public class ProjectViewModel
    {
        [ScaffoldColumn(false)]
        public int ProjectID
        {
            get;
            set;
        }

        [Required]
        [DisplayName("اسم المشروع:")]
        public string ProjectName
        {
            get;
            set;
        }

        [DisplayName("تاريخ البدء:")]
        [DataType(DataType.Date)]
        public DateTime StartDate
        {
            get;
            set;
        }


        [DisplayName("تاريخ الانتهاء:")]
        [DataType(DataType.Date)]
        public DateTime EndDate
        {
            get;
            set;
        }
        public bool Status
        {
            get;
            set;
        }

        [UIHint("ClientPrograme")]
        public ProgramsViewModel Programe
        {
            get;
            set;
        }
        [UIHint("ProgrameID")]
        [DisplayName("البرنامج:")]
        public int? ProgrameID { get; set; }
     
    }
}
