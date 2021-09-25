using EmployeeData.Data;
using EmployeeData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Position = EmployeeData.Data.Position;

namespace EmployeeData.Services
{
    public class PositionService
    {
        private readonly Guid _userId;
        public PositionService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePosition(PositionCreate model)
        {
            var entity = new Position()
            {
                PositionId = model.PositionId,
                Title = model.Title,
                PayRate = model.PayRate
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Positions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PositionList> GetAllPosition()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Positions.Select(e => new PositionList
                { PositionId = e.PositionId, Title = e.Title, PayRate = e.PayRate });

                return query.ToArray();
            }
        }
        public IEnumerable<PositionList> GetPositionsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Positions.Where(e => id == e.PositionId).Select
                    (e => new PositionList { PositionId = e.PositionId, Title = e.Title,});
                return query.ToArray();
 
            }
        }
        public bool PositionEdit(UpdatePosition model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Positions
                .Single(e => e.PositionId == model.PositionId);
                entity.PositionId = model.PositionId;
                entity.Title = model.Title;
                entity.PayRate = model.PayRate;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePosition(int positionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Positions
                .Single(e => e.PositionId == positionId);
                ctx.Positions.Remove(entity);
                return ctx.SaveChanges() == 1;
                
            }

        }

        
    }
}
