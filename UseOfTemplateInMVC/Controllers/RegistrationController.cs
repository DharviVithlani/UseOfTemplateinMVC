using System;
using System.Web.Mvc;
using DataAccess;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Models;

namespace UseOfTemplateInMVC.Controllers
{
    public class RegistrationController : Controller
    {
        public ActionResult NewRegistration()
        {
            return View("Registration");
        }
        public ActionResult Registration(int id)
        {
            try
            {
                if (id==0)
                {
                    return View();
                }
                else
                {
                    var model = BusinessLogic.Repository.Registration.GetUserById(id);
                    GetDropDownData(model);
                    return View(model);
                }
            }
            catch (Exception e)
            {

            }
            return View();
        }

        public ActionResult GetStateList(int CountryId)
        {
            IEnumerable<State> statelist = BusinessLogic.Repository.Registration.GetStates(CountryId);
            return PartialView("GetStateList", statelist);
        }

        public ActionResult GetCityList(int StateId)
        {
            IEnumerable<City> citylist = BusinessLogic.Repository.Registration.GetCities(StateId);
            return PartialView("GetCityList", citylist);
        }

        [HttpPost]
        public ActionResult Registration(UserData obj)
        {
            try
            {
                if (obj.UserId != 0)
                {
                    BusinessLogic.Repository.Registration.AddUpdateUser(obj);
                    obj.isSuccess = true;
                    obj.ErrorMessage = "Your profile has been Updated.";
                    GetDropDownData(obj);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        var userexists = BusinessLogic.Repository.Registration.GetUserByUserName(obj.UserName);
                        if (userexists != null)
                        {
                            obj.isSuccess = false;
                            obj.ErrorMessage = "Already exists please choose another name.";
                        }
                        else
                        {
                            BusinessLogic.Repository.Registration.AddUpdateUser(obj);
                            obj.isSuccess = true;
                            obj.ErrorMessage = obj.UserName + " has been Added.";
                            obj.UserName = "";
                            ModelState.Clear();
                        }
                    }
                }
            }

            catch (Exception e)
            {

            }
            return View(obj);
        }
        public UserData GetDropDownData(UserData userData)
        {
            var countrydata = BusinessLogic.Repository.Registration.GetCountries();
            List<SelectListItem> items = countrydata.Select(x => new SelectListItem { Text = x.CountryName, Value = x.CountryID.ToString() }).ToList();
            items.Insert(0, new SelectListItem { Text = "Select Country", Value = "0" });
            userData.countries = items;

            var statedata = BusinessLogic.Repository.Registration.GetStates(Convert.ToInt32(userData.CountryId));
            List<SelectListItem> statelist = statedata.Select(x => new SelectListItem { Text = x.StateName, Value = x.StateId.ToString() }).ToList();
            statelist.Insert(0, new SelectListItem { Text = "Select State", Value = "0" });
            userData.states = statelist;

            var citydata = BusinessLogic.Repository.Registration.GetCities(Convert.ToInt32(userData.StateId));
            List<SelectListItem> citylist = citydata.Select(x => new SelectListItem { Text = x.CityName, Value = x.CityId.ToString() }).ToList();
            citylist.Insert(0, new SelectListItem { Text = "Select City", Value = "0" });
            userData.cities = citylist;
            return userData;
        }
    }
}