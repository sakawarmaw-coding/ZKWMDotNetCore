using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZKWMDotNetCore.RestApi
{
    public static class ConnectionString
    {
        public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "ZAKAWARMAW\\SQL2022",
            InitialCatalog = "DotNetTrainingBatch4",
            UserID = "sa",
            Password = "sa@123",
           // TrustServerCertificate = true,
        };
    }
}
