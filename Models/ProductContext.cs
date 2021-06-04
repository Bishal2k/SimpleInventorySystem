﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestForASPCORE.Models
{
    public class ProductContext
    {
        public string connectionString { get; set; }

        public ProductContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
        public List<Product> getProduct()
        {
            List<Product> list = new List<Product>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT product.id, name, barCode, categoryId, productcatagory.productName from product JOIN productcatagory ON productcatagory.id = product.categoryId", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Product()
                        {
                            id = Convert.ToInt32(reader["id"]),
                            barCode = reader["barCode"].ToString(),
                            name = reader["name"].ToString(),
                            categoryId = Convert.ToInt32(reader["categoryId"]),
                            categoryName = reader["productName"].ToString()
                        }); ;
                    }
                    conn.Close();
                }

            }
            return list;

        }
        public void insert(Product obj)
        {
            String insertQuery = "insert into product(barCode,name,categoryId) values('" + obj.barCode + "','" + obj.name + "','" + obj.categoryName + "')";

            using (MySqlConnection conn = GetConnection())
            {

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
        public List<Product> getCategoryName()
        {
            List<Product> categoryName = new List<Product>();
            string getCategoryNameQuery = "select productName from product";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(getCategoryNameQuery, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categoryName.Add(new Product()
                        {
                            categoryName = reader["productName"].ToString()
                        }); ;
                    }
                    conn.Close();
                }

            }
            return categoryName;
        }

    }
}
