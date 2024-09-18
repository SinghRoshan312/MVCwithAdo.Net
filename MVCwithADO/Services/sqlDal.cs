using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace MVCwithADO.Services
{
    public class sqlDal
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataSet ds;
        public static string connectionString()
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            //con = new SqlConnection(conString);
            return conString;
        }
        public DataSet ExecuteDataSet(SqlCommand scmd)
        { 
            con=new SqlConnection(connectionString());
            cmd=scmd;
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            adapter = new SqlDataAdapter(cmd);
            ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            cmd.Dispose();
            return ds;
        }
        public int ExecuteNonQuery(SqlCommand scmd)
        {
            int i = 0;
            cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(connectionString());
            cmd = scmd;
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandTimeout = 120;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            i = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return i;
        }
    }
}