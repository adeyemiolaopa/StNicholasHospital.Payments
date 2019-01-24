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
    public class StaffServiceTests
    {
        private string _connString;
        private StaffRepository _staffRepository;
        private StaffService _staffService;

        [TestInitialize]
        public void Initialize()
        {
            _connString = ConfigurationManager.ConnectionStrings["StNicholasHospitalConnString"].ConnectionString;
            _staffRepository = new StaffRepository(_connString);
            _staffService = new StaffService(_staffRepository);

        }

        [TestMethod]
        public void GetByID_ValidStaffID_ReturnsStaff()
        {
            // Arrange
            var validStaffID = "adeyemiolaopa@gmail.com";
            var validPassword = "123456";

            // Act
            var staff = _staffService.GetByID(validStaffID, validPassword);

            // Assert
            Assert.IsInstanceOfType(staff, typeof(StaffDto));
            Assert.AreEqual(validStaffID, staff.StaffID);
        }

        [TestMethod, ExpectedException(typeof(InvalidStaffIDOrPasswordException))]
        public void GetByID_InValidStaffIDOrPassword_ThrowsException()
        {
            // Arrange
            var invalidStaffID = "invalidemail@gmail.com";
            var invalidPassword = "6783992";

            // Act
            var staff = _staffService.GetByID(invalidStaffID, invalidPassword);
        }
    }
}
