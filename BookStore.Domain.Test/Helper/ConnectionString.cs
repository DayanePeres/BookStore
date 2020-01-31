using BookStore.Data;

namespace BookStore.Integrated.Test.Helper
{
    public class ConnectionString
    {
        public static void SetDev()
        {
            EnvironmentProperties.ConnectionString = "";
        }
    }
}
