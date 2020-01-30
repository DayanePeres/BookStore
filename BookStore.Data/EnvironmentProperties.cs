namespace BookStore.Data
{
    public class EnvironmentProperties
    {
        public static int SessionLifeTime = 10;
        public const string DataBaseName = "BookStore";
        public static string ConnectionString = "Server=localhost,11433;Database=BookStore;Uid=SA;Pwd=DockerSql2017!;";
    }
}
