using oalib;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WorkOrder
{
    public partial class FrmEmploy : Form
    {
        #region Data(Emps_v2 and Emp_v2)
        private List<Emp> _emps = new List<Emp>();
        private Emp _selEmp = new Emp();

        public List<Emp> Emps
        {
            get { return _emps; }
            set { _emps = value; }
        }
        public Emp SelEmp
        {
            get { return _selEmp; }
            set { _selEmp = value; }
        }

        List<Emp> sellist = new List<Emp>();


        #endregion
        public FrmEmploy()
        {
            InitializeComponent();
        }

        private void FrmEmploy_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            checkedListBox1.Items.Clear();
            
            SelEmp = null;
            if (_emps != null)
            {
                for (int i = 0; i <= _emps.Count - 1; i++)
                {
                    listBox1.Items.Add(_emps[i]);
                    checkedListBox1.Items.Add(_emps[i]);
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

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int i = sellist.Count;
            MessageBox.Show(i.ToString());
        }

        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            MessageBox.Show(e.NewValue.ToString());/// Вот истина!!!! идти по этому пути!!!!
            
        }
    }
}
