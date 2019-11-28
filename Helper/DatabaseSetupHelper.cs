using System;
using System.Collections.Generic;
using System.Text;

namespace Virgo.Backend.UpdateDatabase.Helper
{
    public class DatabaseSetupHelper
    {
        public static string GetDatabaseConnectionString()
        {
            // TODO: Get connection properties from environment variables
            // test connection string
            return "server=localhost;port=46986;database=VirgoLocal;user=root;password=my-secret-pw";
        }
    }
}