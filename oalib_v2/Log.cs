using System;
using System.IO;
using System.Windows.Forms;

namespace oalib
{
    /// <summary>
    /// Объект для ведения логов ошибок
    /// </summary>
    [Serializable]
    public class Log
    {
        
        /// <summary>
        /// Запись журнала ошибок
        /// </summary>
        /// <param name="sLog">Текст ошибки</param>
        public Log(string sLog)
        {
            if (!File.Exists(Const.FILE_LOG))
            {
                StreamWriter createfile = File.CreateText(Const.FILE_LOG);
                createfile.Close();
            }
            StreamWriter addlog = File.AppendText(Const.FILE_LOG);

            addlog.WriteLine("[" + DateTime.Now.ToString("u") + "]" + sLog);
            addlog.Close();
            if (Const.IS_DEBUG)
#pragma warning disable CS0162 // Обнаружен недостижимый код
                MessageBox.Show(sLog);
#pragma warning restore CS0162 // Обнаружен недостижимый код
        }



    }


}