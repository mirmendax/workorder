using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using oalib;

namespace WorkOrder
{
    public partial class FrmArhive : Form
    {
        #region Data (ListOrder, SelOrder, isSelected, IsDeleteAll)
        List<Order> ListOrder = new List<Order>();
        private Order _selorder = new Order();
        private bool _selected = false;
        
        public Order SelOrder
        {
            get { return _selorder; }
            set { _selorder = value; }
        }
        public bool isSelected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        #endregion

        public int ID = 0;

        public FrmArhive()
        {
            InitializeComponent();
        }

        

        void OnRewriteListBox()
        {
            listBox1.Items.Clear();
            ListOrder.Clear();

            // Заполнение listbox'а из данных таблицы 
            DataTable dTable = SQL.Query("SELECT * FROM 'order' WHERE number != 0 ORDER BY id DESC");
            foreach (DataRow item in dTable.Rows)
            {
                
                Order o = new Order(item);
                ListOrder.Add(o);
                string s = string.Format("{0}:\t{1}:{2}:{3} >{4}", o.ID.ToString(), o.date.ToString(Const.DATE_FORMAT), o.GiveOrder, o.ForePerson, o.estr);
                listBox1.Items.Add(s);
            }

            //Подсчет Всего распоряжений
            dTable = SQL.Query("SELECT count(*) AS 'count' FROM `order`");
            label6.Text = dTable.Rows[0]["count"].ToString();

            //Подсчет не подтвержденных распоряжений
            dTable = SQL.Query("SELECT count(*) AS 'count' FROM `order` WHERE number = 0");
            label8.Text = dTable.Rows[0]["count"].ToString();
            button2.Enabled = false;
        }

        void OnRewriteListBox(List<Order> list)
        {
            
            listBox1.Items.Clear();
            
            // Заполнение listbox'а из данных таблицы 
            foreach (Order o in list)
            {

                string s = string.Format("{0}:\t{1}:{2}:{3} >{4}", o.ID.ToString(), o.date.ToString(Const.DATE_FORMAT), o.GiveOrder, o.ForePerson, o.estr);
                listBox1.Items.Add(s);
            }
            label7.Text = listBox1.Items.Count.ToString();
        }


        private void FrmArhive_Load(object sender, EventArgs e)
        {

            OnRewriteListBox();
            isSelected = false;
            SelOrder = null;
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            ID = Tools.IsID(lb.SelectedItem.ToString());
            
            button2.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                DataTable dTable = SQL.Query("SELECT * FROM 'order' WHERE id=" + ID.ToString());
                SelOrder = new Order(dTable.Rows[0]);
                
                isSelected = true;
                Hide();
            }
            else button2.Enabled = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dTable = SQL.Query("SELECT * FROM 'order' WHERE number != 0");
            List<Order> templist = new List<Order>();
            foreach (DataRow item in dTable.Rows)
            {
                templist.Add(new Order(item));
            }
            templist = oalib.ListOrder.ShowOrders(templist, dateFrom.SelectionStart, dateTo.SelectionStart);
            OnRewriteListBox(templist);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OnRewriteListBox();
            label7.Text = listBox1.Items.Count.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить архив?", "Удалить архив?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                
                Hide();
            }
        }
    }
}
