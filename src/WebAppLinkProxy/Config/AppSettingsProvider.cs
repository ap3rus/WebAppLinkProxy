using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppLinkProxy.Config
{
    class AppSettingsProvider
    {
        private readonly string _fileName;

        public AppSettingsProvider(string fileName)
        {
            _fileName = fileName;
        }

        public T LoadSection<T>(string sectionName)
        {
            // TODO handle exceptions
            var json = File.ReadAllText(_fileName);
            var wholeConfig = JObject.Parse(json);
            var section = wholeConfig.GetValue(sectionName);
            return (T)section.ToObject(typeof(T));
        }
    }
}
