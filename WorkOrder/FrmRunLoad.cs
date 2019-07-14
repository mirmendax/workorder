using System;
using System.Windows.Forms;

namespace WorkOrder
{
    public partial class FrmRunLoad : Form
    {
        private int progres = 0;

        public FrmRunLoad()
        {
            InitializeComponent();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            progres++;
            if (progres >= 100)
                Close();
        }

        private void FrmRunLoad_Load(object sender, EventArgs e)
        {

        }
    }
}
