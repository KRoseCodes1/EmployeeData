using EmployeeData.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData.Models
{
    public class EmployeeCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        [ForeignKey(nameof(Position))]
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

        //Questionable.

        [ForeignKey(nameof(Benefit))]
        public List<int> Benefits { get; set; }
        public virtual Benefit Benefit { get; set; }
    }
}
