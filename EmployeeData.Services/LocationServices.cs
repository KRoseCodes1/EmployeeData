using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeData.Models;
using EmployeeData.Data;

namespace EmployeeData.Services
{
    public class LocationServices
    {
        private readonly Guid _userId;
        public LocationServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLocation(LocationCreate model)
        {
            var entity = new Location()
            {
                LocationName = model.LocationName,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LocationListItem> GetLocations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Locations
                    .Select(e => new LocationListItem
                    {
                        LocationName = e.LocationName,
                        Address = e.Address,
                        PhoneNumber = e.PhoneNumber
                    }
                    );
                return query.ToArray();

            }
        }
    }
}




