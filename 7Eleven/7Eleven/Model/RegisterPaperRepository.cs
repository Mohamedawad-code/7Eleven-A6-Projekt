using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;

namespace _7Eleven.Model
{
    public class RegisterPaperRepository
    {
        private string _connectionString = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=7Eleven; Integrated Security=True; TrustServerCertificate=True;";

        // needed to rebuild the full objects when reading from database
        private ProductRepository _productRepo = new ProductRepository();
        private CategoryRepository _categoryRepo = new CategoryRepository();
        private CoworkerRepository _coworkerRepo = new CoworkerRepository();

        public void AddRegisterPaper(RegisterPaper registerPaper)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddRegisterPaper", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", registerPaper.ID);
                cmd.Parameters.AddWithValue("@ProductNO", registerPaper.Product.ProductNO);
                cmd.Parameters.AddWithValue("@CategoryID", registerPaper.Category.ID);
                cmd.Parameters.AddWithValue("@CoworkerID", registerPaper.RegisteredBy.Id);
                cmd.Parameters.AddWithValue("@Amount", registerPaper.Amount);
                cmd.Parameters.AddWithValue("@ExpiringDate", registerPaper.ExpiringDate);
                cmd.Parameters.AddWithValue("@RegisterDate", registerPaper.RegisterDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteRegisterPaper(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteRegisterPaper", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public RegisterPaper GetById(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetRegisterPaperById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // rebuild full objects from their IDs
                        var product = _productRepo.GetById((Guid)reader["ProductNO"]);
                        var category = _categoryRepo.GetById((Guid)reader["CategoryID"]);
                        var coworker = _coworkerRepo.GetById((int)reader["CoworkerID"]);

                        return new RegisterPaper(
                            product,
                            category,
                            (int)reader["Amount"],
                            (DateTime)reader["ExpiringDate"],
                            coworker,
                            (DateTime)reader["RegisterDate"]
                        )
                        {
                            ID = (Guid)reader["ID"]
                        };
                    }
                }
            }
            return null;
        }

        public List<RegisterPaper> GetAll()
        {
            var registerPapers = new List<RegisterPaper>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllRegisterPapers", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = _productRepo.GetById((Guid)reader["ProductNO"]);
                        var category = _categoryRepo.GetById((Guid)reader["CategoryID"]);
                        var coworker = _coworkerRepo.GetById((int)reader["CoworkerID"]);

                        var registerPaper = new RegisterPaper(
                            product,
                            category,
                            (int)reader["Amount"],
                            (DateTime)reader["ExpiringDate"],
                            coworker,
                            (DateTime)reader["RegisterDate"]
                        )
                        {
                            ID = (Guid)reader["ID"]
                        };
                        registerPapers.Add(registerPaper);
                    }
                }
            }
            return registerPapers;
        }

        public List<RegisterPaper> GetByCoworker(int coworkerId)
        {
            var registerPapers = new List<RegisterPaper>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetRegisterPapersByCoworker", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CoworkerID", coworkerId);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = _productRepo.GetById((Guid)reader["ProductNO"]);
                        var category = _categoryRepo.GetById((Guid)reader["CategoryID"]);
                        var coworker = _coworkerRepo.GetById((int)reader["CoworkerID"]);

                        var registerPaper = new RegisterPaper(
                            product,
                            category,
                            (int)reader["Amount"],
                            (DateTime)reader["ExpiringDate"],
                            coworker,
                            (DateTime)reader["RegisterDate"]
                        )
                        {
                            ID = (Guid)reader["ID"]
                        };
                        registerPapers.Add(registerPaper);
                    }
                }
            }
            return registerPapers;
        }

        public List<RegisterPaper> GetByDateRange(DateTime start, DateTime end)
        {
            var registerPapers = new List<RegisterPaper>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetRegisterPapersByDateRange", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StartDate", start);
                cmd.Parameters.AddWithValue("@EndDate", end);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = _productRepo.GetById((Guid)reader["ProductNO"]);
                        var category = _categoryRepo.GetById((Guid)reader["CategoryID"]);
                        var coworker = _coworkerRepo.GetById((int)reader["CoworkerID"]);

                        var registerPaper = new RegisterPaper(
                            product,
                            category,
                            (int)reader["Amount"],
                            (DateTime)reader["ExpiringDate"],
                            coworker,
                            (DateTime)reader["RegisterDate"]
                        )
                        {
                            ID = (Guid)reader["ID"]
                        };
                        registerPapers.Add(registerPaper);
                    }
                }
            }
            return registerPapers;
        }
    }
}