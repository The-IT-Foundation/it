using System.Threading.Tasks;

namespace it.core.Examples.Configuration
{
    partial class AppSettings
    {
        public static string Environment => IT.Get("ENV", "BASIC", "DEV");
        public static bool IsProduction => Environment == "PROD";
        public static string SomeServiceApiKey => IT.Get("SomeServiceApiKey", "INTEGRATION", "api-key-test-sandbox");
    }

}