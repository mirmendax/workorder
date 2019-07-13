using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data.SQLite;
using System.Data;

namespace oalib
{
    /// <summary>
    /// Объект списка работника
    /// </summary>
    [Serializable]
    public class EmpS
    {
        

        private List<Emp> employees;
        private static int r_GIVEORDER = 1;//Право отдающего распоряжение
        private static int r_FOREPERSON = 2;//Право производителя работ
        private static int r_OTHER = 5;//Член бригады

        

        public List<Emp> Employees { get => employees; set => employees = value; }
        public static int R_GIVEORDER { get => r_GIVEORDER; }
        public static int R_FOREPERSON { get => r_FOREPERSON; }
        public static int R_OTHER { get => r_OTHER; }

        /// <summary>
        /// Список работников по заданному праву
        /// </summary>
        /// <param name="rule">Право (1 - Отдающий расопряжение, 2 - Производитель, 5 - Член бригады</param>
        /// <returns>Список</returns>
        public List<Emp> EmployesOfRule(int rule)
        {
            List<Emp> result = new List<Emp>();
            DataTable dTable = new DataTable();
            
            switch (rule)
            {
                case 1:
                    dTable = SQL.Query("SELECT * FROM 'emp' WHERE `rGiveOrder` = 1 AND `hide` = 1");
                    break;
                case 2:
                    dTable = SQL.Query("SELECT * FROM 'emp' WHERE `rForePerson` = 1 AND `hide` = 1");
                    break;
                case 5:
                    dTable = SQL.Query("SELECT * FROM 'emp' WHERE `hide` = 1");
                    break;
                default:
                    break;
            }
            foreach (DataRow item in dTable.Rows)
            {
                Emp temp = new Emp(item);
                result.Add(temp);
            }
            return result;
        }


       /// <summary>
       /// Конструктор класса
       /// </summary>
        public EmpS()
        {
            Employees = new List<Emp>();
        }

        
    }
}