using System.Linq;
using System.Data;
using DataAccessLayer;
using System.Data.Entity;
using System.Collections.Generic;
using BusinessLogic.Models;

namespace BusinessLogic.Repository
{
    public class Registration
    {
        public static uspGetUserByUserName_Result GetUserByUserName(string name)
        {
            exampleEntities4 db = new exampleEntities4();
            var editrow = db.uspGetUserByUserName(name).FirstOrDefault();
            return editrow;

        }
        public static UserData GetUserById(int id)
        {
            exampleEntities4 db = new exampleEntities4();
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
            }
            return userdata;
        }

        public static void AddUpdateUser(UserData obj)
        {
            exampleEntities4 db = new exampleEntities4();

            if (obj.UserId == 0)
            {
                var userdata = new User();
                userdata.UserName = obj.UserName;
                userdata.Password = obj.Password;
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
                    db.Entry(editdata).State = EntityState.Modified;
                }
            }
            db.SaveChanges();
        }

        public static IEnumerable<Country> GetCountries()
        {
            exampleEntities4 db = new exampleEntities4();
            var countrylist = db.Countries.ToList();
            return countrylist;
        }

        public static IEnumerable<State> GetStates(int id)
        {
            exampleEntities4 db = new exampleEntities4();
            var statelist = db.States.Where(m => m.CountryId == id).ToList();
            return statelist;
        }

        public static IEnumerable<City> GetCities(int id)
        {
            exampleEntities4 db = new exampleEntities4();
            var citylist = db.Cities.Where(m => m.StateId == id).ToList();
            return citylist;
        }

        public static IEnumerable<uspGetAllMembers_Result> GetMembers()
        {
            exampleEntities4 db = new exampleEntities4();
            var memberdata = db.uspGetAllMembers().ToList();
            return memberdata;
        }

        public static void DeleteRow(int id)
        {
            exampleEntities4 db = new exampleEntities4();
            var deleterow = db.Users.Where(m => m.UserId == id).FirstOrDefault();
            if (deleterow != null)
            {
                db.Entry(deleterow).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
