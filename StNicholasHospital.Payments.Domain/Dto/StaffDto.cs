using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StNicholasHospital.Payments.Domain.Dto
{
    public class StaffDto
    {
        public string StaffID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string StaffNo { get; set; }
        public string Password { get; set; }
        public DateTime EntryDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
