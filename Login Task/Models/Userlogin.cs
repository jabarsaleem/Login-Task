using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace Login_Task.Models
{
    public class Userlogin
    {
        [Key]
        [Required(ErrorMessage = "UserName is required")]
        public int ID { get; set; }
       [Required]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }
        
        public string email { get; set; }


        public string status { get; set; }
        public string role { get; set; }
    }
}
