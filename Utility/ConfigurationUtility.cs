using System;
using System.Configuration;
using System.Globalization;

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

        public static bool TryParseDate(string value, out DateTime dateTime, params string[] formatCollection) {
            if (formatCollection == null) { throw new ArgumentNullException("formatCollection"); }
            if (formatCollection.Length == 0) { throw new ArgumentException("At least one format must be specified.", "formats"); }

            foreach (string format in formatCollection) {
                if (DateTime.TryParseExact(value, format, null, DateTimeStyles.None, out dateTime) == true) {
                    return true;
                }
            }

            dateTime = DateTime.MinValue;
            return false;
        }
    }
}
