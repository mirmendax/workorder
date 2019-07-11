using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data.SQLite;
using System.Data;

namespace oalib_v2
{
    /// <summary>
    /// Объект списка работника
    /// </summary>
    [Serializable]
    public class EmpS_v2
    {
        const string FILE = "emps_v2.wo";

        private List<Emp_v2> employees;
        private static int r_GIVEORDER = 1;//Право отдающего распоряжение
        private static int r_FOREPERSON = 2;//Право производителя работ
        private static int r_OTHER = 5;//Член бригады

        public static string FILE1 => FILE;

        public List<Emp_v2> Employees { get => employees; set => employees = value; }
        public static int R_GIVEORDER { get => r_GIVEORDER; set => r_GIVEORDER = value; }
        public static int R_FOREPERSON { get => r_FOREPERSON; set => r_FOREPERSON = value; }
        public static int R_OTHER { get => r_OTHER; set => r_OTHER = value; }

        /// <summary>
        /// Список работников по заданному праву
        /// </summary>
        /// <param name="rule">Право</param>
        /// <returns>Список</returns>
        public List<Emp_v2> EmployesOfRule(int rule)
        {
            List<Emp_v2> result = new List<Emp_v2>();
            if (rule == R_OTHER)
            {
                return Employees;
            }
            if (Employees.Count != 0)
            {
                for (int i = 0; i <= Employees.Count - 1; i++)
                {
                    if (rule == R_GIVEORDER)
                    {
                        if (Employees[i].RuleGiveOrder)
                            result.Add(Employees[i]);
                    }
                    if (rule == R_FOREPERSON)
                    {
                        if (Employees[i].RuleForePerson)
                            result.Add(Employees[i]);
                    }


                }
            }

            return result;
        }

       /// <summary>
       /// Конструктор класса
       /// </summary>
        public EmpS_v2()
        {
            Employees = new List<Emp_v2>();
        }

        /// <summary>
        /// Сохранение списка работников в файл
        /// </summary>
        public void Save()
        {
            /*
            BinaryFormatter data = new BinaryFormatter();
            FileStream file = File.Open(FILE1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            data.Serialize(file, this.Employees);
            file.Close();
            */
            


        }

        /// <summary>
        /// Загрузка списка работников из файла
        /// </summary>
        public void Load()
        {
            /*
             * BinaryFormatter data = new BinaryFormatter();
            if (!File.Exists(FILE1))
            {
                File.Open(FILE1, FileMode.OpenOrCreate, FileAccess.ReadWrite).Close();
            }
            FileStream file = File.Open(FILE1, FileMode.Open, FileAccess.ReadWrite);
            try
            {
                Employees = (data.Deserialize(file) as List<Emp_v2>);
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                new Log("Error Emps_v2 of :" + e.Message);
            }
            file.Close();
             */
            if (!File.Exists(Const.DATA_FILE))
            {
                System.Windows.Forms.MessageBox.Show("База данных отсутсвует.");
            }
            else
            {
                try
                {
                    SQLiteConnection Conn = new SQLiteConnection("Data Source = data.db; Version = 3");
                    Conn.Open();
                    
                    String query = "";
                    DataTable dTable = new DataTable();


                    query = "SELECT * FROM emp";

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, Conn);
                    adapter.Fill(dTable);

                    if (dTable.Rows.Count != 0 )
                    {
                        foreach (DataRow item in dTable.Rows)
                        {
                            Emp_v2 temp = new Emp_v2(item);
                            Employees.Add(temp);
                        }
                    }

                }
                catch (SQLiteException ex)
                {
                    new Log("Error DB: " + ex.Message);
                }
            }

        }
    }
}