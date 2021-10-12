using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BusinessLogic.Models
{
  public class UserData
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        [Display(Name = "Country")]
        public Nullable<int> CountryId { get; set; }

        [Display(Name = "State")]
        public Nullable<int> StateId { get; set; }

        [Display(Name = "City")]
        public Nullable<int> CityId { get; set; }

        [RegularExpression(@"\d{6}", ErrorMessage = "ZipCode must be in 6 digits.")]
        public Nullable<int> ZipCode { get; set; }

        [DisplayName("Choose File")]
        public string ProfileImage { get; set; }

        public int ModifiedBy { get; set; }

        //Extra columns

        [Required(ErrorMessage = "Confirm Password is required.")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and Confirm password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string ErrorMessage { get; set; }

        public bool isSuccess { get; set; }
        public IEnumerable<SelectListItem> countries { get; set; }

        public IEnumerable<SelectListItem> states { get; set; }

        public IEnumerable<SelectListItem> cities { get; set; }
    }
}
