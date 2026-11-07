using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cracker
{
    public abstract class Updater
    {
        private readonly string m_Url;

        public Updater(string url)
        {
            m_Url = url;
        }

        protected string ReadJson()
        {
            using HttpClient client = new HttpClient();
            return client.GetStringAsync(m_Url).GetAwaiter().GetResult();
        }
    }
}
