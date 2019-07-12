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
        public static int R_GIVEORDER { get => r_GIVEORDER; }
        public static int R_FOREPERSON { get => r_FOREPERSON; }
        public static int R_OTHER { get => r_OTHER; }

        /// <summary>
        /// Список работников по заданному праву
        /// </summary>
        /// <param name="rule">Право (1 - Отдающий расопряжение, 2 - Производитель, 5 - Член бригады</param>
        /// <returns>Список</returns>
        public List<Emp_v2> EmployesOfRule(int rule)
        {
            List<Emp_v2> result = new List<Emp_v2>();
            DataTable dTable = new DataTable();
            
            switch (rule)
            {
                case 1:
                    dTable = SQL.Query("SELECT * FROM 'emp' WHERE `rGiveOrder` = 1");
                    break;
                case 2:
                    dTable = SQL.Query("SELECT * FROM 'emp' WHERE `rForePerson` = 1");
                    break;
                case 5:
                    dTable = SQL.Query("SELECT * FROM 'emp'");
                    break;
                default:
                    break;
            }
            foreach (DataRow item in dTable.Rows)
            {
                Emp_v2 temp = new Emp_v2(item);
                result.Add(temp);
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
        /// Загрузка списка работников из базы
        /// </summary>
        public void Load()
        {
            employees.Clear();
            DataTable dTable = SQL.Query("SELECT * FROM 'emp'");
            if (dTable.Rows.Count != 0)
            {
                foreach (DataRow item in dTable.Rows)
                {
                    Emp_v2 temp = new Emp_v2(item);
                    Employees.Add(temp);
                }
            }
            

        }
    }
}