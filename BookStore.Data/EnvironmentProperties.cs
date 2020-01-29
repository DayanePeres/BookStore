using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data
{
    class EnvironmentProperties
    {
        public static int SessionLifeTime = 10;
        public const string DatabaseName = "Library";
        public static string ConnectionString = "Server=localhost,11433;Database=BookStore;Uid=SA;Pwd=DockerSql2017!;";
    }
}
