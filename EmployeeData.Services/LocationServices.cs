using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData.Services
{
   public class LocationServices
   {
        private readonly Guid _userId;
        public LocationServices(Guid userId)
        {
            _userId = userId;
        }

    }
    public bool CreateLocation(LocationCreate model)
    {
        var entity = 
            new Post()
            {
               LocationName = model.LocationName,
               Address = model.Address,
               PhoneNumber = model.PhoneNumber
            }
    }


}
