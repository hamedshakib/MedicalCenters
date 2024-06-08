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
                                        .AddJsonFile(string.Equals(environment,"development",StringComparison.OrdinalIgnoreCase) ? "appsettings.Development.json" : "appsettings.json",optional:false,reloadOnChange:true)
                                        .Build();
            return configuration;
        }
    }
}
