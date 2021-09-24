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
    [Authorize]
    public class EmployeeController : ApiController
    {
        private EmployeeService CreateEmployeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var employeeService = new EmployeeService(userId);
            return employeeService;
        }

        public IHttpActionResult Get()
        {
            EmployeeService employeeService = CreateEmployeeService();
            var employees = employeeService.GetEmployees();
            return Ok(employees);
        }

        public IHttpActionResult Post(EmployeeCreate employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEmployeeService();

            if (!service.CreateEmployee(employee))
                return InternalServerError();

            return Ok();
        }
    }
}
