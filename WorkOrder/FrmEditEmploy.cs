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
            List<Emp> list = new List<Emp>();
            DataTable dTable = SQL.Query("SELECT * FROM 'emp' WHERE hide = 0");
            foreach (DataRow item in dTable.Rows)
            {
                Emp temp = new Emp(item);
                list.Add(temp);
            }

            listEmpLBox.Items.Clear();
            const string gTrue = "*";
            const string fTrue = "#";
            const string False = "";
            foreach (Emp item in list)
            {
                listEmpLBox.Items.Add(string.Format("{0}: {1}  {2}  {3}", item.ID.ToString(),
                    item.ToString(), (item.RuleGiveOrder) ? gTrue : False, (item.RuleForePerson) ? fTrue : False));
            }
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
                int id = Tools.IsID(listEmpLBox.SelectedItem.ToString());
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
            int id = Tools.IsID(listEmpLBox.SelectedItem.ToString());
            if (id != 0)
            {
                SQL.Delete(id, "emp");
                OnRewriteListBox();
                OnRewriteEmploy(new Emp("", 2));
            }
        }
    }
}
