using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WeChatLib
{
    public class LogRecord
    {
        static string logpath = string.Empty;
        private static ConcurrentDictionary<string, object> fileLockDic = new ConcurrentDictionary<string, object>();
        static LogRecord()
        {
            try
            {
                //if (System.Configuration.ConfigurationManager.AppSettings["logpath"] != null && System.Configuration.ConfigurationManager.AppSettings["logpath"] != "")
                //{
                //    logpath = System.Configuration.ConfigurationManager.AppSettings["logpath"];
                //}
                //else
                {
                    logpath = @"d:\WeChatLog\";
                }

                if (!System.IO.Directory.Exists(logpath))
                {
                    System.IO.Directory.CreateDirectory(logpath);
                }
            }
            catch
            {
                throw;
            }

        }
        public static void writeLogsingle(string filename, string logMessage)
        {
            object lockObject = fileLockDic.GetOrAdd(filename, new object());

            lock (lockObject)
            {
                logMessage = string.Format("{0} {1}\r\n", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), logMessage);
                string fLogName = string.Format("{0}{1}{2}", logpath, System.DateTime.Now.ToString("yyyy-MM-dd HH "), filename);
                try
                {
                    if (!fLogName.EndsWith(".log"))
                    {
                        fLogName += ".log";
                    }
                    using (FileStream fs = new FileStream(fLogName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                    {
                        using (BinaryWriter w = new BinaryWriter(fs))
                        {
                            w.Write(logMessage.ToCharArray());
                        }
                    }
                }
                catch (Exception exp)
                {
                    string s = exp.Message;
                }
                return;
            }
        }
    }
}
