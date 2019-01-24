using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StNicholasHospital.Payments.Domain.Dto
{
    public class PatientDto
    {
        public string PatientID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public DateTime EntryDate { get; set; }
        public string CreatedBy { get; set; }
        public decimal TotalPayment { get; set; }
    }
}
    