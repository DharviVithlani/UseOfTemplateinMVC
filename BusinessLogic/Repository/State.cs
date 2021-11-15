using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public class State
    {
        public static IEnumerable<DataAccess.State> GetStates(int id)
        {
            exampleEntities db = new exampleEntities();
            var statelist = db.States.Where(m => m.CountryId == id).ToList();
            return statelist;
        }
    }
}
