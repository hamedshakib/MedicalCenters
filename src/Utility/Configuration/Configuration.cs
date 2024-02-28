using Microsoft.Extensions.Configuration;

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
