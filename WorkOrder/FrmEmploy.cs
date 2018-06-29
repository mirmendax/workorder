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
    public partial class FrmEmploy : Form
    {
        #region Data(Emps_v2 and Emp_v2)
        private List<Emp_v2> _emps = new List<Emp_v2>();
        private Emp_v2 _selEmp = new Emp_v2();

        public List<Emp_v2> Emps
        {
            get { return _emps; }
            set { _emps = value; }
        }
        public Emp_v2 SelEmp
        {
            get { return _selEmp; }
            set { _selEmp = value; }
        }
        


        #endregion
        public FrmEmploy()
        {
            InitializeComponent();
        }

        private void FrmEmploy_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SelEmp = null;
            if (_emps != null)
            {
                for (int i = 0; i <= _emps.Count - 1; i++)
                {
                        listBox1.Items.Add(_emps[i]);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb.SelectedIndex != -1)
            {
                SelEmp = Emps[lb.SelectedIndex];
                Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

    }
}
