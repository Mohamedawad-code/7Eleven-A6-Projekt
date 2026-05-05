using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;

namespace _7Eleven.Model
{
    public class ProductRepository
    {
        private string _connectionString = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=7Eleven; Integrated Security=True; TrustServerCertificate=True;";

        public void AddProduct(Product product)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductNO", product.ProductNO);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Amount", product.Amount);
                cmd.Parameters.AddWithValue("@TimeReceived", product.TimeReceived);
                cmd.Parameters.AddWithValue("@ExpiringDate", product.ExpiringDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(Guid productNO)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductNO", productNO);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductNO", product.ProductNO);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Amount", product.Amount);
                cmd.Parameters.AddWithValue("@TimeReceived", product.TimeReceived);
                cmd.Parameters.AddWithValue("@ExpiringDate", product.ExpiringDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Product GetById(Guid productNO)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetProductById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductNO", productNO);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Product(
                            reader["Name"].ToString(),
                            (int)reader["Amount"],
                            (DateTime)reader["TimeReceived"],
                            (DateTime)reader["ExpiringDate"]
                        )
                        {
                            ProductNO = (Guid)reader["ProductNO"]
                        };
                    }
                }
            }
            return null;
        }

        public List<Product> GetAll()
        {
            var products = new List<Product>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllProducts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product(
                            reader["Name"].ToString(),
                            (int)reader["Amount"],
                            (DateTime)reader["TimeReceived"],
                            (DateTime)reader["ExpiringDate"]
                        )
                        {
                            ProductNO = (Guid)reader["ProductNO"]
                        };
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        public List<Product> GetExpiredProducts()
        {
            var products = new List<Product>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetExpiredProducts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CurrentDate", DateTime.Now);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product(
                            reader["Name"].ToString(),
                            (int)reader["Amount"],
                            (DateTime)reader["TimeReceived"],
                            (DateTime)reader["ExpiringDate"]
                        )
                        {
                            ProductNO = (Guid)reader["ProductNO"]
                        };
                        products.Add(product);
                    }
                }
            }
            return products;
        }
    }
}