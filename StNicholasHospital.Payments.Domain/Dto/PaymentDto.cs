using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StNicholasHospital.Payments.Domain.Dto
{
    public class PaymentDto
    {
        public string PaymentID { get; set; }
        public string PatientID { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public decimal Amount { get; set; }
        public string CreatedBy { get; set; }
    }
}
