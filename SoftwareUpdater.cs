using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cracker
{
    public class SoftwareUpdater : Updater
    {
        private Version m_Version;
        private string? m_Url;

        public SoftwareUpdater()
            : base("http://www.xiaonh.com/bitcoincracker/software.json")
        {
            m_Version = new Version();
            m_Url = null;
        }

        public bool HasNew
        {
            get
            {
                AssemblyProductAttribute? productAttr = (AssemblyProductAttribute?)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyProductAttribute));
                string product = productAttr?.Product ?? string.Empty;
                Version? version = Assembly.GetExecutingAssembly().GetName().Version;
                return version != null && m_Version > version;
            }
        }
        public string? Url { get { return m_Url; } }

        public bool Update()
        {
            try
            {
                string json = ReadJson();
                JObject? obj = JsonConvert.DeserializeObject<JObject>(json);
                if (obj == null)
                    return false;

                JToken? versionToken = obj["Version"];
                JToken? urlToken = obj["Url"];

                if (versionToken == null || urlToken == null)
                    return false;

                m_Version = Version.Parse(versionToken.Value<string>() ?? string.Empty);
                m_Url = urlToken.Value<string>();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
