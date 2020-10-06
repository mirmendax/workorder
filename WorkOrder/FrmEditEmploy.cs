using oalib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WorkOrder
{
    public partial class FrmEditEmploy : Form
    {

        public FrmEditEmploy()
        {
            InitializeComponent();
        }



        public void OnRewriteListBox()
        {
            //System.Diagnostics.Debugger.Break();
            ItemCheckEventHandler nullhandler = null;
            nullhandler = (s, a) => { };
            cListBox.ItemCheck -= ItemCheck;
            //List<Emp> list = new List<Emp>();
            DataTable dTable = SQL.Query("SELECT * FROM 'emp' ");
            //listEmpLBox.Items.Clear();
            cListBox.Items.Clear();
            const string gTrue = "*";
            const string fTrue = "#";
            const string False = "";
            foreach (DataRow item in dTable.Rows)
            {
                Emp temp = new Emp(item);
                var str = string.Format("{0}: {1}  {2}  {3}", temp.ID.ToString(),
                   temp.ToString(), (temp.RuleGiveOrder) ? gTrue : False, (temp.RuleForePerson) ? fTrue : False);
                //listEmpLBox.Items.Add(str);
                var hidemode = false;
                if (item["hide"].ToString() == "0")
                {
                    hidemode = true;
                }
                else
                {
                    hidemode = false;
                }
                cListBox.Items.Add(str, hidemode);
                //list.Add(temp);
            }

            
            cListBox.ItemCheck += ItemCheck;
        }

        public void OnRewriteEmploy(Emp emp)
        {
            nameTBox.Text = emp.Name;
            groupBox.Value = emp.group;
            rGiveOrderChBox.Checked = emp.RuleGiveOrder;
            rForePersonChBox.Checked = emp.RuleForePerson;


        }

        private void frmEditEmploy_Load(object sender, EventArgs e)
        {
            OnRewriteListBox();
            nameTBox.Text = "";
            groupBox.Value = 0;
            rGiveOrderChBox.CheckState = CheckState.Unchecked;
            rForePersonChBox.CheckState = CheckState.Unchecked;
        }

        private void abortButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void listEmpLBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            string str = lb.SelectedItem.ToString();
            string[] s = str.Split(new char[] { ':' });
            int id = int.Parse(s[0]);
            if (id != 0)
            {
                DataTable dTable = SQL.Query("SELECT * FROM 'emp' WHERE `id`=" + id.ToString());
                Emp temp = new Emp(dTable.Rows[0]);
                OnRewriteEmploy(temp);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (nameTBox.Text != "" && groupBox.Value != 0)
            {
                Emp editEmp = new Emp(nameTBox.Text, (int)groupBox.Value, rGiveOrderChBox.Checked, rForePersonChBox.Checked);
                int id = Tools.IsID(cListBox.SelectedItem.ToString());
                if (id != 0)
                {
                    SQL.Update(id, editEmp);
                    OnRewriteListBox();
                    OnRewriteEmploy(new Emp("", 2));
                }

            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (nameTBox.Text != "" && groupBox.Value != 0)
            {
                Emp newEmp = new Emp(nameTBox.Text, (int)groupBox.Value, rGiveOrderChBox.Checked, rForePersonChBox.Checked);
                SQL.Insert(newEmp);

                OnRewriteListBox();
                OnRewriteEmploy(new Emp("", 2));
            }

        }


        private void delbutton_Click(object sender, EventArgs e)
        {
            int id = Tools.IsID(cListBox.SelectedItem.ToString());
            if (id != 0)
            {
                SQL.Delete(id, "emp");
                OnRewriteListBox();
                OnRewriteEmploy(new Emp("", 2));
            }
        }

        private void ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (cListBox.SelectedItem == null) return;

            int id = Tools.IsID(cListBox.SelectedItem.ToString());
            if (id == 0) return;
            bool mode = true;
            if (e.NewValue == CheckState.Checked)
            {
                mode = true;
            }
            if (e.NewValue == CheckState.Unchecked)
            {
                mode = false;
            }
            SQL.EditHideModeEmploy(id, mode);
        }

        private void cListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            int id = Tools.IsID(cListBox.SelectedItem.ToString());
            if (id != 0)
            {
                DataTable dTable = SQL.Query("SELECT * FROM 'emp' WHERE `id`=" + id.ToString());
                Emp temp = new Emp(dTable.Rows[0]);
                OnRewriteEmploy(temp);
            }
        }
    }
}
