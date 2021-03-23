using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Application.Core.AppSettingsConfiguration.Enums;

namespace Application.Core.AppSettingsConfiguration
{
    public static class AppSettingsConfigurations
    {
        private static readonly ReadOnlyDictionary<ConfigurationType, string> ConfigurationTypes;

        static AppSettingsConfigurations()
        {
            ConfigurationTypes = new ReadOnlyDictionary<ConfigurationType, string>(new Dictionary<ConfigurationType, string>
            {
                {
                    ConfigurationType.CorsConfiguration, "CorsConfiguration"
                }
            });
        }

        public static string GetConfigurationType(ConfigurationType key)
        {
            ConfigurationTypes.TryGetValue(key, out string result);

            if (result == null)
            {
                throw new ArgumentNullException(nameof(result), $"The following Configuration Type does not exist with this key. {nameof(key).ToUpper()}: {key}");
            }

            return result;
        }
    }
}
