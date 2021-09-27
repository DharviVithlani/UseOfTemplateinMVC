using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
  public class login
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required field")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required field")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
