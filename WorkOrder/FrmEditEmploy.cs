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
    public partial class FrmEditEmploy : Form
    {
        #region Data (NewListEmp, ListEmp, IsSaved)
        private List<Emp_v2> _listEmp;
        private bool _isSave = false;
        private List<Emp_v2> _newListEmp;
        public List<Emp_v2> NewListEmp
        {
            get { return _newListEmp; }
            set { _newListEmp = value; }
        }
        public List<Emp_v2> ListEmps
        {
            get { return _listEmp; }
            set { _listEmp = value; }
        }
        public bool IsSaved
        {
            get { return _isSave; }
            set { _isSave = value; }
        }
        #endregion
        public FrmEditEmploy()
        {
            InitializeComponent();
        }

        public void onRewriteListBox(List<Emp_v2> _l)
        {
            listEmpLBox.Items.Clear();
            const string gTrue = "*";
            const string fTrue = "#";
            const string False = "";
            for (int i = 0; i <= _l.Count - 1; i++)
            {
                listEmpLBox.Items.Add(string.Format("{0}  {1}  {2}",
                    _l[i].ToString(), (_l[i].RuleGiveOrder) ? gTrue : False, (_l[i].RuleForePerson) ? fTrue : False));
            }
        }

        public void onRewriteEmploy(Emp_v2 emp)
        {
            nameTBox.Text = emp.Name;
            groupBox.Value = emp.group;
            rGiveOrderChBox.Checked = emp.RuleGiveOrder;
            rForePersonChBox.Checked = emp.RuleForePerson;
            
            
        }

        private void frmEditEmploy_Load(object sender, EventArgs e)
        {
            onRewriteListBox(this.ListEmps);
            nameTBox.Text = "";
            groupBox.Value = 0;
            rGiveOrderChBox.CheckState = CheckState.Unchecked;
            rForePersonChBox.CheckState = CheckState.Unchecked;
            IsSaved = false;
        }

        private void abortButton_Click(object sender, EventArgs e)
        {
            IsSaved = false;
            Hide();
        }

        private void listEmpLBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            int i = lb.SelectedIndex;
            if (i != -1)
            {
                if (ListEmps[i] != null)
                    onRewriteEmploy(ListEmps[i]);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (nameTBox.Text != "" && groupBox.Value != 0)
            {
                Emp_v2 editEmp = new Emp_v2(nameTBox.Text, (int)groupBox.Value, rGiveOrderChBox.Checked, rForePersonChBox.Checked);
                if (listEmpLBox.SelectedIndex != -1)
                {
                    ListEmps[listEmpLBox.SelectedIndex] = editEmp;
                    onRewriteListBox(ListEmps);
                    SaveButton.ForeColor = Color.Red;
                }

            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (nameTBox.Text != "" && groupBox.Value != 0)
            {
                Emp_v2 newEmp = new Emp_v2(nameTBox.Text, (int)groupBox.Value, rGiveOrderChBox.Checked, rForePersonChBox.Checked);
                ListEmps.Add(newEmp);
                onRewriteListBox(ListEmps);
            }
            
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            IsSaved = true;
            NewListEmp = ListEmps;
            //SaveButton.ForeColor = Color.Black;
            Hide();
        }

        private void delbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (listEmpLBox.SelectedIndex != -1)
                {
                    ListEmps.Remove(ListEmps[listEmpLBox.SelectedIndex]);
                    onRewriteListBox(ListEmps);
                    onRewriteEmploy(new Emp_v2("", 2));
                }
            }
            catch (Exception ex) { new Log("Error delete user: " + ex.Message); }
        }
    }
}
