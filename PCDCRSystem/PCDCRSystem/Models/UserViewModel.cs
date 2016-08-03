using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PCDCRSystem.Models
{
    public class UserViewModel
    {
        [ScaffoldColumn(false)]
        public int UserID
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Full Name")]
        public string FullName
        {
            get;
            set;
        }

        
        [DisplayName("UserName")]
        public string Username
        {
            get;
            set;
        }

        
        [DisplayName("Password")]
        public string Password
        {
            get;
            set;
        }

        
        [DisplayName("UserType")]
        public string UserType
        {
            get;
            set;
        }
        
        [DisplayName("UserPhone")]
        public string UserPhone
        {
            get;
            set;
        }

     
        [DisplayName("UserAddress")]
        public string UserAddress
        {
            get;
            set;
        }
        public bool userstatus
        {
            get;
            set;
        }
    }
}