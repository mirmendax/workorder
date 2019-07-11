using System;
using System.IO;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oalib_v2
{

    public class Const
    {
        public const string DATA_FILE = "data.db";
    }
    /// <summary>
    /// Объект для ведения логов ошибок
    /// </summary>
    [Serializable]
    public class Log
    {
        private const string fILE_LOG = "log_v2.log";
        public static string FILE_LOG => fILE_LOG;
        /// <summary>
        /// Запись журнала ошибок
        /// </summary>
        /// <param name="sLog">Текст ошибки</param>
        public Log(string sLog)
        {
            if (!File.Exists(FILE_LOG))
            {
                StreamWriter createfile = File.CreateText(FILE_LOG);
                createfile.Close();
            }
            StreamWriter addlog = File.AppendText(FILE_LOG);
            
            addlog.WriteLine("["+DateTime.Now.ToString("d.MM.yyyy")+"]"+sLog);
            addlog.Close();
        }

        
    }
}