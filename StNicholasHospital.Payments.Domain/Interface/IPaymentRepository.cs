using StNicholasHospital.Payments.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StNicholasHospital.Payments.Domain.Interface
{
    public interface IPaymentRepository
    {
        void Add(string paymentID, string patientID, string description, decimal amount, string createdBy);
        PaymentDto FindByID(string paymentID);
        List<PaymentDto> GetPaymentsByPatientID(string patientID);
        decimal GetTotalPaymentByPatientID(string patientID, DateTime startDate, DateTime endDate);

    }
}
