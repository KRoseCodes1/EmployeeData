
﻿
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



        public bool CreateLocation(LocationCreate model)
        {
            var entity =
             new Location()
             {
                 LocationName = model.LocationName,
                 Address = model.Address,
                 PhoneNumber = model.PhoneNumber,
             };


            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public  IEnumerable<LocationlistItem> GetLocations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                  ctx
                      .Locations
                       .Select(
                            e =>
                                 new LocationlistItem
                                 {
                                     LocationName = e.LocationName,
                                     Address = e.Address,
                                     PhoneNumber = e.PhoneNumber,

                                 }
                              );

                return query.ToArray();

            }
        }

        public LocationlistItem GetLocationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Locations
                    .Single(e => e.LocationId == id);
                return


                        new LocationlistItem
                        {
                            LocationName = entity.LocationName,
                            PhoneNumber = entity.PhoneNumber,
                            Address = entity.Address,
                        };


            }



        }
        public bool UpdateLocation(LocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Locations
                    .Single(e => e.LocationId == model.LocationId);

                entity.Address = model.Address;
                entity.PhoneNumber = model.PhoneNumber;
                entity.LocationName = model.LocationName;

                return ctx.SaveChanges() == 1;

            }
        }
        public bool DeleteLocation(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Locations
                    .Single(e => e.LocationId == id);

                ctx.Locations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    } }






