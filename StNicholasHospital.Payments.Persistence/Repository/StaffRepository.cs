using StNicholasHospital.Payments.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StNicholasHospital.Payments.Domain.Dto;
using System.Data.SqlClient;
using System.Data;

namespace StNicholasHospital.Payments.Persistence.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly string _connectionString;

        public StaffRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(string staffID, string firstName, string lastName, string password, DateTime createdBy)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("stpInsertStaff", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] sqlParams = { new SqlParameter("@StaffID", staffID),
                                                new SqlParameter("@Firstname", firstName),
                                                new SqlParameter("@Lastname", lastName),
                                                new SqlParameter("@Password", password),
                                                new SqlParameter("@CreatedBy", createdBy)
                };

                cmd.Parameters.AddRange(sqlParams);
                cmd.ExecuteReader();
            }

        }

        public StaffDto FindByID(string staffID, string password)
        {
            StaffDto staffDto = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("stpGetStaffByStaffID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] sqlParams = { new SqlParameter("@StaffID", staffID),
                                                new SqlParameter("@Password", password)
                };

                cmd.Parameters.AddRange(sqlParams);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        staffDto = new StaffDto()
                        {
                            CreatedBy = reader["CreatedBy"].ToString(),
                            EntryDate = DateTime.Parse(reader["EntryDate"].ToString()),
                            Firstname = reader["Firstname"].ToString(),
                            Lastname = reader["Lastname"].ToString(),
                            Password = reader["Password"].ToString(),
                            StaffID = reader["StaffID"].ToString(),
                            StaffNo = reader["StaffNo"].ToString()
                        };

                    }
                }
            }

            return staffDto;
        }

        public List<StaffDto> GetAll()
        {
            List<StaffDto> staffMembers = new List<StaffDto>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("stpGetAllStaff", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        StaffDto staffDto = new StaffDto()
                        {
                            CreatedBy = reader["CreatedBy"].ToString(),
                            EntryDate = DateTime.Parse(reader["EntryDate"].ToString()),
                            Firstname = reader["Firstname"].ToString(),
                            Lastname = reader["Lastname"].ToString(),
                            Password = reader["Password"].ToString(),
                            StaffID = reader["StaffID"].ToString(),
                            StaffNo = reader["StaffNo"].ToString()
                        };

                        staffMembers.Add(staffDto);
                    }
                }
            }

            return staffMembers;
        }

        public void UpdatePassword(string staffID, string oldPassword, string newPassword)
        {
            var staffDto = FindByID(staffID, oldPassword);

            if (staffDto == null) {
                throw new Exception("The Staff does not exist!");
            }

            if (staffDto.Password != oldPassword) {
                throw new Exception("The OldPassword is incorrect, check it and try again!");
            }

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("stpUpdateStaffPswdByStaffID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Password", newPassword));
                cmd.ExecuteReader();
            }
        }
    }
}
