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
    public class PatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public PatientDto CreatePatient(string phoneNo, string firstName, string lastName, string createdBy, string email)
        {
            var patientID = Guid.NewGuid().ToString();

            if (string.IsNullOrEmpty(phoneNo)) {
                throw new Exception("The PhoneNo cannot be null!");
            }

            if (string.IsNullOrEmpty(firstName)) {
                throw new Exception("The Firstname cannot be null!");
            }

            if (string.IsNullOrEmpty(lastName)) {
                throw new Exception("The Lastname cannot be null!");
            }

            if (string.IsNullOrEmpty(createdBy)) {
                throw new Exception("The CreatedBy cannot be null!");
            }

            if (string.IsNullOrEmpty(email)) {
                throw new Exception("The Email cannot be null!");
            }

            try {
                _patientRepository.Add(patientID, phoneNo, firstName, lastName, createdBy, email);

                    var patientDto = _patientRepository.FindByPhoneNo(phoneNo);

                    if (patientDto == null) {
                        throw new InvalidPatientIDException("The PhoneNo is not correct!");
                    }

                    return patientDto;
            }
            catch (SqlException ex) {
                throw new DuplicatePhoneNoException("The PhoneNo exists in the database! " + ex.Message);
            }
            
        }

        public PatientDto GetByPhoneNo(string phoneNo)
        {
            if (string.IsNullOrEmpty(phoneNo)) {
                throw new Exception("The PhoneNo cannot be null!");
            }

            var patientDto = _patientRepository.FindByPhoneNo(phoneNo);

            if (patientDto == null) {
                throw new InvalidPhoneNoException("The PhoneNo is not correct!");
            }

            return patientDto;
        }

        public PatientDto GetByID(string patientID)
        {
            if (string.IsNullOrEmpty(patientID)) {
                throw new Exception("The PatientID cannot be null!");
            }

            var patientDto = _patientRepository.FindByID(patientID);

            if (patientDto == null) {
                throw new InvalidPatientIDException("The PatientID is not correct!");
            }

            return patientDto;
        }

        public List<PatientDto> GetAll()
        {
            var patients = _patientRepository.GetAll();
            return patients;
        }
    }
}
