using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entities;

namespace Data
{
    public class DProduct : DataContext
    {

        public List<Product> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "[usp.Product.GetAll]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();
                    List<Product> list = new List<Product>();

                    while (reader.Read())
                    {
                        Product item = new Product();
                        item.ProductId = Convert.ToInt32(reader["ProductId"].ToString());
                        item.ProductName = reader["ProductName"].ToString();
                        item.Price = Convert.ToDecimal(reader["Price"].ToString());
                        item.Stock = Convert.ToDecimal(reader["Stock"].ToString());
                        item.CategoryId = Convert.ToInt32(reader["CategoryId"].ToString());
                        item.CategoryName = reader["CategoryName"].ToString();
                        list.Add(item);
                        item = null;
                    }
                    connection.Close();
                    return list;
                }
            }
        }


        public List<Product> GetByName(string filter)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "[usp.Product.GetByName]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@filter", filter);//agregamos el parametro
                     
                    SqlDataReader reader = command.ExecuteReader();
                    List<Product> list = new List<Product>();

                    while (reader.Read())
                    {
                        Product item = new Product();
                        item.ProductId = Convert.ToInt32(reader["ProductId"].ToString());
                        item.ProductName = reader["ProductName"].ToString();
                        item.Price = Convert.ToDecimal(reader["Price"].ToString());
                        item.Stock = Convert.ToDecimal(reader["Stock"].ToString());
                        item.CategoryId = Convert.ToInt32(reader["CategoryId"].ToString());
                        item.CategoryName = reader["CategoryName"].ToString();
                        list.Add(item);
                        item = null;
                    }
                    connection.Close();
                    return list;
                }
            }
        }


        public bool Register(Product product)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "[usp.Product.Register]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"@{nameof(Product.ProductName)}", product.ProductName);//agregamos el parametro
                    command.Parameters.AddWithValue($"@{nameof(Product.Price)}", product.Price);//agregamos el parametro
                    command.Parameters.AddWithValue($"@{nameof(Product.Stock)}", product.Stock);//agregamos el parametro
                    command.Parameters.AddWithValue($"@{nameof(Product.CategoryId)}", product.CategoryId);//agregamos el parametro

                    int rowAffect = command.ExecuteNonQuery();
                   
                    connection.Close();
                    return rowAffect > 0;
                }
            }
        }


        public bool Update(Product product)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "[usp.Product.Update]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"@{nameof(Product.ProductId)}", product.ProductId);//agregamos el parametro
                    command.Parameters.AddWithValue($"@{nameof(Product.ProductName)}", product.ProductName);//agregamos el parametro
                    command.Parameters.AddWithValue($"@{nameof(Product.Price)}", product.Price);//agregamos el parametro
                    command.Parameters.AddWithValue($"@{nameof(Product.Stock)}", product.Stock);//agregamos el parametro
                    command.Parameters.AddWithValue($"@{nameof(Product.CategoryId)}", product.CategoryId);//agregamos el parametro

                    int rowAffect = command.ExecuteNonQuery();

                    connection.Close();
                    return rowAffect > 0;
                }
            }
        }


        public bool Delete(int productId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "[usp.Product.Delete]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"@{nameof(Product.ProductId)}", productId);//agregamos el parametro
                    
                    int rowAffect = command.ExecuteNonQuery();

                    connection.Close();
                    return rowAffect > 0;
                }
            }
        }
    }
}
