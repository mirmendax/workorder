using oalib;
using System;
using System.Data;
using System.Windows.Forms;

namespace WorkOrder
{
    public partial class FrmVerifyOrder : Form
    {
        #region (Order(_ord), Number(_number) IsVerify(_isVerify) IsDelOrder(_isDelOrd)
        private Order Order;
        private int _number;


        #endregion


        public FrmVerifyOrder()
        {
            InitializeComponent();
        }

        private void FrmVerifyOrder_Load(object sender, EventArgs e)
        {
            DataTable dTable = SQL.Query("SELECT * FROM 'order' WHERE number = 0");
            if (dTable.Rows.Count > 0)
            {
                Order = new Order(dTable.Rows[0]);
                
                if (Order != null)
                {
                    estrlbl.Text = Order.estr;
                    instlbl.Text = Order.instr;
                    giveprslbl.Text = Order.GiveOrder.ToString();
                    foreprslbl.Text = Order.ForePerson.ToString();
                    datelbl.Text = Order.date.ToString(Const.DATE_FORMAT);
                    string s = string.Empty;
                    for (int i = 0; i <= Order.teamOrder.Count - 1; i++)
                    {
                        s += Order.teamOrder[i].ToString() + "\n";
                    }
                    brglbl.Text = s;
                }
            }
        }

        private void verifybtn_Click(object sender, EventArgs e)
        {
            try
            {
                Random rnumber = new Random();
                _number = rnumber.Next(1, 100);
                if (ListOrder.VerifyOrder(Order.ID, _number))
                    Hide();
                else
                {
                    MessageBox.Show("Ошибка подтвеждения распоряжения.");
                    Hide();
                }
            }
            catch (Exception ex)
            {
                new Log("Error verify number " + ex.Message);
            }

        }

        private void delordbtn_Click(object sender, EventArgs e)
        {
            if (ListOrder.DeleteOrderNotVerify(Order.ID))
                Hide();
            else
            {
                MessageBox.Show("Ошибка удаления распоряжения.");
                Hide();
            }

        }
    }
}
