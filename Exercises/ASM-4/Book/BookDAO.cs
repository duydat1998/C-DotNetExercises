using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Book
{
    public class BookDAO
    {
        string strConnection;
        public BookDAO()
        {
            strConnection = ConfigurationManager.ConnectionStrings["BookStoreDB"].ConnectionString;

        }

        public DataTable GetAllBook()
        {
            DataTable output = null;
            SqlConnection con = new SqlConnection(strConnection);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                string sql = "Select * from Books";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                output = new DataTable();
                da.Fill(output);
            }
            finally
            {
                con.Close();
            }
            return output;
        }

        public bool AddBook(BookDTO dto)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strConnection);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                string sql = "Insert into Books values(@ID, @Name, @Price)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", dto.BookID);
                cmd.Parameters.AddWithValue("@Name", dto.BookName);
                cmd.Parameters.AddWithValue("@Price", dto.BookPrice);
                int count = cmd.ExecuteNonQuery();
                if(count > 0)
                {
                    result = true;
                }

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public bool UpdateBook(BookDTO dto)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strConnection);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                string sql = "Update Books set BookName=@Name, BookPrice=@Price where BookID=@ID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", dto.BookID);
                cmd.Parameters.AddWithValue("@Name", dto.BookName);
                cmd.Parameters.AddWithValue("@Price", dto.BookPrice);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    result = true;
                }

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public bool DeleteBook(int bookID)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strConnection);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                string sql = "Delete Books where BookID=@ID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", bookID);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    result = true;
                }

            }
            finally
            {
                con.Close();
            }
            return result;
        }
    }
}
