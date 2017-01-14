using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppLinkProxy.Config
{
    class DomainConfig
    {
        public string Description { get; set; }
        public string[] Patterns { get; set; }
        public string LaunchUri { get; set; }
    }
}
