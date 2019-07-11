using System;
using System.Collections.Generic;

namespace oalib_v2
{
    /// <summary>
    /// Объект рапоряжения
    /// </summary>
    [Serializable]
    public class Order_v2
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
        /// Работник отдающий расопряжение
        /// </summary>
        public Emp_v2 GiveOrder = new Emp_v2();
        /// <summary>
        /// Работник производитель работ
        /// </summary>
        public Emp_v2 ForePerson = new Emp_v2();
        /// <summary>
        /// Список членов бригады
        /// </summary>
        public List<Emp_v2> brigada = new List<Emp_v2>();
        /// <summary>
        /// Содержание инструктажа
        /// </summary>
        public string instr = string.Empty;
        

        public override bool Equals(object obj)//????????? ПРОВЕРИТЬ ?????
        {
            if ((obj as Order_v2) == null) return false;
            return ((this.ID == (obj as Order_v2).ID));//??????????????
        }

        public bool checkedOrder(Order_v2 ord)//??????????????????????????
        {
            return ((this.estr == ord.estr)
                &&(this.instr == ord.instr)
                &&(this.GiveOrder == ord.GiveOrder)
                &&(this.ForePerson == ord.ForePerson)
                &&(this.brigada == ord.brigada)
                &&(this.date == ord.date));
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Order_v2() { }

        public Order_v2(Order_v2 o_v2)
        {
            this.ID = o_v2.ID;
            this.number = o_v2.number;
            this.estr = o_v2.estr;
            this.date = o_v2.date;
            this.GiveOrder = o_v2.GiveOrder;
            this.ForePerson = o_v2.ForePerson;
            this.brigada = o_v2.brigada;
            this.instr = o_v2.instr;
        }

        public Order_v2(string _estr, DateTime _date, Emp_v2 _gorder, Emp_v2 _fperson, List<Emp_v2> _brig, string _instr)
        {
            this.ID = 0;
            this.number = 0;
            this.estr = _estr;
            this.date = _date;
            this.GiveOrder = _gorder;
            this.ForePerson = _fperson;
            this.brigada = _brig;
            this.instr = _instr;
        }

    }
}