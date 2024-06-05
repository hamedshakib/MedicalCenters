using Microsoft.Extensions.Configuration;

namespace Utility.Configuration
{
    public class Configuration
    {
        public static IConfigurationRoot GetAppSettingJson()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCore_Environment");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile(environment == "Development" ? "appsettings.Development.json" : "appsettings.json")
                                        .Build();
            return configuration;
        }
    }
}
