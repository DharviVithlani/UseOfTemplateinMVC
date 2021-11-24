using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class UserPinInfo
    {
        public Nullable<int> UserId { get; set; }
        public string UserName { get; set; }
        public Nullable<int> Pincode { get; set; }
        public Nullable<bool> IsConfirm { get; set; }
    }
}
