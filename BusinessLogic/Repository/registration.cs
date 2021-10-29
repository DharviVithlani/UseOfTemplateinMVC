﻿using System.Linq;
using System.Data;
using DataAccess;
using System.Data.Entity;
using System.Collections.Generic;
using BusinessLogic.Models;
using System;

namespace BusinessLogic.Repository
{
    public class Registration
    {
        public static uspGetUserByUserName_Result GetUserByUserName(string name)
        {
            exampleEntities db = new exampleEntities();
            var editrow = db.uspGetUserByUserName(name).FirstOrDefault();
            return editrow;
        }

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

        public static void AddUpdateUser(UserData obj)
        {
            exampleEntities db = new exampleEntities();
            if (obj.UserId == 0)
            {
                var userdata = new User();
                userdata.UserName = obj.UserName;
                userdata.Password = obj.Password;
                userdata.CreatedDate = DateTime.Now;
                userdata.IsActive = true;
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

        public static IEnumerable<Country> GetCountries()
        {
            exampleEntities db = new exampleEntities();
            var countrylist = db.Countries.ToList();
            return countrylist;
        }

        public static IEnumerable<State> GetStates(int id)
        {
            exampleEntities db = new exampleEntities();
            var statelist = db.States.Where(m => m.CountryId == id).ToList();
            return statelist;
        }

        public static IEnumerable<City> GetCities(int id)
        {
            exampleEntities db = new exampleEntities();
            var citylist = db.Cities.Where(m => m.StateId == id).ToList();
            return citylist;
        }

        public static IEnumerable<uspGetAllMembers_Result> GetMembers(string search, string searchby, string searchtype)
        {
            exampleEntities db = new exampleEntities();
            var memberdata = db.uspGetAllMembers(search, searchby, searchtype).ToList();
            return memberdata;
        }

        public static void DeleteRow(int id)
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

        public static User GetUserDetailsById(int id)
        {
            exampleEntities db = new exampleEntities();
            var userdata = db.Users.Where(m => m.UserId == id).FirstOrDefault();
            return userdata;
        }
        public static void UpdatePassword(User obj)
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

        public static void AddLastLoginTimeStamp(int id, bool success)
        {
            exampleEntities db = new exampleEntities();
            var userdetails = db.Users.Where(m => m.UserId == id).FirstOrDefault();
            if (success == false)
            {
                userdetails.LastLoginAttempt = DateTime.Now;
                userdetails.LoginFailedCount = userdetails.LoginFailedCount == null ? 0 : userdetails.LoginFailedCount;
                //userdetails.LoginFailedCount = (userdetails.LoginFailedCount == null ? 0 : userdetails.LoginFailedCount) + 1;
                userdetails.LoginFailedCount++;
            }
            else
            {
                userdetails.LastLoginTimeStamp = DateTime.Now;
                userdetails.LoginFailedCount = 0;
            }
            db.Entry(userdetails).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
