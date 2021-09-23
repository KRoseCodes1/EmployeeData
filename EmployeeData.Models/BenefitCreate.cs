using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData.Models
{
    public class BenefitCreate
    {
        [Required]
        public string BenefitType { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public bool FullTimeOnly { get; set; }
    }
}
