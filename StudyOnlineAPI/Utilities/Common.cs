using Microsoft.Extensions.Configuration;
using System.IO;

namespace StudyOnlineAPI.Utilities
{
    public class Common
    {
        private static IConfiguration _config;

        public static IConfiguration AppSettings
        {
            get
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
                _config = builder.Build();
                return _config;
            }
        }
    }
}
