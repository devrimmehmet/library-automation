using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Kütüphane_Yönetim_Otomasyonu
{
    
    public class ConnectionString
    {
        SqlConnection sqlConnection = new SqlConnection($"Data Source=.;Initial Catalog=Library;Integrated Security=True");
        public void Connection()
        {
            
            
        }
        public void Login()
        {

        }
        public void LoginConnection()
        {

           
        }
    }
}
