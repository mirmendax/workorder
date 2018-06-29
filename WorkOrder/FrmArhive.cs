using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using oalib_v2;

namespace WorkOrder
{
    public partial class FrmArhive : Form
    {
        #region Data (ListOrder, SelOrder, isSelected, IsDeleteAll)
        private ListOrder_v2 _list = new ListOrder_v2();
        private Order_v2 _selorder = new Order_v2();
        private bool _selected = false;
        private bool _isDeleteAll = false;
        public ListOrder_v2 ListOrder
        {
            get { return _list; }
            set { _list = value; }
        }
        public Order_v2 SelOrder
        {
            get { return _selorder; }
            set { _selorder = value; }
        }
        public bool isSelected
        {
            get { return _selected; }
            set { _selected = value; }
        }
        public bool IsDeleteAll
        {
            get { return _isDeleteAll; }
            set { _isDeleteAll = value; }
        }
        #endregion

        List<Order_v2> _orderList = new List<Order_v2>();
        public FrmArhive()
        {
            InitializeComponent();
        }

        

        void OnRewriteListBox()
        {
            button2.Enabled = false;
            listBox1.Items.Clear();
            foreach (Order_v2 o in _orderList)
            {
                //string s = string.Format("{0}:{1}:{2} >{3}", o.date.ToString(), o.ID, o.number, o.estr);
                string s = string.Format("{0}:{1}:{2} >{3}", o.date.ToString(Form1.DATE_FORMAT), o.GiveOrder, o.ForePerson, o.estr);
                listBox1.Items.Add(s);
            }
            label6.Text = ListOrder.listOrder.Count.ToString();
            label7.Text = _orderList.Count.ToString();
            //int i=0;
            //foreach (Order_v2 o in ListOrder.listOrder)
                //if (o.number == 0) i++;
            label8.Text = ListOrder.NotVerifydOrderList().Count.ToString();
        }
        

        private void FrmArhive_Load(object sender, EventArgs e)
        {
            
            _orderList.Clear();
            isSelected = false;
            SelOrder = null;
            IsDeleteAll = false;

            //listBox1.Items.Clear();
            if (ListOrder != null)
            {
                /*
                foreach (Order_v2 o in ListOrder.listOrder)
                {
                    if (o.number != 0)
                    {
                        _orderList.Add(o);
                        
                    }
                }
                */
                IEnumerable<Order_v2> query = from o in ListOrder.listOrder
                                              where o.number > 0
                                              select o;
                _orderList = query.ToList();
                
                OnRewriteListBox();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            if (lb.SelectedIndex != -1 && _orderList.Count != 0)
            {
                SelOrder = _orderList[lb.SelectedIndex];
                SelOrder.number = 0;
                button2.Enabled = true;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isSelected = true;
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _orderList.Clear();
            _orderList = ListOrder.ShowOrders(dateFrom.SelectionStart, dateTo.SelectionStart);
            
            OnRewriteListBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _orderList.Clear();
            /*
            foreach (Order_v2 o in _list.listOrder)
            {
                if (o.number != 0)
                {
                    _orderList.Add(o);

                }
            }*/
            IEnumerable<Order_v2> query = from o in _list.listOrder
                                          where o.number > 0
                                          select o;
            _orderList = query.ToList();
            OnRewriteListBox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить архив?", "Удалить архив?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                IsDeleteAll = true;
                Hide();
            }
        }
    }
}
