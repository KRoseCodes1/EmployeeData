using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData.Models
{
    public class BenefitEdit
    {
        public int BenefitId { get; set; }
        public string BenefitType { get; set; }
        public double Cost { get; set; }
        public bool FullTimeOnly { get; set; }
    }
}
