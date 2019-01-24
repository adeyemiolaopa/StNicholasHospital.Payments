using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StNicholasHospital.Payments.Persistence.Repository;
using StNicholasHospital.Payments.Domain.Service;
using System.Configuration;
using StNicholasHospital.Payments.Domain.Dto;
using StNicholasHospital.Payments.Domain.Exceptions;

namespace StNicholasHospital.Payments.Domain.Tests.Service
{
    [TestClass]
    public class PatientServiceTests
    {
        private string _connString;
        private PatientRepository _patientRepository;
        private PatientService _patientService;

        [TestInitialize]
        public void Initialize()
        {
            _connString = ConfigurationManager.ConnectionStrings["StNicholasHospitalConnString"].ConnectionString;
            _patientRepository = new PatientRepository(_connString);
            _patientService = new PatientService(_patientRepository);
        }

        [TestMethod]
        public void CreatePatient_ValidPhoneNo_ReturnsPatient()
        {
            // Arrange
            var validPhoneNo = "07034678899";
            var firstname = "Olusayo";
            var lastname = "Babalola";
            var email = "olusayobabalola@gmail.com";

            // Act
            var patient = _patientService.CreatePatient(validPhoneNo, firstname, lastname, "SYSTEM", email);

            // Assert
            Assert.IsInstanceOfType(patient, typeof(PatientDto));
            Assert.AreEqual(validPhoneNo, patient.PhoneNo);
        }

        [TestMethod, ExpectedException(typeof(DuplicatePhoneNoException))]
        public void CreatePatient_DuplicatePhoneNo_ThrowsException()
        {
            // Arrange
            var validPhoneNo = "08067564565";
            var firstname = "Fisayo";
            var lastname = "Olusoji";
            var email = "fisayoolusoji@gmail.com";

            // Act
            var patient = _patientService.CreatePatient(validPhoneNo, firstname, lastname, "SYSTEM", email);
        }

        [TestMethod]
        public void GetByID_ValidPatientID_ReturnsPatient()
        {
            // Arrange
            var validPatientID = "e7112286-f0a0-4310-919b-36226ed5ce6f";

            // Act
            var patient = _patientService.GetByID(validPatientID);

            // Assert
            Assert.IsInstanceOfType(patient, typeof(PatientDto));
            Assert.AreEqual(validPatientID, patient.PatientID);
        }

        [TestMethod, ExpectedException(typeof(InvalidPatientIDException))]
        public void GetByID_InValidPatientID_ThrowsException()
        {
            // Arrange
            var invalidPatientID = "e7112286-f0a0-4310-919b-36226ed5ce6g";

            // Act
            var patient = _patientService.GetByID(invalidPatientID);
        }

        [TestMethod]
        public void GetByPhoneNo_ValidPhoneNo_ReturnsPatient()
        {
            // Arrange
            var validPhoneNo = "08054676575";

            // Act
            var patient = _patientService.GetByPhoneNo(validPhoneNo);

            // Assert
            Assert.IsInstanceOfType(patient, typeof(PatientDto));
            Assert.AreEqual(validPhoneNo, patient.PhoneNo);
        }

        [TestMethod, ExpectedException(typeof(InvalidPhoneNoException))]
        public void GetByID_InValidPhoneNo_ThrowsException()
        {
            // Arrange
            var invalidPhoneNo = "08067564566";

            // Act
            var patient = _patientService.GetByPhoneNo(invalidPhoneNo);
        }
        
    }
}
