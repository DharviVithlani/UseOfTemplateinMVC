using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
   public class Country
    {
        public static IEnumerable<DataAccess.Country> GetCountries()
        {
            exampleEntities db = new exampleEntities();
            var countrylist = db.Countries.ToList();
            return countrylist;
        }
    }
}
