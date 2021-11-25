using BusinessLogic.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace BusinessLogic.Utility
{
    public class Cookies
    {
        public static string GetCookie(string key)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[key];
            if (cookie != null)
            {
                return cookie.Value;
            }
            return "";
        }

        public static void SetCookie(string key, string value)
        {
            HttpContext.Current.Response.Cookies[key].Value = value;
            HttpContext.Current.Response.Cookies[key].Expires = DateTime.Now.AddDays(Convert.ToInt32(ConfigurationManager.AppSettings["CookiesExpirationNoOfDays"]));
        }

        public static void RemoveCookieByKey(string key)
        {
            HttpContext.Current.Response.Cookies[key].Expires = DateTime.Now.AddDays(-1);
        }
    }
}
