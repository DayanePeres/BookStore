using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Integrated.Test.Helper
{
    public class ConnectionString
    {
        public static void setDev()
        {
            EnvironmentProperties.ConnectionString = "";
        }
    }
}
