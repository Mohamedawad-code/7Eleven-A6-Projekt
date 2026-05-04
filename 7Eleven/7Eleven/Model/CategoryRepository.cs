using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace _7Eleven.Model
{
    public class CategoryRepository
    {
        private string _connectionString = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=7Eleven; Integrated Security=True; TrustServerCertificate=True;";

        public void AddCategory(Category category)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddCategory", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", category.ID);
                cmd.Parameters.AddWithValue("@FoodName", category.FoodName);
                cmd.Parameters.AddWithValue("@FoodType", category.FoodType.ToString());

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCategory(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCategory(Category category)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", category.ID);
                cmd.Parameters.AddWithValue("@FoodName", category.FoodName);
                cmd.Parameters.AddWithValue("@FoodType", category.FoodType.ToString());

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Category GetById(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString)) // we create a variable with a new sqlconnection inside of it
            {
                SqlCommand cmd = new SqlCommand("GetCategoryById", conn); // we create a variable with new sqlcommand inside of it
                cmd.CommandType = CommandType.StoredProcedure; // set a value, saying that we want this commandtype to be a storedprocedure

                cmd.Parameters.AddWithValue("@ID", id); // we add parameters to the object

                conn.Open(); // opens connection
                using (SqlDataReader reader = cmd.ExecuteReader()) 
                {
                    if (reader.Read())
                    {
                        return new Category(
                            reader["FoodName"].ToString(),
                            Enum.Parse<FoodCategory>(reader["FoodType"].ToString())
                        )
                        {
                            ID = (Guid)reader["ID"]
                        };
                    }
                }
            }
            return null;
        }

        public List<Category> GetAll()
        {
            var categories = new List<Category>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllCategories", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var category = new Category(
                            reader["FoodName"].ToString(),
                            Enum.Parse<FoodCategory>(reader["FoodType"].ToString())
                        )
                        {
                            ID = (Guid)reader["ID"]
                        };
                        categories.Add(category);
                    }
                }
            }
            return categories;
        }

        public List<Category> GetByFoodType(FoodCategory foodType)
        {
            var categories = new List<Category>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetCategoriesByFoodType", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FoodType", foodType.ToString());

                conn.Open();


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var category = new Category(
                            reader["FoodName"].ToString(),
                            Enum.Parse<FoodCategory>(reader["FoodType"].ToString())
                        )
                        {
                            ID = (Guid)reader["ID"]
                        };
                        categories.Add(category);
                    }
                }
            }
            return categories;
        }
    }
}
