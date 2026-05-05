using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Eleven.Model
{
   
        public class CoworkerRepository
        {
            private string _connectionString = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=7Eleven; Integrated Security=True; TrustServerCertificate=True;";

            public void AddCoworker(Coworker coworker)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("AddCoworker", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", coworker.Id);
                    cmd.Parameters.AddWithValue("@Name", coworker.Name);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            public void DeleteCoworker(int id)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeleteCoworker", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            public void UpdateCoworker(Coworker coworker)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UpdateCoworker", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", coworker.Id);
                    cmd.Parameters.AddWithValue("@Name", coworker.Name);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            public Coworker GetById(int id)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetCoworkerById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Coworker(
                                reader["Name"].ToString(),
                                (int)reader["Id"]
                            );
                        }
                    }
                }
                return null;
            }

            public List<Coworker> GetAll()
            {
                var coworkers = new List<Coworker>();

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetAllCoworkers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var coworker = new Coworker(
                                reader["Name"].ToString(),
                                (int)reader["Id"]
                            );
                            coworkers.Add(coworker);
                        }
                    }
                }
                return coworkers;
            }
        }
    }




