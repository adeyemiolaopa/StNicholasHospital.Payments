using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StNicholasHospital.Payments.Persistence.Repository;
using StNicholasHospital.Payments.Domain.Service;
using System.Configuration;
using StNicholasHospital.Payments.Domain.Exceptions;
using StNicholasHospital.Payments.Domain.Dto;

namespace StNicholasHospital.Payments.Domain.Tests.Service
{
    [TestClass]
    public class PaymentServiceTests
    {
        private string _connString;
        private PatientRepository _patientRepository;
        private PaymentRepository _paymentRepository;
        private PaymentService _paymentService;

        [TestInitialize]
        public void Initialize()
        {
            _connString = ConfigurationManager.ConnectionStrings["StNicholasHospitalConnString"].ConnectionString;
            _patientRepository = new PatientRepository(_connString);
            _paymentRepository = new PaymentRepository(_connString);
            _paymentService = new PaymentService(_paymentRepository, _patientRepository);
        }

        [TestMethod]
        public void CreatePayment_ValidPatientID_ReturnsPayment()
        {
            // Arrange
            var validPatientID = "e7112286-f0a0-4310-919b-36226ed5ce6f";
            string description = "Payment for surgery";
            decimal amount = 500;

            // Act
            var payment = _paymentService.CreatePayment(validPatientID, description, amount,"SYSTEM");

            // Assert
            Assert.IsInstanceOfType(payment, typeof(PaymentDto));
            Assert.AreEqual(validPatientID, payment.PatientID);
            Assert.IsTrue(payment.Amount > 0);
        }

        [TestMethod, ExpectedException(typeof(InvalidPatientIDException))]
        public void CreatePayment_InValidPatientID_ThrowsException()
        {
            // Arrange
            var inValidPatientID = "e7112286-f0a0-4310-919b-36226ed5ce6g";
            string description = "Payment for drugs and treatment";
            decimal amount = 120;

            // Act
            var payment = _paymentService.CreatePayment(inValidPatientID, description, amount, "SYSTEM");
        }

        [TestMethod]
        public void GetByID_ValidPaymentID_ReturnsPayment()
        {
            // Arrange
            var validPaymentID = "7eabe52b-bd64-4689-a18b-fea25174af2e";

            // Act
            var payment = _paymentService.GetByID(validPaymentID);

            // Assert
            Assert.IsInstanceOfType(payment, typeof(PaymentDto));
            Assert.AreEqual(validPaymentID, payment.PaymentID);
            Assert.IsNotNull(payment);
        }

        [TestMethod, ExpectedException(typeof(InvalidPaymentIDException))]
        public void GetByID_InValidPaymentID_ThrowsException()
        {
            // Arrange
            var invalidPaymentID = "1c83aeae-c1d8-4de9-bc02-bc342d723661";

            // Act
            var payment = _paymentService.GetByID(invalidPaymentID);
        }

        [TestMethod]
        public void GetTotalPaymentByPatientID_ValidPatientID_ReturnsTotalPayment()
        {
            // Arrange
            var validPatientID = "e7112286-f0a0-4310-919b-36226ed5ce6f";
            var startDate = DateTime.Parse("2019-01-02");
            var endDate = DateTime.Now;

            // Act
            var totalPayment = _paymentService.GetTotalPaymentByPatientID(validPatientID, startDate, endDate);

            // Assert
            Assert.IsNotNull(totalPayment);
            Assert.IsTrue(totalPayment > 0);
            //Assert.IsTrue(totalPayment == 600);
        }

        [TestMethod, ExpectedException(typeof(InvalidPatientIDException))]
        public void GetByID_InValidPatientID_ThrowsException()
        {
            // Arrange
            var invalidPatientID = "e7112286-f0a0-4310-919b-36226ed5ce6g";
            var startDate = DateTime.Parse("2019-01-02");
            var endDate = DateTime.Now;

            // Act
            var totalPayment = _paymentService.GetTotalPaymentByPatientID(invalidPatientID, startDate, endDate);
        }
    }
}
