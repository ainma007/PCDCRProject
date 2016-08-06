using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace PCDCRSystem.Models
{
    public class CorporationViewModel
    {


        [ScaffoldColumn(false)]
        public int CorporationID
        {
            get;
            set;
        }

        [Required]
        [DisplayName("اسم المؤسسة:")]
        public string CorporationName
    {
            get;
            set;
        }


        
        [DisplayName("هاتف المؤسسة:")]
        public string CorporationPhone
        {
            get;
            set;
        }



       
        [DisplayName("عنوان المؤسسة:")]
        public string CorporationAdderss
        {
            get;
            set;
        }


    }
}