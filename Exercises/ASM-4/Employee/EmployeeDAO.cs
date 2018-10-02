using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Employee
{
    public class EmployeeDAO
    {
        string strConnection;
        public EmployeeDAO()
        {
            strConnection = ConfigurationManager.ConnectionStrings["BookStoreDB"].ConnectionString;

        }

        public EmployeeDTO CheckLogin(string empID, string empPass)
        {
            EmployeeDTO output = null;
            SqlConnection con = new SqlConnection(strConnection);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                string sql = "Select EmpRole from Employee where EmpID=@ID and EmpPassword=@Pass";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", empID);
                cmd.Parameters.AddWithValue("@Pass", empPass);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        bool empRole = (bool) reader["EmpRole"];
                        output = new EmployeeDTO { EmpID = empID, EmpPassword = empPass, EmpRole = empRole };
                    }
                    
                }
            }
            finally
            {
                con.Close();
            }
            return output;
        }

        public bool ChangePassword(string empID, string empPass)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strConnection);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                string sql = "Update Employee set EmpPassword=@Pass where EmpID=@ID ";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", empID);
                cmd.Parameters.AddWithValue("@Pass", empPass);
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
    }
}
