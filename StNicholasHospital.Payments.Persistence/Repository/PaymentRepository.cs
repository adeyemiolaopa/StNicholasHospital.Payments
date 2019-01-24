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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly string _connectionString;

        public PaymentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(string paymentID, string patientID, string description, decimal amount, string createdBy)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                
                SqlCommand cmd = new SqlCommand("stpInsertPayment", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] sqlParams = { new SqlParameter("@PaymentID", paymentID),
                                                new SqlParameter("@EntryDate", DateTime.Now.Date),
                                                new SqlParameter("@PatientID", patientID),
                                                new SqlParameter("@Description", description),
                                                new SqlParameter("@Amount", amount),
                                                new SqlParameter("@CreatedBy", createdBy),
                };

                cmd.Parameters.AddRange(sqlParams);
                cmd.ExecuteReader();
            }
        }

        public PaymentDto FindByID(string paymentID)
        {
            PaymentDto paymentDto = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("stpGetPaymentByPaymentID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PaymentID", paymentID));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        paymentDto = new PaymentDto()
                        {
                            CreatedBy = reader["CreatedBy"].ToString(),
                            EntryDate = DateTime.Parse(reader["EntryDate"].ToString()),
                            Amount = decimal.Parse(reader["Amount"].ToString()),
                            Description = reader["Description"].ToString(),
                            PatientID = reader["PatientID"].ToString(),
                            PaymentID = reader["PaymentID"].ToString()
                        };

                    }
                }
            }

            return paymentDto;
        }

        public decimal GetTotalPaymentByPatientID(string patientID, DateTime startDate, DateTime endDate)
        {
            SqlParameter totalPayment = new SqlParameter();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("stpGetTotalPaymentByPatientID", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] sqlParams = { new SqlParameter("@PatientID", patientID),
                                             new SqlParameter("@StartDate", startDate),
                                             new SqlParameter("@EndDate", endDate)
                };

                cmd.Parameters.AddRange(sqlParams);

                totalPayment = cmd.Parameters.Add("@TotalPayment", SqlDbType.Decimal);
                totalPayment.Precision = 18;
                totalPayment.Scale = 2;
                totalPayment.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
            }

            return decimal.Parse(totalPayment.Value.ToString());
        }

        public List<PaymentDto> GetPaymentsByPatientID(string patientID)
        {
            List<PaymentDto> payments = new List<PaymentDto>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("stpGetPaymentsByPatientID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PatientID", patientID));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PaymentDto paymentDto = new PaymentDto()
                        {
                            CreatedBy = reader["CreatedBy"].ToString(),
                            EntryDate = DateTime.Parse(reader["EntryDate"].ToString()),
                            Amount = decimal.Parse(reader["Amount"].ToString()),
                            Description = reader["Description"].ToString(),
                            PatientID = reader["PatientID"].ToString(),
                            PaymentID = reader["PaymentID"].ToString()
                        };

                        payments.Add(paymentDto);
                    }
                }
            }

            return payments.OrderBy(O => O.EntryDate).ToList();
        }

    }
}
