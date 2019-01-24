using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StNicholasHospital.Payments.Presentation.Models
{
    public class CalculateModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPayment { get; set; }
        public string PatientID { get; set; }
    }

}