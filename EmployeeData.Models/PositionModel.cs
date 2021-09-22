using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData.Models
{
    public class PositionCreate
    {
        public int PositionId { get; set; }
        public string Title { get; set; }
        public double PayRate { get; set; }
        [ForeignKey(nameof(Position))]
        public virtual Position Position { get; set; }
    }
    public class PositionList
    {
        public int PositionId { get; set; }
        public string Title { get; set; }
        public double PayRate { get; set; }
    }
    public class GetAllPosition
    {
       
        public int PositionId { get; set; }
        public string Title { get; set; }
        public double PayRate { get; set; }
    }
    public class UpdatePosition
    {
       
        public int PositionId { get; set; }
        public string Title { get; set; }
        public double PayRate { get; set; }
    }
     
}
