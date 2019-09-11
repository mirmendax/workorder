using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace oalib
{
    /// <summary>
    /// Объект списка распоряжений
    /// </summary>
    public class ListOrder
    {
        private const string FILE = "arhiveorder_v2.wo";
        public List<Order> listOrder;
        /// <summary>
        /// Список не подтвержденных распоряжений
        /// </summary>
        /// <returns>Список</returns>
        public List<Order> NotVerifydOrderList()
        {
            List<Order> result = new List<Order>();

            DataTable dT = SQL.Query("SELECT * FROM 'order' WHERE number = 0");
            foreach (DataRow item in dT.Rows)
            {
                Order temp = new Order(item);
                result.Add(temp);
            }

            return result;
        }


        /// <summary>
        /// Подтверждение распоряжения
        /// </summary>
        /// <param name="ord">Объект распоряжения </param>
        /// <param name="numOrder">Номер распоряжения</param>
        /// <returns>Если true значит подтвеждено</returns>
        public static bool VerifyOrder(int id, int numOrder)
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

                string str_update = "UPDATE 'order' SET 'number' = @number WHERE id = @id";

                SQLiteCommand Command = new SQLiteCommand(str_update, Conn);
                Command.Parameters.AddWithValue("@number", numOrder);
                Command.Parameters.AddWithValue("@id", id);
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
        /// Удаление не подтвержденного расоряжения
        /// </summary>
        /// <param name="delOrder">Объект распоряжения</param>
        /// <returns>Если true то удалено</returns>
        public static bool DeleteOrderNotVerify(int id)
        {
            return SQL.Delete(id, "order");
        }
        /// <summary>
        /// Поиск распоряжений
        /// </summary>
        /// <param name="fOrder">Объект распоряжения</param>
        /// <returns>Порядковый номер в списке</returns>
        public int FindOrder(Order fOrder)
        {
            Load();
            int result = -1;
            for (int i = 0; i <= listOrder.Count - 1; i++)
            {
                if (listOrder[i].Equals(fOrder))
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        public ListOrder()
        {
            listOrder = new List<Order>();
        }

        /// <summary>
        /// Список распоряжений в заданом интервале времени
        /// </summary>
        /// <param name="a">С</param>
        /// <param name="b">По</param>
        /// <returns>Список распоряжений</returns>
        public static List<Order> ShowOrders(List<Order> data, DateTime a, DateTime b)
        {

            List<Order> result = new List<Order>();
            List<DateTime> dd = new List<DateTime>();
            DateTime dcount = a;
            while (dcount <= b)
            {
                dd.Add(dcount);
                dcount = dcount.AddDays(1);
            }

            IEnumerable<Order> query = from o in data
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
                DataTable dTable = SQL.Query("SELECT count(*) AS 'count' FROM `order` WHERE number != 0");
                try
                {
                    return int.Parse(dTable.Rows[0]["count"].ToString());
                }
                catch (Exception ex)
                {
                    new Log("Error parse: " + ex.Message);
                    return 0;
                }
            }
        }
        /// <summary>
        /// Добавление нового распоряжения в список
        /// </summary>
        /// <param name="neworder">Объект распоряжения</param>
        /// <returns>Объект с присвоенным идентификатором</returns>
        public bool AddOrder(Order neworder)
        {
            return SQL.Insert(neworder);

        }
        /// <summary>
        /// Сохранение списка
        /// </summary>
        public void Save()
        {
            BinaryFormatter data = new BinaryFormatter();
            FileStream file = File.Open(FILE, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            data.Serialize(file, listOrder);
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
                listOrder = data.Deserialize(file) as List<Order>;
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                new Log("Error ListOrder_v2 of: " + e.Message);
            }

            file.Close();
        }
    }
}