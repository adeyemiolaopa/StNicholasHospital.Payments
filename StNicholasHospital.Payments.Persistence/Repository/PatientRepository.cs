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
    public class PatientRepository : IPatientRepository
    {
        private readonly string _connectionString;

        public PatientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(string patientID, string phoneNo, string firstName, string lastName, string createdBy, string email)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("stpInsertPatient", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] sqlParams = { new SqlParameter("@PatientID", patientID),
                                                new SqlParameter("@EntryDate", DateTime.Now),
                                                new SqlParameter("@PhoneNo", phoneNo),
                                                new SqlParameter("@Firstname", firstName),
                                                new SqlParameter("@Lastname", lastName),
                                                new SqlParameter("@Email", email),
                                                new SqlParameter("@CreatedBy", createdBy),
                                                new SqlParameter("@TotalPayment", DBNull.Value),
                };

                cmd.Parameters.AddRange(sqlParams);
                cmd.ExecuteReader();
            }

        }

        public PatientDto FindByPhoneNo(string phoneNo)
        {
            PatientDto patientDto = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("stpGetPatientByPhoneNo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PhoneNo", phoneNo));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        patientDto = new PatientDto()
                        {
                            CreatedBy = reader["CreatedBy"].ToString(),
                            EntryDate = DateTime.Parse(reader["EntryDate"].ToString()),
                            Firstname = reader["Firstname"].ToString(),
                            Lastname = reader["Lastname"].ToString(),
                            PatientID = reader["PatientID"].ToString(),
                            PhoneNo = reader["PhoneNo"].ToString(),
                            Email = reader["Email"].ToString()
                        };

                        if (reader["TotalPayment"] == DBNull.Value) {
                            patientDto.TotalPayment = 0;
                        }
                        else {
                            patientDto.TotalPayment = decimal.Parse(reader["TotalPayment"].ToString());
                        }
                    }
                }
            }

            return patientDto;
        }

        public List<PatientDto> GetAll()
        {
            List<PatientDto> patients = new List<PatientDto>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("stpGetAllPatients", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PatientDto patientDto = new PatientDto()
                        {
                            CreatedBy = reader["CreatedBy"].ToString(),
                            EntryDate = DateTime.Parse(reader["EntryDate"].ToString()),
                            Firstname = reader["Firstname"].ToString(),
                            Lastname = reader["Lastname"].ToString(),
                            PatientID = reader["PatientID"].ToString(),
                            PhoneNo = reader["PhoneNo"].ToString(),
                            Email = reader["Email"].ToString()
                        };

                        if (reader["TotalPayment"] == DBNull.Value) {
                            patientDto.TotalPayment = 0;
                        }
                        else {
                            patientDto.TotalPayment = decimal.Parse(reader["TotalPayment"].ToString());
                        }

                        patients.Add(patientDto);
                    }
                }
            }

            Stack<int> stack = new Stack<int>();
            stack.Push(7);

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("test");

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("item1", "test");

            return patients;
        }

        public PatientDto FindByID(string patientID)
        {
            PatientDto patientDto = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("stpGetPatientByPatientID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PatientID", patientID));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        patientDto = new PatientDto()
                        {
                            CreatedBy = reader["CreatedBy"].ToString(),
                            EntryDate = DateTime.Parse(reader["EntryDate"].ToString()),
                            Firstname = reader["Firstname"].ToString(),
                            Lastname = reader["Lastname"].ToString(),
                            PatientID = reader["PatientID"].ToString(),
                            PhoneNo = reader["PhoneNo"].ToString(),
                            Email = reader["Email"].ToString()
                        };

                        if (reader["TotalPayment"] == DBNull.Value) {
                            patientDto.TotalPayment = 0;
                        }
                        else {
                            patientDto.TotalPayment = decimal.Parse(reader["TotalPayment"].ToString());
                        }
                    }
                }
            }

            return patientDto;
        }

        //public (int i, string t) Test()
        //{
        //    return (i, t);
        //}
    }
}
