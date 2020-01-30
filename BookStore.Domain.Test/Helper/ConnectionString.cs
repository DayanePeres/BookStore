using BookStore.Data;

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
