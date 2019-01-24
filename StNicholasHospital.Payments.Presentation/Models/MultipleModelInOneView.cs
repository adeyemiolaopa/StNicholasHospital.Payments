using StNicholasHospital.Payments.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StNicholasHospital.Payments.Presentation.Models
{
    public class MultipleModelInOneView
    {
        public PatientDto Patient { get; set; }
        public List<PaymentDto> Payments { get; set; }

        public MultipleModelInOneView()
        {
            Patient = new PatientDto();
            Payments = new List<PaymentDto>();
        }
    }
}