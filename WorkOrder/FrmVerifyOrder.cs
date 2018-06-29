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
    public partial class FrmVerifyOrder : Form
    {
        #region (Order(_ord), Number(_number) IsVerify(_isVerify) IsDelOrder(_isDelOrd)
        private Order_v2 _ord;
        private int _number = 0;
        private bool _isVerify = false;
        private bool _isDelOrd = false;
        public Order_v2 Order
        {
            get { return _ord; }
            set { _ord = value; }
        }
        public int Number
        {
            get { return _number; }
        }
        public bool IsVerify
        {
            get { return _isVerify; }
        }
        public bool IsDelOrder
        {
            get { return _isDelOrd; }
        }
        #endregion


        public FrmVerifyOrder()
        {
            InitializeComponent();
        }

        private void FrmVerifyOrder_Load(object sender, EventArgs e)
        {
            _isDelOrd = false;
            _isVerify = false;
            _number = 0;
            numberTBox.Value = _number;
            if (_ord != null)
            {
                estrlbl.Text = _ord.estr;
                instlbl.Text = _ord.instr;
                giveprslbl.Text = _ord.GiveOrder.ToString();
                foreprslbl.Text = _ord.ForePerson.ToString();
                datelbl.Text = _ord.date.ToString("d.MM.yyyy");
                string s = string.Empty;
                for (int i = 0; i <= _ord.brigada.Count - 1; i++)
                {
                    s += _ord.brigada[i].ToString() + "\n";
                }
                brglbl.Text = s;
            }
        }

        private void verifybtn_Click(object sender, EventArgs e)
        {
            try
            {
                _number = (int)numberTBox.Value;
                _isVerify = true;
                Hide();
            }
            catch (Exception ex)
            {
                new Log("Error verify number " + ex.Message);
            }

        }

        private void delordbtn_Click(object sender, EventArgs e)
        {
            _isDelOrd = true;
            Hide();
        }
    }
}
