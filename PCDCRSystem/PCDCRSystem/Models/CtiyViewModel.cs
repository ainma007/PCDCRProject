using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PCDCRSystem.Models
{
    public class CtiyViewModel
    {

        [ScaffoldColumn(false)]
        public int CityID
        {
            get;
            set;
        }

        [Required]
        [DisplayName("اسم المدينة:")]
        public string CityName
        {
            get;
            set;
        }


        [UIHint("ClientProvince")]
        public ProvinceViewModel Province
        {
            get;
            set;
        }
        [UIHint("ProvinceID")]
        [DisplayName("المحافظة")]
        public int? ProvinceID { get; set; }
    }
}