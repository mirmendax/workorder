using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace oalib_v2
{
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
            BinaryFormatter data = new BinaryFormatter();
            FileStream file = File.Open(FILE1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            data.Serialize(file, this.Employees);
            file.Close();
        }

        /// <summary>
        /// Загрузка списка работников из файла
        /// </summary>
        public void Load()
        {
            BinaryFormatter data = new BinaryFormatter();
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
        }
    }

    /// <summary>
    /// Объект работника
    /// </summary>
    [Serializable]
    public class Emp_v2
    {
        public string Name;
        public int group;
        public bool RuleGiveOrder = false;
        public bool RuleForePerson = false;
        public override bool Equals(object obj)
        {
            if ((obj as Emp_v2) == null) return false;
            return (this.Name == (obj as Emp_v2).Name);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Emp_v2() 
        {
            Name = "";
            group = 0;
            RuleGiveOrder = false;
            RuleForePerson = false;
        }

        public Emp_v2(string name, int gr)
        {
            this.Name = name;
            this.group = gr;
        }
        public Emp_v2(string name, int group, bool rGiveOrder, bool rForePerson)
        {
            this.Name = name;
            this.group = group;
            this.RuleGiveOrder = rGiveOrder;
            this.RuleForePerson = rForePerson;
        }
        public override string ToString()
        {
            string result;
            switch (this.group)
            {
                case 1: result = this.Name + " гр I";
                    break;
                case 2: result = this.Name + " гр II";
                    break;
                case 3: result = this.Name + " гр III";
                    break;
                case 4: result = this.Name + " гр IV";
                    break;
                case 5: result = this.Name + " гр V";
                    break;
                default: result = "none";
                    break;
            }
            return result;
        }
    }
    /// <summary>
    /// Данные для автозаполнения
    /// </summary>
    [Serializable]
    public class Data_v2
    {
        public string estr;
        public string instr;
        [OptionalField]
        public string dop_instr;
        public Data_v2()
        {
            estr = "";
            instr = "";
        }
        public Data_v2(string e, string i, string d_i)
        {
            estr = e;
            instr = i;
            dop_instr = d_i;
        }
    }
    /// <summary>
    /// Объект списка распоряжений
    /// </summary>
    public class ListOrder_v2
    {
        const string FILE = "arhiveorder_v2.wo";
        public List<Order_v2> listOrder;
        /// <summary>
        /// Список не подтвержденных распоряжений
        /// </summary>
        /// <returns>Список</returns>
        public List<Order_v2> NotVerifydOrderList()
        {
            List<Order_v2> result = new List<Order_v2>();
            
            foreach (Order_v2 o in listOrder)
            {
                if (o.number == 0)
                    result.Add(o);
            }
            return result;
        }
        /// <summary>
        /// Подтверждение распоряжения
        /// </summary>
        /// <param name="ord">Объект распоряжения </param>
        /// <param name="numOrder">Номер распоряжения</param>
        /// <returns>Если true значит подтвеждено</returns>
        public bool VerifyOrder(Order_v2 ord, int numOrder)
        {
            bool result = false;
            this.Load();
            if (ord != null)
            {
                if (ord.number == 0)
                {
                    
                    int i = this.FindOrder(ord);
                    if (i != -1)
                    {
                        
                        //listOrder[i] = new Order_v2(ord);
                        if (listOrder.Remove(ord))
                        {                       
                            ord.number = numOrder;
                            listOrder.Add(ord);
                            result = true;
                            this.Save();
                        }
                        
                    }
                }
                
            } 

            return result;
        }
        /// <summary>
        /// Удаление не подтвержденного расоряжения
        /// </summary>
        /// <param name="delOrder">Объект распоряжения</param>
        /// <returns>Если true то удалено</returns>
        public bool DeleteOrderNotVerify(Order_v2 delOrder)
        {
            this.Load();
            bool result = false;
            if (listOrder.Remove(delOrder))
            {
                List<Order_v2> nlist = new List<Order_v2>();
                int count = 0;
                foreach (Order_v2 o in listOrder)
                {
                    o.ID = count;
                    nlist.Add(o);
                    count++;
                }
                if ((listOrder.Count - nlist.Count) == 0)
                {
                    listOrder = nlist;
                    result = true;
                }

            }
            Save();
            return result;
        }
        /// <summary>
        /// Поиск распоряжений
        /// </summary>
        /// <param name="fOrder">Объект распоряжения</param>
        /// <returns>Порядковый номер в списке</returns>
        public int FindOrder(Order_v2 fOrder)
        {
            this.Load();
            int result = -1;
            for (int i = 0; i <= listOrder.Count-1; i++)
            {
                if (listOrder[i].Equals(fOrder))
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        public ListOrder_v2()
        {
            listOrder = new List<Order_v2>();
        }
        /// <summary>
        /// Удаление архива
        /// </summary>
        public void ClearArhive()
        {

            listOrder.Clear();
            this.Save();
        }
        /// <summary>
        /// Список распоряжений в заданом интервале времени
        /// </summary>
        /// <param name="a">С</param>
        /// <param name="b">По</param>
        /// <returns>Список распоряжений</returns>
        public List<Order_v2> ShowOrders(DateTime a, DateTime b)
        {
            this.Load();
            List<Order_v2> result = new List<Order_v2>();
            List<DateTime> dd = new List<DateTime>();
            DateTime dcount = a;
            while (dcount <= b)
            {
                dd.Add(dcount);
                dcount = dcount.AddDays(1);
            }
            /*
            foreach (DateTime t in dd)
            {
                foreach (Order_v2 o in listOrder)
                {
                    if ((o.date == t) && (o.number != 0))
                    {
                        result.Add(o);
                        //MessageBox.Show(o.date.ToString("dd.MM.yyyy")+">"+o.ID + " :" + o.number);
                    }
                }
            }
            */
            IEnumerable<Order_v2> query = from o in listOrder
                                          join t in dd on o.date equals t
                                          select o;
            result = query.ToList();
            return result;
        }

        
        /// <summary>
        /// Кол-во распоряжений
        /// </summary>
        public int CountOrder
        {

            get
            {
                this.Load();
                return listOrder.Count;
            }
        }
        /// <summary>
        /// Добавление нового распоряжения в список
        /// </summary>
        /// <param name="neworder">Объект распоряжения</param>
        /// <returns>Объект с присвоенным идентификатором</returns>
        public Order_v2 AddOrder(Order_v2 neworder)
        {
            this.Load();
            neworder.ID = listOrder.Count;
            listOrder.Add(neworder);
            this.Save();
            return neworder;
        }
        /// <summary>
        /// Сохранение списка
        /// </summary>
        public void Save()
        {
            BinaryFormatter data = new BinaryFormatter();
            FileStream file = File.Open(FILE, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            data.Serialize(file, this.listOrder);
            file.Close();
        }
        /// <summary>
        /// Загрузска списка из файла
        /// </summary>
        public void Load()
        {
            listOrder.Clear();
            BinaryFormatter data = new BinaryFormatter();
            if (!File.Exists(FILE))
            {
                FileStream f = File.Open(FILE, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                f.Close();
            }

            FileStream file = File.Open(FILE, FileMode.Open, FileAccess.ReadWrite);
            try
            {
                listOrder = (data.Deserialize(file) as List<Order_v2>);
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                new Log("Error ListOrder_v2 of: " + e.Message);
            }

            file.Close();
        }
    }
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