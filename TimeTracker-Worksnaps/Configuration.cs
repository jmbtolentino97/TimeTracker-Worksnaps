using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker_Worksnaps
{
    internal static class Configuration
    {
        static readonly ConfigurationBuilder _configurationBuilder = new ConfigurationBuilder();
        static readonly IConfiguration _configuration;

        static Configuration()
        {
            _configurationBuilder.AddJsonFile("appSettings.json".AbsPath());
            _configuration = _configurationBuilder.Build();
        }

        public static string GetApiKey()
        {
            return _configuration.GetSection("api_key").Value;
        }

        public static string GetProjectId()
        {
            return _configuration.GetSection("project_id").Value;
        }

        public static string GetUserId()
        {
            return _configuration.GetSection("user_id").Value;
        }
    }
}
