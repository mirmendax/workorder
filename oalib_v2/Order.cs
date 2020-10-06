
using System;
using System.Collections.Generic;
using System.Data;

namespace oalib
{
    /// <summary>
    /// Объект рапоряжения
    /// </summary>
    [Serializable]
    public class Order
    {
        /// <summary>
        /// index распоряжения (уникальный)
        /// </summary>
        public int ID = 0;
        /// <summary>
        /// номер распоряжения, наличие этого номера потверждает работу
        /// </summary>
        public int number = 0;
        /// <summary>
        /// поручается
        /// </summary>
        public string estr = string.Empty;
        /// <summary>
        /// Дата расопряжения
        /// </summary>
        public DateTime date = new DateTime();
        /// <summary>
        /// Работник отдающий раcпоряжение
        /// </summary>
        public Emp GiveOrder = new Emp();
        /// <summary>
        /// Работник производитель работ
        /// </summary>
        public Emp ForePerson = new Emp();
        /// <summary>
        /// Список членов бригады
        /// </summary>
        public List<Emp> teamOrder = new List<Emp>();
        /// <summary>
        /// Содержание инструктажа
        /// </summary>
        public string instr = string.Empty;

        public string tech = string.Empty;


        public override bool Equals(object obj)//????????? ПРОВЕРИТЬ ?????
        {
            if (obj as Order == null) return false;
            return ID == (obj as Order).ID;//??????????????
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Order() { }

        public Order(Order o_v2)
        {
            ID = o_v2.ID;
            number = o_v2.number;
            estr = o_v2.estr;
            date = o_v2.date;
            GiveOrder = o_v2.GiveOrder;
            ForePerson = o_v2.ForePerson;
            teamOrder = o_v2.teamOrder;
            instr = o_v2.instr;
            tech = o_v2.tech;
        }

        public Order(DataRow data, bool header=false)
        {
            ID = int.Parse(data["id"].ToString());
            number = int.Parse(data["number"].ToString());
            estr = data["estr"].ToString();
            date = DateTime.Parse(data["date"].ToString());
            if (!header)
            {
                DataTable dTable = SQL.Query("SELECT * FROM 'emp' WHERE id=" + data["giveorder"].ToString());
                GiveOrder = new Emp(dTable.Rows[0]);

                dTable = SQL.Query("SELECT * FROM 'emp' WHERE id=" + data["foreperson"].ToString());
                ForePerson = new Emp(dTable.Rows[0]);

                teamOrder = SQL.JSONToTeam(data["team"].ToString());
                instr = data["instr"].ToString();
                tech = data["tech"].ToString();
            }
        }

        

        public Order(string _estr, DateTime _date, Emp _gorder, Emp _fperson, List<Emp> _brig, string _instr, string _tech)
        {
            ID = 0;
            number = 0;
            estr = _estr;
            date = _date;
            GiveOrder = _gorder;
            ForePerson = _fperson;
            teamOrder = _brig;
            instr = _instr;
            tech = _tech;
        }

    }
}