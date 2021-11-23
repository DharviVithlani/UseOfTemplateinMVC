using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic.Repository
{
    public class Pincode
    {
        public static string AddPinCode(int id)
        {
            exampleEntities db = new exampleEntities();
            var pinCode = new PinCode();
            pinCode.UserId = id;
            pinCode.Pincode1 = Utility.RandomNumber.GetRandomNumber();
            pinCode.CreatedDate = DateTime.Now;
            pinCode.IsConfirm = false;
            db.PinCodes.Add(pinCode);
            db.SaveChanges();
            return pinCode.Pincode1.ToString();
        }

        public static string ConfirmUserByPinCode(string pincode)
        {
            exampleEntities db = new exampleEntities();
            var userPinCode = int.Parse(pincode);
            var pinCode = db.PinCodes.Where(m => m.Pincode1 == userPinCode).FirstOrDefault();
            if (pinCode != null)
            {
                if (pinCode.IsConfirm == false)
                {
                    pinCode.IsConfirm = true;
                    db.Entry(pinCode).State = EntityState.Modified;
                    db.SaveChanges();
                    return "Success";
                }
                else if (pinCode.IsConfirm == true)
                {
                    return "AlreadyConfirmed";
                }
            }
            return "Error";
        }
    }
}
