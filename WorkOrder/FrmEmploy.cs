﻿using oalib;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Text;


namespace WorkOrder
{
    public enum TYPE_RULE
    {
        Give,
        Fore,
        Other
    }
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



        public List<Emp> SelList = new List<Emp>();
        public TYPE_RULE Type_rule = new TYPE_RULE();
        private int MaxCountList = 0;
        #endregion

        private string WithName(int index)
        {
            string str = checkedListBox1.Items[index].ToString();
            string[] data = str.Split(new char[] { ' ' });
            string name = data[0] + " " + data[1];
            return name;
        }


        public FrmEmploy()
        {
            InitializeComponent();
        }

        private void FrmEmploy_Load(object sender, EventArgs e)
        {
            switch (Type_rule)
            {
                case TYPE_RULE.Give:
                    MaxCountList = 1;
                    break;
                case TYPE_RULE.Fore:
                    MaxCountList = 1;
                    break;
                case TYPE_RULE.Other:
                    MaxCountList = 4;
                    break;
                default:
                    break;
            }
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
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    foreach (var item in SelList)
                    {
                        if (item.ToString() == checkedListBox1.Items[i].ToString())
                        {
                            checkedListBox1.SetItemChecked(i, true);
                        }
                    }
            


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
            label1.Text = "";
            foreach(Emp item in SelList)
            {
                label1.Text += item.ID.ToString() + "\t" + item.ToString() + "\n";
            }
        }

        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
            if (e.NewValue == CheckState.Checked)
            {
                
                DataTable dTable = SQL.Query("SELECT * FROM 'emp' WHERE name LIKE '%" + WithName(e.Index) + "%'");
                Emp emp = new Emp();
                if (dTable.Rows.Count == 1)
                {
                    emp = new Emp(dTable.Rows[0]);
                    SelList.Add(emp);
                }
                else new Log("Fail. Count rows: "+dTable.Rows.Count.ToString() );
            } 
            if (e.NewValue == CheckState.Unchecked)
            {
                DataTable dTable = SQL.Query("SELECT * FROM 'emp' WHERE name LIKE '%" + WithName(e.Index) + "%'");
                Emp emp = new Emp();
                if (dTable.Rows.Count == 1)
                {
                    emp = new Emp(dTable.Rows[0]);
                    SelList.Remove(emp);
                }
                else new Log("Fail. Count rows: " + dTable.Rows.Count.ToString());
            }
            
        }
    }
}
