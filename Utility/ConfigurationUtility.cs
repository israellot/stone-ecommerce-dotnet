using System;
using System.Configuration;

namespace GatewayApiClient.Utility {

    internal class ConfigurationUtility {

        public static string GetConfigurationString(string configurationName) {

            configurationName = string.Concat("GatewayService.", configurationName);

            string configurationValue = ConfigurationManager.AppSettings[configurationName];
            if (string.IsNullOrWhiteSpace(configurationValue)) { throw new ConfigurationErrorsException("Missing configuration: " + configurationName); }

            return configurationValue;
        }
        public static Guid GetConfigurationKey(string configurationName) {

            string configurationValue = ConfigurationUtility.GetConfigurationString(configurationName);

            Guid key;
            if (Guid.TryParse(configurationValue, out key) == false) { throw new ConfigurationErrorsException("Invalid configuration format: " + configurationName); }

            return key;
        }
    }
}
