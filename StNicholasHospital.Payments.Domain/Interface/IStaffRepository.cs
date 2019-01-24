using StNicholasHospital.Payments.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StNicholasHospital.Payments.Domain.Interface
{
    public interface IStaffRepository
    {
        void Add(string staffID, string firstName, string lastName, string password, DateTime createdBy);
        void UpdatePassword(string staffID, string oldPassword, string newPassword);
        StaffDto FindByID(string staffID, string password);
        List<StaffDto> GetAll();
    }
}
