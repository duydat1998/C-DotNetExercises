using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ProductLibrary
{
    public class ProductDB
    {
        private string strConnection = ConfigurationManager.ConnectionStrings["SaleDB"].ConnectionString;

        public bool AddNewProduct(Product p)
        {
            int count=-1;
            SqlConnection con = new SqlConnection(strConnection);
            if(con != null)
            {
                try
                {
                    string sql = "Insert into Products values(@ID, @Name, @Price, @Quantity)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@ID", p.ProductID);
                    cmd.Parameters.AddWithValue("@Name",p.ProductName);
                    cmd.Parameters.AddWithValue("@Price",p.UnitPrice);
                    cmd.Parameters.AddWithValue("@Quantity",p.Quantity);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    count = cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return (count >0);
        }

        public bool UpdateProduct(Product p)
        {
            int count = -1;
            SqlConnection con = new SqlConnection(strConnection);
            if (con != null)
            {
                try
                {
                    string sql = "Update Products set ProductName=@Name, UnitPrice=@Price, Quantity=@Quantity where ProductId=@ID";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@ID", p.ProductID);
                    cmd.Parameters.AddWithValue("@Name", p.ProductName);
                    cmd.Parameters.AddWithValue("@Price", p.UnitPrice);
                    cmd.Parameters.AddWithValue("@Quantity", p.Quantity);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    count = cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return (count > 0);
        }

        public bool RemoveProduct(int ID)
        {
            int count = -1;
            SqlConnection con = new SqlConnection(strConnection);
            if (con != null)
            {
                try
                {
                    string sql = "Delete Products where ProductID=@ID";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    count = cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return (count > 0);
        }

        public Product FindProduct(int id)
        {
            Product output = null;
            SqlConnection con = new SqlConnection(strConnection);
            if (con != null)
            {
                try
                {
                    string sql = "Select * from Products where ProductID=@ID";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@ID", id);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int index = dr.GetOrdinal("ProductName");
                            string name = dr.GetString(index);
                            index = dr.GetOrdinal("UnitPrice");
                            float price = (float) dr.GetDecimal(index);
                            index = dr.GetOrdinal("Quantity");
                            int quantity = dr.GetInt32(index);
                            output = new Product { ProductID = id, ProductName = name, Quantity = quantity, UnitPrice = price };
                        }
                    }
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return output;
        }

        public DataTable GetAllProducts()
        {
            //List<Product> output = null;
            DataTable output = new DataTable();
            SqlConnection con = new SqlConnection(strConnection);
            if (con != null)
            {
                try
                {
                    string sql = "Select * from Products";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(output);
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return output;
        }

    }
}
