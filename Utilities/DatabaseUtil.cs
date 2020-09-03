using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.BussinessLib
{
    class DatabaseUtil
    {
        public static SqlConnection GetDBConnection()
        {
            var str = ConfigurationManager.AppSettings.Get("STA_DB");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            return conn;
        }
        public static String GetResultsFromDB(String Query)
        {

            SqlConnection conn = GetDBConnection();
            string output = "";
            SqlCommand cmd = new SqlCommand(Query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                output = Convert.ToString(reader.GetValue(0));
                // output = Convert.ToString(reader["ID"].ToString());
                // Console.WriteLine(output);
            }

            reader.Close();
            conn.Close();
            return output;
        }
    }
}
