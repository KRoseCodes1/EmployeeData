using EmployeeData.Data;
using EmployeeData.Models;
using EmployeeData.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData.Services
{
    public class BenefitService
    {
        public bool CreateBenefit(BenefitCreate model)
        {
            var entity = new Benefit() { BenefitType = model.BenefitType, Cost = model.Cost, FullTimeOnly = model.FullTimeOnly };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Benefits.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BenefitListItem> GetBenefits()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Benefits.Select(e => new BenefitListItem { BenefitId = e.BenefitId, BenefitType = e.BenefitType, Cost = e.Cost });
                return query.ToArray();
            }
        }
        public bool UpdateBenefit(BenefitEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Benefits.Single(e => e.BenefitId == model.BenefitId);
                entity.BenefitType = model.BenefitType;
                entity.Cost = model.Cost;
                entity.FullTimeOnly = model.FullTimeOnly;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool RemoveBenefit(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Benefits.Single(e => e.BenefitId == id);
                ctx.Benefits.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
