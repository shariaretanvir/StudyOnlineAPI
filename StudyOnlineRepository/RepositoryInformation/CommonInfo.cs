using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnlineRepository.RepositoryInformation
{
    public class CommonInfo
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
