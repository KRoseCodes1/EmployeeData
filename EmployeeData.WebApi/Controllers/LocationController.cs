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
            private LocationService LocationService()
            {
                var userID = Guid.Parse(userID.Identity.GetUserID());
                var LocationService = new LocationService(userID);
                return LocationService;
            }
            public IHttpActionResult Post(CreateLocation)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateLocationService();

                if (!service.CreateLocation(location))
                    return InternalServerError();

                return Ok();
            }
            public class IHttpActionResult Get(int id)
            {
                LocationService locationService = CreateLocationService();
                var location = locationService.GetLocationById(id);
                return Ok(location);
            }
        }

        public IHttpActionresult Put(LocationEdit location)
        {
            if (!ModelState.IsValid)
                return Badrequest(ModelState);

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

            return ok();

        }
    }

}
