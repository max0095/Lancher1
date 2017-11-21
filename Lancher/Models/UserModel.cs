using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lancher.Models
{
    public class UserModel
    {
        public string emailid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string facebook { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string education { get; set; }
        public string filename{ get; set; }
        public string birthday { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string password { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string confirmpassword { get; set; }







    }
}