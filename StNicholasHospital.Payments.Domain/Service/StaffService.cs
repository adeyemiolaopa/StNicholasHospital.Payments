using StNicholasHospital.Payments.Domain.Dto;
using StNicholasHospital.Payments.Domain.Exceptions;
using StNicholasHospital.Payments.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StNicholasHospital.Payments.Domain.Service
{
    public class StaffService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public StaffDto GetByID(string staffID, string password)
        {
            if (string.IsNullOrEmpty(staffID)) {
                throw new Exception("The StaffID cannot be null!");
            }

            if (string.IsNullOrEmpty(password)) {
                throw new Exception("The Password cannot be null!");
            }

            var staffDto = _staffRepository.FindByID(staffID, password);

            if (staffDto == null) {
                throw new InvalidStaffIDOrPasswordException("The StaffID or Password is not correct!");
            }

            return staffDto;
        }

        public List<StaffDto> GetAll()
        {
            var staffMembers = _staffRepository.GetAll();
            return staffMembers;
        }
    }
}
