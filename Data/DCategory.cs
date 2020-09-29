using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entities;

namespace Data
{
    public class DCategory : DataContext
    {

        public List<Category> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "[usp.Category.GetAll]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();
                    List<Category> list = new List<Category>();

                    while (reader.Read())
                    {
                        Category item = new Category();
                        item.CategoryId = Convert.ToInt32(reader["CategoryId"].ToString());
                        item.CategoryName = reader["CategoryName"].ToString();
                        item.RegisterDate = Convert.ToDateTime(reader["RegisterDate"].ToString());
                        list.Add(item);
                        item = null;
                    }
                    connection.Close();
                    return list;
                }
            }
        }
    }
}
