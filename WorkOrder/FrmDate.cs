using System;
using System.Windows.Forms;

namespace WorkOrder
{
    public partial class FrmDate : Form
    {
        private DateTime date;
        private bool isSelec = false;
        public bool _IsSelected
        {
            get { return isSelec; }

        }

        public DateTime _Date
        {
            get { return date; }
            set { date = value; }
        }
        public FrmDate()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {

            isSelec = true;
            _Date = e.Start;
            Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Date = monthCalendar1.TodayDate;
            Close();
            //Hide();
        }

        private void FrmDate_Load(object sender, EventArgs e)
        {
            isSelec = false;
        }
    }
}
