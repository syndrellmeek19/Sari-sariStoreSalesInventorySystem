using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SariSariStoreSIS
{
    public class SQLCONNECTION
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\_\SariSariStoreSIS\SariSariStoreSIS\Database1.mdf;Integrated Security=True;Connect Timeout=30;");
            return con;
        }
    }
}
