using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Utility
{
    public class RandomNumber
    {
        public static int GetRandomNumber()
        {
            string numbers = "0123456789";
            Random random = new Random();
            string otp = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                int tempval = random.Next(0, numbers.Length);
                otp += tempval;
            }
            return Convert.ToInt32(otp);
        }
    }
}
