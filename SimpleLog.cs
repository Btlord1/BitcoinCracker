using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracker
{
    public class SimpleLog
    {
        private static readonly string LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cracker.Log");
        private static readonly object LogLock = new object();
        private readonly Action<string>? m_OutputAction;

        public SimpleLog(Action<string>? outputAction = null)
        {
            m_OutputAction = outputAction;
        }

        public void Log(string format, params object[] args)
        {
            lock (LogLock)
            {
                string s = string.Format("{0}: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), string.Format(format, args));
                using (StreamWriter writer = new StreamWriter(LogPath, true))
                {
                    writer.WriteLine(s);
                }

                m_OutputAction?.Invoke(s);
            }
        }
    }
}
