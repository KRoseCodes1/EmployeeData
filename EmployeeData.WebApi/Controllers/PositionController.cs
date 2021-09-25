using EmployeeData.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeData.Models;

namespace EmployeeData.WebApi.Controllers
{
    [Authorize]
    public class PositionController : ApiController
    {
        private PositionService CreatePositionServcie()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var positionService = new PositionService(userId);
            return positionService;
        }
        [HttpGet]
        [Route("api/position")]
        public IHttpActionResult GetAll()
        {
            PositionService positionService = CreatePositionServcie();
            var Positions = positionService.GetAllPosition();
            return Ok(Positions);
        }
        [HttpGet]
        [Route("api/position/{Id}")]
        public IHttpActionResult GetPosition()
        {
            PositionService positionService = CreatePositionServcie();
            var positions = positionService.GetPositionsById();
            return Ok(positions);
        }
        [HttpPost]
        public IHttpActionResult CreateNewPosition(PositionCreate position)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePositionServcie();
            if (!service.CreatePosition(position))
                return InternalServerError();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult UpdateCurrentPosition(UpdatePosition position)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePositionServcie();
            if (!service.PositionEdit(position))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeletePosition(int positionId)
        {
            var service = CreatePositionServcie();
            if (!service.DeletePosition(positionId))
                return InternalServerError();
            return Ok();
        }
    }
}
