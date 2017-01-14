using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppLinkProxy.Config
{
    static class RoutingConfigValidation
    {
        public static void Validate(this RoutingConfig config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            if (config.Domains == null)
                throw new ArgumentException("Domains may not be null.", nameof(config));

            foreach (var domainConfigItem in config.Domains)
            {
                var domainConfig = domainConfigItem.Value;
                if (domainConfig.Patterns == null)
                    throw new ArgumentException($"Patterns may not be null, domain {domainConfigItem.Key}", nameof(config));

                if (domainConfig.Patterns.Any(m => m == null))
                    throw new ArgumentException($"Patterns may not contain null items, domain {domainConfigItem.Key}", nameof(config));

                if (domainConfig.LaunchUri == null)
                    throw new ArgumentException($"LaunchUri may not be null, domain {domainConfigItem.Key}", nameof(config));
            }
        }
    }
}
