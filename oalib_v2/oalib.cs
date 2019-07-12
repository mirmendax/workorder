using System;
using System.IO;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace oalib_v2
{

    public class Const
    {
        public const string DATA_FILE = "data.db";
        public const string DATE_FORMAT = "dd.MM.yy";
    }

    public class SQL
    {
        /// <summary>
        /// Перевод из JSON в список членов бригады
        /// </summary>
        /// <param name="json">Строка из базы</param>
        /// <returns>Список членов бригады</returns>
        public static List<Emp_v2> JSONToTeam(string json)
        {
            List<Emp_v2> result = new List<Emp_v2>();
            try
            {
                Team team = JsonConvert.DeserializeObject<Team>(json);
                foreach(int i in team.team)
                {
                    DataTable dT = SQL.Query("SELECT * FROM 'emp' WHERE id=" + i.ToString());
                    Emp_v2 temp = new Emp_v2(dT.Rows[0]);
                    result.Add(temp);
                }
                return result;
            }
            catch (Exception ex)
            {
                new Log("Error json: " + ex.Message);
                return result;
            }
            
        }
        /// <summary>
        /// Перевод из списка членов бригады в JSON
        /// </summary>
        /// <param name="team">Список членов бригады</param>
        /// <returns>Строка JSON</returns>
        public static string TeamToJSON(List<Emp_v2> team)
        {
            string result = "";
            try
            {
                Team tt = new Team();
                foreach (Emp_v2 item in team)
                {
                    tt.team.Add(item.ID);
                }
                result = JsonConvert.SerializeObject(tt, Formatting.None);
                return result;
            }
            catch (Exception ex)
            {
                new Log("Error json: " + ex.Message);
                return result;
            }
        }

        public static bool Delete(int id, string table)
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


                string str_update = "DELETE FROM '"+ table + "' WHERE id=" + id.ToString();

                SQLiteCommand Command = new SQLiteCommand(str_update, Conn);
                
                Conn.Open();
                if (Command.ExecuteNonQuery() > 0)
                {
                    Conn.Close();

                    return true;
                }
                else
                {
                    Conn.Close();
                    return result;
                }
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

        public static bool Update(int id, Emp_v2 data)
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


                string str_update = "UPDATE 'emp' SET 'name' = @name, 'group' = @group, 'rGiveOrder' = @rGive, 'rForePerson' = @rFore " +
                    "WHERE id = " + id.ToString(); ;

                SQLiteCommand Command = new SQLiteCommand(str_update, Conn);
                Command.Parameters.AddWithValue("@name", data.Name);
                Command.Parameters.AddWithValue("@group", data.group);
                Command.Parameters.AddWithValue("@rGive", data.RuleGiveOrder);
                Command.Parameters.AddWithValue("@rFore", data.RuleForePerson);
                Conn.Open();
                if (Command.ExecuteNonQuery() > 0)
                {
                    Conn.Close();

                    return true;
                }
                else
                {
                    Conn.Close();
                    return result;
                }
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
                

                string str_insert = "INSERT INTO `emp` ('name', 'group', 'rGiveOrder', 'rForePerson') VALUES (@name_emp, @group, @rGive, @rFore)";

                SQLiteCommand Command = new SQLiteCommand(str_insert, Conn);
                Command.Parameters.AddWithValue("@name_emp", data.Name);
                Command.Parameters.AddWithValue("@group", data.group);
                Command.Parameters.AddWithValue("@rGive", data.RuleGiveOrder);
                Command.Parameters.AddWithValue("@rFore", data.RuleForePerson);
                Conn.Open();
                if (Command.ExecuteNonQuery() > 0)
                {
                    Conn.Close();

                    return true;
                }
                else
                {
                    Conn.Close();
                    return result;
                }
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

        public static bool Insert(Order_v2 data)
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


                string str_insert = "INSERT INTO `order` ('estr', 'date', 'giveorder', 'foreperson', 'team', 'instr' ) " +
                    "VALUES (@estr, @date, @give, @fore, @team, @instr)";

                SQLiteCommand Command = new SQLiteCommand(str_insert, Conn);
                Command.Parameters.AddWithValue("@estr", data.estr);
                Command.Parameters.AddWithValue("@date", data.date.ToString(Const.DATE_FORMAT));
                Command.Parameters.AddWithValue("@give", data.GiveOrder.ID);
                Command.Parameters.AddWithValue("@fore", data.ForePerson.ID);
                Command.Parameters.AddWithValue("@team", TeamToJSON(data.brigada));
                Command.Parameters.AddWithValue("@instr", data.instr);
                Conn.Open();
                if (Command.ExecuteNonQuery() > 0)
                {
                    Conn.Close();

                    return true;
                }
                else
                {
                    Conn.Close();
                    return result;
                }
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
    public class Team
    {
        public List<int> team = new List<int>();
    }


}