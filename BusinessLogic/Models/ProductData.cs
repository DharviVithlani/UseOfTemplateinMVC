using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public partial class ProductData
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Product Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Product Price is required.")]
        public Nullable<int> Price { get; set; }

        [Display(Name = "Image")]
        public string ProductImage { get; set; }
    }
}
