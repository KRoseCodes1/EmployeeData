﻿using EmployeeData.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
    public bool CreateLocation(LocationCreate model)
    {
        var entity =
            new Location()
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

        public IEnumerable<LocationListItem> GetLocations()
        {
            using (var ctx = new Application())
            {
                var query = 
                    ctx
                        .Locations
                        .Where(else => else.OwnerId == _userId)
                        .Select(
                             else =>
                                  new Location
                                  {
                                     LocationName = e.LocationName,
                                     Address
                                     PhoneNumber

                                  };
                                return Query.ToArray();
                                                                  
            }
        }
    }




