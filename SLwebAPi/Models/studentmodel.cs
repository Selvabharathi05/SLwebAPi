using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLwebAPi.Models
{
    public class studentmodel
    {
        [Required()]
        public int Roll_no
        {
            get; set;
        }
        [MaxLength(20, ErrorMessage = "Can't be more than 20")]
        public string StudentName
        {
            get;
            set;
        }

        public int Age
        {
            get; set;
        }
        public int Class
        {
            get; set;
        }
    }

}