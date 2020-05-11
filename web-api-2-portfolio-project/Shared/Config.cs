using System.Configuration;

namespace web_api_2_portfolio_project.Shared
{
    public class Config
    {
        public static string GetClientID()
        {
            return ConfigurationManager.AppSettings.Get("client-id");
        }

        public static string GetClientSecret()
        {
            return ConfigurationManager.AppSettings.Get("client-secret");
        }
    }
}