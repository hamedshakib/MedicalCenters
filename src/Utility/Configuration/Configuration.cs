using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Configuration
{
    public class Configuration
    {
        public static IConfigurationRoot GetAppSettingJson()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build();
            return configuration;
        }
    }
}
