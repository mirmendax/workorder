﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace oalib
{
    /// <summary>
    /// Класс адаптер запросов в базу.
    /// </summary>
    public class SQL
    {

        /// <summary>
        /// Версия
        /// </summary>
        /// <param name="program">???</param>
        /// <returns></returns>
        public static string Version(string program)
        {
            string result = "";
            DataTable dTable = Query("SELECT * FROM 'versions' WHERE name = '" + program + "'");
            if (dTable.Rows.Count > 0)
                result = dTable.Rows[0]["version"].ToString() + "." + dTable.Rows[0]["build"].ToString() + "";

            return result;
        }

        /// <summary>
        /// Перевод из JSON в список членов бригады
        /// </summary>
        /// <param name="json">Строка из базы</param>
        /// <returns>Список членов бригады</returns>
        public static List<Emp> JSONToTeam(string json)
        {
            List<Emp> result = new List<Emp>();
            try
            {
                Team team = JsonConvert.DeserializeObject<Team>(json);
                foreach (int i in team.team)
                {
                    DataTable dT = Query("SELECT * FROM 'emp' WHERE id=" + i.ToString());
                    Emp temp = new Emp(dT.Rows[0]);
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
        public static string TeamToJSON(List<Emp> team)
        {
            string result = "";
            try
            {
                Team tt = new Team();
                foreach (Emp item in team)
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
        /// <summary>
        /// Удаление записи из базы
        /// </summary>
        /// <param name="id">ИД записи для удаления</param>
        /// <param name="table">таблица: если order то удаляется, если emp то значение hide этой записи присваивается 1</param>
        /// <returns></returns>
        public static bool Delete(int id, string table)
        {
            bool result = false;
            if (!File.Exists(Const.DATA_FILE))
            {
                MessageBox.Show("База данных отсутсвует.");
                return result;
            }
            try
            {
                SQLiteConnection Conn = new SQLiteConnection(Const.SQL_CONNECTION);
                string str_update = "";
                if (table == "emp")
                {
                    str_update = "UPDATE '" + table + "' SET 'hide' = 1 " +
                    "WHERE id = " + id.ToString();
                }
                else
                {
                    str_update = "DELETE FROM '" + table + "' WHERE id = " + id.ToString();
                }

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
        /// <summary>
        /// Изменение видимости Работника
        /// </summary>
        /// <param name="id">ID работника</param>
        /// <param name="mode">Видимость (true - видимый, false - не видимый)</param>
        /// <returns></returns>
        public static bool EditHideModeEmploy(int id, bool mode)
        {
            bool result = false;
            if (!File.Exists(Const.DATA_FILE))
            {
                MessageBox.Show("База данных отсутсвует.");
                return result;
            }
            try
            {
                SQLiteConnection Conn = new SQLiteConnection(Const.SQL_CONNECTION);
                var str_query = $"UPDATE 'emp' SET 'hide' = {(mode ? '0' : '1')} WHERE id = {id}";
                SQLiteCommand Command = new SQLiteCommand(str_query, Conn);

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

        public static bool Update(int id, Emp data)
        {
            bool result = false;
            if (!File.Exists(Const.DATA_FILE))
            {
                MessageBox.Show("База данных отсутсвует.");
                return result;
            }
            try
            {
                SQLiteConnection Conn = new SQLiteConnection(Const.SQL_CONNECTION);

                string str_update = "UPDATE 'emp' SET 'name' = @name, 'group' = @group, 'rGiveOrder' = @rGive, 'rForePerson' = @rFore " +
                    "WHERE id = " + id.ToString();

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


        public static bool Insert(Emp data)
        {
            bool result = false;
            if (!File.Exists(Const.DATA_FILE))
            {
                MessageBox.Show("База данных отсутсвует.");
                return result;
            }
            try
            {
                SQLiteConnection Conn = new SQLiteConnection(Const.SQL_CONNECTION);
                
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

        public static bool InsertAC(Data data)
        {
            bool result = false;
            if (!File.Exists(Const.DATA_FILE))
            {
                MessageBox.Show("База данных отсутсвует.");
                return result;
            }
            try
            {
                string str_select = "";
                string str_insert = "";
                DataTable dTable;
                SQLiteDataAdapter adapter;

                SQLiteConnection Conn = new SQLiteConnection(Const.SQL_CONNECTION);

                //Проверка на совпадение в базе (ac_estr) по estr
                str_select = "SELECT count(*) AS 'count' FROM `ac_estr` WHERE text = '" + data.estr + "'";
                dTable = new DataTable();
                adapter = new SQLiteDataAdapter(str_select, Conn);
                Conn.Open();
                adapter.Fill(dTable);
                Conn.Close();
                if (dTable.Rows[0]["count"].ToString() == "0")
                {
                    str_insert = "INSERT INTO 'ac_estr' (text) VALUES (@text)";
                    SQLiteCommand Command = new SQLiteCommand(str_insert, Conn);
                    Command.Parameters.AddWithValue("@text", data.estr);
                    Conn.Open();
                    Command.ExecuteNonQuery();
                    Conn.Close();
                }

                //Проверка на совпадение в базе (ac_instr) по instr
                str_select = "SELECT count(*) AS 'count' FROM `ac_instr` WHERE text = '" + data.instr + "'";
                dTable = new DataTable();
                adapter = new SQLiteDataAdapter(str_select, Conn);
                Conn.Open();
                adapter.Fill(dTable);
                Conn.Close();
                if (dTable.Rows[0]["count"].ToString() == "0")
                {
                    str_insert = "INSERT INTO 'ac_instr' (text) VALUES (@text)";
                    SQLiteCommand Command = new SQLiteCommand(str_insert, Conn);
                    Command.Parameters.AddWithValue("@text", data.instr);
                    Conn.Open();
                    Command.ExecuteNonQuery();
                    Conn.Close();
                }
                if (data.dop_instr != "")
                {
                    //Проверка на совпадение в базе (ac_instrd) по dop_instr
                    str_select = "SELECT count(*) AS 'count' FROM `ac_instrd` WHERE text = '" + data.dop_instr + "'";
                    dTable = new DataTable();
                    adapter = new SQLiteDataAdapter(str_select, Conn);
                    Conn.Open();
                    adapter.Fill(dTable);
                    Conn.Close();
                    if (dTable.Rows[0]["count"].ToString() == "0")
                    {
                        str_insert = "INSERT INTO 'ac_instrd' (text) VALUES (@text)";
                        SQLiteCommand Command = new SQLiteCommand(str_insert, Conn);
                        Command.Parameters.AddWithValue("@text", data.dop_instr);
                        Conn.Open();
                        Command.ExecuteNonQuery();
                        Conn.Close();
                    }

                }
                if (data.tech != "")
                {
                    //Проверка на совпадение в базе (ac_instrd) по dop_instr
                    str_select = "SELECT count(*) AS 'count' FROM `ac_tech` WHERE text = '" + data.tech + "'";
                    dTable = new DataTable();
                    adapter = new SQLiteDataAdapter(str_select, Conn);
                    Conn.Open();
                    adapter.Fill(dTable);
                    Conn.Close();
                    if (dTable.Rows[0]["count"].ToString() == "0")
                    {
                        str_insert = "INSERT INTO 'ac_tech' (text) VALUES (@text)";
                        SQLiteCommand Command = new SQLiteCommand(str_insert, Conn);
                        Command.Parameters.AddWithValue("@text", data.tech);
                        Conn.Open();
                        Command.ExecuteNonQuery();
                        Conn.Close();
                    }

                }
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

        public static bool Insert(Order data)
        {
            bool result = false;
            if (!File.Exists(Const.DATA_FILE))
            {
                MessageBox.Show("База данных отсутсвует.");
                return result;
            }
            try
            {
                SQLiteConnection Conn = new SQLiteConnection(Const.SQL_CONNECTION);


                string str_insert = "INSERT INTO `order` ('estr', 'date', 'giveorder', 'foreperson', 'team', 'instr', 'tech' ) " +
                    "VALUES (@estr, @date, @give, @fore, @team, @instr, @tech)";

                SQLiteCommand Command = new SQLiteCommand(str_insert, Conn);
                Command.Parameters.AddWithValue("@estr", data.estr);
                Command.Parameters.AddWithValue("@date", data.date.ToString(Const.DATE_FORMAT));
                Command.Parameters.AddWithValue("@give", data.GiveOrder.ID);
                Command.Parameters.AddWithValue("@fore", data.ForePerson.ID);
                Command.Parameters.AddWithValue("@team", TeamToJSON(data.teamOrder));
                Command.Parameters.AddWithValue("@instr", data.instr);
                Command.Parameters.AddWithValue("@tech", data.tech);
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
                MessageBox.Show("База данных отсутсвует.");
                return new DataTable();
            }
            try
            {
                SQLiteConnection Conn = new SQLiteConnection(Const.SQL_CONNECTION);
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


}