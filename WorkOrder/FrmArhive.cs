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
        List<Order_v2> ListOrder = new List<Order_v2>();
        private Order_v2 _selorder = new Order_v2();
        private bool _selected = false;
        
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
        
        #endregion

        public FrmArhive()
        {
            InitializeComponent();
        }

        

        void OnRewriteListBox()
        {
            DataTable dTable = SQL.Query("SELECT * FROM 'order' WHERE number != 0");
            listBox1.Items.Clear();
            ListOrder.Clear();
            foreach (DataRow item in dTable.Rows)
            {
                
                Order_v2 o = new Order_v2(item);
                ListOrder.Add(o);
                string s = string.Format("{0}:{1}:{2}:{3} >{4}", o.ID.ToString(), o.date.ToString(Const.DATE_FORMAT), o.GiveOrder, o.ForePerson, o.estr);
                listBox1.Items.Add(s);
            }
            dTable = SQL.Query("SELECT count(*) AS 'count' FROM `order`");
            label6.Text = dTable.Rows[0]["count"].ToString();
            //
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
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isSelected = true;
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
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
