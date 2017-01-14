using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebAppLinkProxy.Config;

namespace WebAppLinkProxy
{
    class Router
    {
        private readonly RoutingConfig _config;

        public Router(RoutingConfig config)
        {
            _config = config;
        }

        public bool TryRoute(Uri siteUri, out Uri launchUri)
        {
            var domain = siteUri.Host;
            DomainConfig domainConfig;
            if (!_config.Domains.TryGetValue(domain, out domainConfig))
            {
                launchUri = null;
                return false;
            }

            foreach (var pattern in domainConfig.Patterns)
            {
                var regex = new Regex(pattern);
                var match = regex.Match(siteUri.PathAndQuery);
                if (!match.Success)
                    continue;

                var resultUriString = domainConfig.LaunchUri;
                foreach (var groupName in regex.GetGroupNames())
                {
                    resultUriString = resultUriString.Replace($"{{{groupName}}}", match.Groups[groupName].Value);
                }

                launchUri = new Uri(resultUriString);
                return true;
            }

            launchUri = null;
            return false;
        }
    }
}
