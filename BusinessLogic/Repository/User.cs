using BusinessLogic.Common;
using BusinessLogic.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
   public class User
    {
        public static UserData GetUserById(int id)
        {
            exampleEntities db = new exampleEntities();
            var userdata = new UserData();
            var editrow = db.Users.Where(m => m.UserId == id).FirstOrDefault();
            if (editrow != null)
            {
                userdata.UserId = editrow.UserId;
                userdata.UserName = editrow.UserName;
                userdata.Password = editrow.Password;
                userdata.ConfirmPassword = editrow.Password;
                userdata.FirstName = editrow.FirstName;
                userdata.LastName = editrow.LastName;
                userdata.DOB = editrow.DOB;
                userdata.Address = editrow.Address;
                userdata.Gender = editrow.Gender;
                userdata.CountryId = editrow.CountryId;
                userdata.StateId = editrow.StateId;
                userdata.CityId = editrow.CityId;
                userdata.ZipCode = editrow.ZipCode;
                userdata.IsActive = editrow.IsActive;
            }
            return userdata;
        }

        public static uspGetUserByUserName_Result GetUserByUserName(string name)
        {
            exampleEntities db = new exampleEntities();
            var editrow = db.uspGetUserByUserName(name).FirstOrDefault();
            return editrow;
        }
        public static void AddUpdateUser(UserData obj)
        {
            exampleEntities db = new exampleEntities();
            if (obj.UserId == 0)
            {
                var userdata = new DataAccess.User();
                userdata.UserName = obj.UserName;
                userdata.Password = obj.Password;
                userdata.CreatedDate = DateTime.Now;
                userdata.IsActive = true;
                userdata.IsBlock = false;
                db.Users.Add(userdata);
            }
            else
            {
                if (obj != null)
                {
                    var editdata = db.Users.Where(m => m.UserId == obj.UserId).FirstOrDefault();
                    editdata.FirstName = obj.FirstName;
                    editdata.LastName = obj.LastName;
                    editdata.DOB = obj.DOB;
                    editdata.Gender = obj.Gender;
                    editdata.Address = obj.Address;
                    editdata.CountryId = obj.CountryId;
                    editdata.StateId = obj.StateId;
                    editdata.CityId = obj.CityId;
                    editdata.ZipCode = obj.ZipCode;
                    editdata.ModifiedDate = DateTime.Now;
                    editdata.ModifiedBy = obj.ModifiedBy;
                    editdata.IsActive = obj.IsActive;
                    db.Entry(editdata).State = EntityState.Modified;
                }
            }
            db.SaveChanges();
        }
        public static IEnumerable<uspGetAllMembers_Result> GetMembers(string search, string searchby, string searchtype)
        {
            exampleEntities db = new exampleEntities();
            var memberdata = db.uspGetAllMembers(search, searchby, searchtype).ToList();
            return memberdata;
        }
        public static void DeleteUser(int id)
        {
            exampleEntities db = new exampleEntities();
            var deleterow = db.Users.Where(m => m.UserId == id).FirstOrDefault();
            if (deleterow != null)
            {
                db.Entry(deleterow).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public static string UpdateUserProfile(int id, string imagepath)
        {
            exampleEntities db = new exampleEntities();
            var userdata = db.uspUploadProfile(id, imagepath).ToString();
            return userdata;
        }

        public static DataAccess.User GetUserDetailsById(int id)
        {
            exampleEntities db = new exampleEntities();
            var userdata = db.Users.Where(m => m.UserId == id).FirstOrDefault();
            return userdata;
        }
        public static void UpdatePassword(DataAccess.User obj)
        {
            exampleEntities db = new exampleEntities();
            obj.LastPasswordChanged = DateTime.Now;
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
        public static IEnumerable<uspGetAllUsers_Result> GetAllUsers()
        {
            exampleEntities db = new exampleEntities();
            var userDetails = db.uspGetAllUsers().ToList();
            return userDetails;
        }

        public static DataAccess.User AddLastLoginTimeStamp(int id, bool success)
        {
            exampleEntities db = new exampleEntities();
            var userdetails = db.Users.Where(m => m.UserId == id).FirstOrDefault();
            if (success == false)
            {
                userdetails.LoginFailedCount = userdetails.LoginFailedCount == null ? 0 : userdetails.LoginFailedCount;
                userdetails.LoginFailedCount++;
                if (userdetails.LoginFailedCount < 6)
                {
                    userdetails.LastLoginAttempt = DateTime.Now;
                }
                else
                {
                    userdetails.IsBlock = true;
                    DateTime currentTime = Convert.ToDateTime(userdetails.LastLoginAttempt);
                    DateTime blockedTime = currentTime.AddHours(Constants.BlockedHours);
                    if (blockedTime <= DateTime.Now)
                    {
                        userdetails.LastLoginAttempt = DateTime.Now;
                        userdetails.LoginFailedCount = 0;
                    }
                }
            }
            else
            {
                DateTime currentTime = Convert.ToDateTime(userdetails.LastLoginAttempt);
                DateTime blockedTime = currentTime.AddHours(Constants.BlockedHours);
                if (blockedTime <= DateTime.Now)
                {
                    userdetails.IsBlock = false;
                }
                if (userdetails.IsBlock != true)
                {
                    userdetails.LastLoginTimeStamp = DateTime.Now;
                    userdetails.LoginFailedCount = 0;
                }
            }
            db.Entry(userdetails).State = EntityState.Modified;
            db.SaveChanges();
            return userdetails;
        }
    }
}
