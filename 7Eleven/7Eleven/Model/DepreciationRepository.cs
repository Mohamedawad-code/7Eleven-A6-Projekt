using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;

namespace _7Eleven.Model
{
    public class DepreciationRepository
    {
        private string _connectionString = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=7Eleven; Integrated Security=True; TrustServerCertificate=True;";
        private ProductRepository _productRepo = new ProductRepository();

        public void AddDepreciation(Depreciation depreciation)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddDepreciation", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", depreciation.ID);
                cmd.Parameters.AddWithValue("@Date", depreciation.Date);
                cmd.Parameters.AddWithValue("@ProductNO", depreciation.ProductDep.ProductNO);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteDepreciation(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteDepreciation", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateDepreciation(Depreciation depreciation)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateDepreciation", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", depreciation.ID);
                cmd.Parameters.AddWithValue("@Date", depreciation.Date);
                cmd.Parameters.AddWithValue("@ProductNO", depreciation.ProductDep.ProductNO);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Depreciation GetById(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetDepreciationById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // fetch the related Product using its ID
                        var product = _productRepo.GetById(
                            (Guid)reader["ProductNO"]
                        );

                        return new Depreciation(
                            (DateTime)reader["Date"],
                            product
                        )
                        {
                            ID = (Guid)reader["ID"]
                        };
                    }
                }
            }
            return null;
        }

        public List<Depreciation> GetAll()
        {
            var depreciations = new List<Depreciation>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllDepreciations", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = _productRepo.GetById(
                            (Guid)reader["ProductNO"]
                        );

                        var depreciation = new Depreciation(
                            (DateTime)reader["Date"],
                            product
                        )
                        {
                            ID = (Guid)reader["ID"]
                        };
                        depreciations.Add(depreciation);
                    }
                }
            }
            return depreciations;
        }
    }
}