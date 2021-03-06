using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData.Data
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }
        [Required]
        public string Title { get; set; }
        public double PayRate { get; set; }
    }
}
