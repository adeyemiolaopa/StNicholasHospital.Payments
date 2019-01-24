using StNicholasHospital.Payments.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StNicholasHospital.Payments.Domain.Interface
{
    public interface IPatientRepository
    {
        void Add(string patientID, string phoneNo, string firstName, string lastName, string createdBy, string email);
        PatientDto FindByPhoneNo(string phoneNo);
        List<PatientDto> GetAll();
        PatientDto FindByID(string patientID);

    }
}
