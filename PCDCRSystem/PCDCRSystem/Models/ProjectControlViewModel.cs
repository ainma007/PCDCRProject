using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace PCDCRSystem.Models
{
    public class ProjectControlViewModel
    {
        [ScaffoldColumn(false)]
        public int ID
        {
            get;
            set;
        }


        [UIHint("Clientproject")]
        public ProjectViewModel projects
        {
            get;
            set;
        }
       
        [UIHint("ProID")]
        public int? ProID { get; set; }

        [UIHint("ClientUser")]
        public UserViewModel Users
        {
            get;
            set;
        }

        [UIHint("UserID")]
        public int? UserID { get; set; }

        public bool Status { get; set; }



    }


}