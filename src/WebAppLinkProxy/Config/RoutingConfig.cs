using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppLinkProxy.Config
{
    class RoutingConfig
    {
        public IDictionary<string, DomainConfig> Domains { get; set; }
    }
}
