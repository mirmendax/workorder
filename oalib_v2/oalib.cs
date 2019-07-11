using System;
using System.IO;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace oalib_v2
{

    public class Const
    {
        public const string DATA_FILE = "data.db";
    }

    public class SQL
    {
        public static bool Insert(Emp_v2 data)
        {
            bool result = false;
            if (!File.Exists(Const.DATA_FILE))
            {
                System.Windows.Forms.MessageBox.Show("База данных отсутсвует.");
                return result;
            }
            try
            {
                SQLiteConnection Conn = new SQLiteConnection("Data Source = data.db; Version = 3");
                

                string str_insert = "INSERT INTO `emp` ('name', 'group', 'rGiveOrder', 'rForePerson') VALUES ('@name', @group, @rGive, @rFore)";

                SQLiteCommand Command = new SQLiteCommand(str_insert, Conn);
                Command.Parameters.AddWithValue("@name", data.Name);
                Command.Parameters.AddWithValue("@group", data.group);
                Command.Parameters.AddWithValue("@rGive", data.RuleGiveOrder);
                Command.Parameters.AddWithValue("@rFore", data.RuleForePerson);
                Conn.Open();
                Command.ExecuteNonQuery();

                Conn.Close();

                return true;
            }
            catch (SQLiteException ex)
            {
                new Log("Error insert DB: " + ex.Message);
                return result;

            }
            catch (Exception ex)
            {
                new Log("Error Insert: " + ex.Message);
                return result;
            }
        }

        public static DataTable Query(string str)
        {
            if (!File.Exists(Const.DATA_FILE))
            {
                System.Windows.Forms.MessageBox.Show("База данных отсутсвует.");
                return new DataTable();
            } 
            try
            {
                SQLiteConnection Conn = new SQLiteConnection("Data Source = data.db; Version = 3");
                Conn.Open();

                DataTable dTable = new DataTable();


                SQLiteDataAdapter adapter = new SQLiteDataAdapter(str, Conn);
                adapter.Fill(dTable);

                
                Conn.Close();
                return dTable;
            }
            catch (SQLiteException ex)
            {
                new Log("Error DB: " + ex.Message);
                return new DataTable();
                
            }
            catch (Exception ex)
            {
                new Log("Error Query: " + ex.Message);
                return new DataTable();
            }
            
        }
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
            MessageBox.Show(sLog);
        }

        
    }
}