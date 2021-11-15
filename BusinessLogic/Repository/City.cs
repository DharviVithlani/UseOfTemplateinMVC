using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
   public class City
    {
        public static IEnumerable<DataAccess.City> GetCities(int id)
        {
            exampleEntities db = new exampleEntities();
            var citylist = db.Cities.Where(m => m.StateId == id).ToList();
            return citylist;
        }
    }   
}
