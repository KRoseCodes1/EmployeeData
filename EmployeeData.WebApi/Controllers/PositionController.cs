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
        public IHttpActionResult GetAll()
        {
            PositionService positionService = CreatePositionServcie();
            var Positions = positionService.GetAllPosition();
            return Ok(Positions);
        }
        [HttpGet]
        public IHttpActionResult GetPositionById()
        {
            PositionService positionService = CreatePositionServcie();
            var positions = positionService.GetPositions();
            return Ok(positions);
        }
        [HttpPost]
        
        
    }
}
