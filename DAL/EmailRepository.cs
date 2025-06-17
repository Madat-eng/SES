using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DAL
{
    public static class EmailRepository
    {
        private static string _connectionString = Setting.ConnectionString;

        public static void AddEmail(string emailAddress)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("AddEmail", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@EmailAddress", emailAddress);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void DeleteEmailById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("DeleteEmailByID", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@EmailID", id);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void DeleteEmailByAddress(string emailAddress)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("DeleteEmailByAddress", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@EmailAddress", emailAddress);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void SendEmailToAll(string sender, string subject, string body)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SendEmailToAll", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@SenderEmail", sender);
            cmd.Parameters.AddWithValue("@Subject", subject);
            cmd.Parameters.AddWithValue("@Body", body);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public static List<EmailDTO> GetAllEmails()
        {
            var emails = new List<EmailDTO>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("GetAllEmails", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                emails.Add(new EmailDTO
                {
                    EmailID = reader.GetInt32(0),
                    EmailAddress = reader.GetString(1),
                    IsVerified = reader.GetBoolean(2),
                    AddedAt = reader.GetDateTime(3)
                });
            }
            return emails;
        }

        public static List<EmailTransactionDTO> GetAllEmailTransactions()
        {
            var transactions = new List<EmailTransactionDTO>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("GetAllEmailTransactions", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                transactions.Add(new EmailTransactionDTO
                {
                    EmailTransactionID = reader.GetInt32(0),
                    EmailID = reader.GetInt32(1),
                    SenderEmail = reader.GetString(2),
                    Status = reader.GetString(3),
                    SendDate = reader.GetDateTime(4),
                    Body = reader.GetString(5),
                    Subject = reader.GetString(6)
                });
            }
            return transactions;
        }
    }
}
