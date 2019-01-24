using StNicholasHospital.Payments.Domain.Dto;
using StNicholasHospital.Payments.Domain.Exceptions;
using StNicholasHospital.Payments.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StNicholasHospital.Payments.Domain.Service
{
    public class PaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPatientRepository _patientRepository;

        public PaymentService(IPaymentRepository paymentRepository, IPatientRepository patientRepository)
        {
            _paymentRepository = paymentRepository;
            _patientRepository = patientRepository;
        }

        public PaymentDto CreatePayment(string patientID, string description, decimal amount, string createdBy)
        {
            var paymentID = Guid.NewGuid().ToString();

            if (string.IsNullOrEmpty(patientID)) {
                throw new Exception("The PatientID cannot be null!");
            }

            if (string.IsNullOrEmpty(description)) {
                throw new Exception("The Description cannot be null!");
            }

            if (amount <= 0) {
                throw new Exception("The Amount cannot be less or equal to 0!");
            }

            if (string.IsNullOrEmpty(createdBy)) {
                throw new Exception("The CreatedBy cannot be null!");
            }

            var patientDto = _patientRepository.FindByID(patientID);

            if (patientDto == null) {
                throw new InvalidPatientIDException("The PatientID does not exist!!");
            }

            try {
                _paymentRepository.Add(paymentID, patientID, description, amount, createdBy);

                    var paymentDto = GetByID(paymentID);

                    if (paymentDto == null) {
                        throw new InvalidPaymentIDException("The PaymentID does not exist!");
                    }

                    return paymentDto;
            }
            catch (SqlException ex) {
                throw new InvalidPatientIDException("The PatientID does not exist! " + ex.Message);
            }
            
        }

        public PaymentDto GetByID(string paymentID)
        {
            if (string.IsNullOrEmpty(paymentID)) {
                throw new Exception("The PaymentID cannot be null!");
            }

            var paymentDto = _paymentRepository.FindByID(paymentID);

            if (paymentDto == null) {
                throw new InvalidPaymentIDException("The PaymentID is not correct!");
            }

            return paymentDto;
        }

        public decimal GetTotalPaymentByPatientID(string patientID, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(patientID)) {
                throw new Exception("The PatientID cannot be null!");
            }

            if (endDate <= startDate) {
                throw new Exception("The EndDate cannot be less than or equal the StartDate!");
            }

            var patientDto = _patientRepository.FindByID(patientID);

            if (patientDto == null) {
                throw new InvalidPatientIDException("The PatientID is not correct!");
            }

            decimal totalPayment;

            try {
                totalPayment = _paymentRepository.GetTotalPaymentByPatientID(patientID, startDate, endDate);
            }
            catch (Exception) {
                throw new InvalidPatientIDException("An error ocurred during processing!");
            }

            return totalPayment;
        }

        public List<PaymentDto> GetPaymentsByPatientID(string patientID)
        {
            if (string.IsNullOrEmpty(patientID)) {
                throw new Exception("The PatientID cannot be null!");
            }

            try {
                var payments = _paymentRepository.GetPaymentsByPatientID(patientID);
                return payments;
            }
            catch (Exception) {
                throw new InvalidPatientIDException("An error ocurred during processing!");
            }

            
        }
    }
}
