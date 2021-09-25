using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData.Models
{
    public class EmployeeEdit
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int LocationId { get; set; }
        public int PositionId { get; set; }
        public List<int> Benefits { get; set }
    }
}
