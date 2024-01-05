using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using crud11.Models;

namespace crud11.DAL
{
    public class Product_DAL
    {
        string conString = ConfigurationManager.ConnectionStrings["adoConnectionstring"].ToString();

        public List<Product> GetAllProducts()
        {
            List<Product> productList = new List<Product>();
            using (SqlConnection conn = new SqlConnection(conString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_GetAllProducts";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dataTable = new DataTable();

                conn.Open();
                adapter.Fill(dataTable);
                conn.Close();

                foreach (DataRow dr in dataTable.Rows)
                {
                    productList.Add(new Product
                    {
                        ProductId = Convert.ToInt32(dr["ProductId"]),
                        ProductName = dr["ProductName"].ToString(),
                        Price = Convert.ToDecimal(dr["Price"]),
                        Qty = Convert.ToInt32(dr["qty"]),
                        Remarks = dr["Remarks"].ToString()
                    });
                }
            }

            return productList;
        }



        //insert product
        public bool InsertProduct(Product product)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_insertProducts", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Qty", product.Qty);
                command.Parameters.AddWithValue("@Remarks", product.Remarks);

                connection.Open();
                id = command.ExecuteNonQuery();
                connection.Close();
            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        //get by product id
        public List<Product> GetAllProductByID(int ProductID)
        {
            List<Product> productList = new List<Product>();
            using (SqlConnection conn = new SqlConnection(conString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_GetProductById";
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dataTable = new DataTable();

                conn.Open();
                adapter.Fill(dataTable);
                conn.Close();

                foreach (DataRow dr in dataTable.Rows)
                {
                    productList.Add(new Product
                    {
                        ProductId = Convert.ToInt32(dr["ProductId"]),
                        ProductName = dr["ProductName"].ToString(),
                        Price = Convert.ToDecimal(dr["Price"]),
                        Qty = Convert.ToInt32(dr["qty"]),
                        Remarks = dr["Remarks"].ToString()
                    });
                }
            }

            return productList;
        }


        //update product
        public bool UpdateProduct(Product product)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_UpdateProducts", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductID", product.ProductId);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Qty", product.Qty);
                command.Parameters.AddWithValue("@Remarks", product.Remarks);

                connection.Open();
                id = command.ExecuteNonQuery();
                connection.Close();
            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //delete product

        public string DeleteProduct(int productid)
        {
            string result = "";

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_deleteProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@productid", productid);
                command.Parameters.Add("@OUTPUTMESSAGE", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;

                connection.Open();
                command.ExecuteNonQuery();
                result = command.Parameters["@OUTPUTMESSAGE"].Value.ToString();
                connection.Close();
            }

            return result;
        }
    }
}