using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
   public class ChangePassword
    {
        [Display(Name ="Current Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Current Password is Required.")]
        public string CurrentPassword { get; set; }

        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "New Password is Required.")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is Required.")]
        [Compare("NewPassword", ErrorMessage = "Password and Confirm password do not match.")]
        public string Confirmpassword { get; set; }
    }
}
