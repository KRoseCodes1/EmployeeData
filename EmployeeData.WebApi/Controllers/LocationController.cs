using EmployeeData.Models;
using EmployeeData.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeData.WebApi.Controllers
{
    public class LocationController : ApiController
    {
    [Authorize]
    public class LocationController : ApiController
    {
        private LocationServices CreateLocationService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var LocationService = new LocationServices(userID);
            return LocationService;
        }
        public IHttpActionResult Post(LocationCreate location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLocationService();

            if (!service.CreateLocation(location))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            LocationServices locationService = CreateLocationService();
            var location = locationService.GetLocations();
            return Ok(location);
        }
        public IHttpActionResult GetById(int id)
        {
            LocationServices locationService = CreateLocationService();
            var location = locationService.GetLocationById(id);
            return Ok(location);
        }
        }

        public IHttpActionResult Put(LocationEdit location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLocationService();

            if (!service.UpdateLocation(location))
                return InternalServerError();

            return Ok();

        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateLocationService();

            if (!service.DeleteLocation(id))
                return InternalServerError();

            return Ok();
        }
    }
  }

}
