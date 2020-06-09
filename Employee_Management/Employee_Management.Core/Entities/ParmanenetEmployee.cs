using System;
using System.Collections.Generic;
using System.Text;
using static Employee_Management.Core.Entities.Enamurations;

namespace Employee_Management.Core.Entities
{
    public class ParmanenetEmployee:Employee
    {
        public PaymentType PaymentType { get; set; }
    }
}
