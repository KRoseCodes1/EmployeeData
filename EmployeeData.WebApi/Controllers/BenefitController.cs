using EmployeeData.Models;
using EmployeeData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EmployeeData.WebApi.Controllers
{
    public class BenefitController : ApiController
    {
        // api/benefit
        public IHttpActionResult Get()
        {
            BenefitService benefitService = new BenefitService();
            var benefits = benefitService.GetBenefits();
            return Ok(benefits);
        }
        // api/benefit
        public IHttpActionResult Post([FromBody]BenefitCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            BenefitService benefitService = new BenefitService();
            if (!benefitService.CreateBenefit(model))
                return InternalServerError();
            return Ok();
        }
        // api/benefit
        public IHttpActionResult Put([FromBody]BenefitEdit updatedModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            BenefitService benefitService = new BenefitService();
            if (!benefitService.UpdateBenefit(updatedModel))
                return InternalServerError();
            return Ok();
        }
        // api/benefit/{id}
        public IHttpActionResult Delete([FromUri]int id)
        {
            BenefitService benefitService = new BenefitService();
            if (!benefitService.RemoveBenefit(id))
                return InternalServerError();
            return Ok();
        }
        [HttpGet, Route("Benefit/parttime")]
        public IHttpActionResult GetAllPartTime()
        {
            BenefitService benefitService = new BenefitService();
            var benefits = benefitService.GetBenefitsForPartTime();
            return Ok(benefits);
        }
    }
}