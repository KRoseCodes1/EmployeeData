using EmployeeData.Data;
using EmployeeData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData.Services
{
    public class EmployeeService
    {
        private readonly Guid _userId;

        public EmployeeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEmployee(EmployeeCreate model)
        {
            var entity = new Employee()
            {
                Name = model.Name,
                Email = model.Email,
                LocationId = model.LocationId,
                PositionId = model.PositionId,
                Benefits = model.Benefits
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Employees.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EmployeeListItem> GetEmployees()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Employees
                    .Select(e => new EmployeeListItem
                    {
                        EmployeeId = e.EmployeeId,
                        Name = e.Name,
                        Email = e.Email,
                        LocationId = e.LocationId,
                        PositionId = e.PositionId,
                    });
                return query.ToArray();
            }
        }

        public IEnumerable<EmployeeDetail> GetEmployeesByLocation(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Employees
                    .Where(e => e.LocationId == id)
                    .Select(e => new EmployeeDetail
                    {
                        EmployeeId = e.EmployeeId,
                        Name = e.Name,
                        Email = e.Email,
                        LocationId = e.LocationId,
                        PositionId = e.PositionId,
                        Benefits = e.Benefits
                    });

                return query.ToArray();
            }
        }

        public IEnumerable<EmployeeDetail> GetEmployeesByPosition(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Employees
                    .Where(e => e.PositionId == id)
                    .Select(e => new EmployeeDetail
                    {
                        EmployeeId = e.EmployeeId,
                        Name = e.Name,
                        Email = e.Email,
                        LocationId = e.LocationId,
                        PositionId = e.PositionId,
                        Benefits = e.Benefits
                    });

                return query.ToArray();
            }
        }

        public bool UpdateEmployee(EmployeeEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Employees
                    .Single(e => e.EmployeeId == model.EmployeeId);

                entity.EmployeeId = model.EmployeeId;
                entity.Name = model.Name;
                entity.Email = model.Email;
                entity.LocationId = model.LocationId;
                entity.PositionId = model.LocationId;
                entity.Benefits = entity.Benefits;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
